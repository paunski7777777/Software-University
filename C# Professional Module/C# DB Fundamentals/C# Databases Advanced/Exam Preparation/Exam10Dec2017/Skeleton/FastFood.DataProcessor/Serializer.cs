namespace FastFood.DataProcessor
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml;

    using Newtonsoft.Json;

    using FastFood.Data;
    using FastFood.DataProcessor.Dto.Export;
    using FastFood.Models.Enums;


    public class Serializer
    {
        public static string ExportOrdersByEmployee(FastFoodDbContext context, string employeeName, string orderType)
        {
            var orderTypeEnum = Enum.Parse<OrderType>(orderType);

            var employee = context.Employees
                                  .ToList()
                                  .Where(n => n.Name == employeeName)
                                  .Select(e => new
                                  {
                                      Name = e.Name,
                                      Orders = e.Orders
                                                .Where(t => t.Type == orderTypeEnum)
                                                .Select(o => new
                                                {
                                                    Customer = o.Customer,
                                                    Items = o.OrderItems
                                                             .Select(i => new
                                                             {
                                                                 Name = i.Item.Name,
                                                                 Price = i.Item.Price,
                                                                 Quantity = i.Quantity
                                                             })
                                                             .ToList(),
                                                    TotalPrice = o.TotalPrice
                                                })
                                                .OrderByDescending(tp => tp.TotalPrice)
                                                .ThenByDescending(c => c.Items.Count)
                                                .ToList(),
                                      TotalMade = e.Orders
                                                   .Where(ot => ot.Type == orderTypeEnum)
                                                   .Sum(tp => tp.TotalPrice)
                                  })
                                  .FirstOrDefault();

            var jsonString = JsonConvert.SerializeObject(employee, Newtonsoft.Json.Formatting.Indented);

            return jsonString;
        }

        public static string ExportCategoryStatistics(FastFoodDbContext context, string categoriesString)
        {
            var categoriesArray = categoriesString.Split(',');

            var categories = context.Categories
                                    .Where(c => categoriesArray
                                                .Any(n => n == c.Name))
                                    .Select(n => new CategoryDto
                                    {
                                        Name = n.Name,
                                        MostPopularItem = n.Items
                                                            .Select(mpi => new MostPopularItemDto
                                                            {
                                                                Name = mpi.Name,
                                                                TimesSold = mpi.OrderItems
                                                                               .Sum(q => q.Quantity),
                                                                TotalMade = mpi.OrderItems
                                                                               .Sum(tm => tm.Item.Price * tm.Quantity)
                                                            })
                                                            .OrderByDescending(x => x.TotalMade)
                                                            .ThenByDescending(x => x.TimesSold)
                                                            .FirstOrDefault()
                                    })
                                    .OrderByDescending(x => x.MostPopularItem.TotalMade)
                                    .ThenByDescending(x => x.MostPopularItem.TimesSold)
                                    .ToList();

            var sb = new StringBuilder();

            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            var serializer = new XmlSerializer(typeof(List<CategoryDto>), new XmlRootAttribute("Categories"));

            serializer.Serialize(new StringWriter(sb), categories, xmlNamespaces);

            return sb.ToString().TrimEnd();
        }
    }
}