namespace FastFood.DataProcessor
{
    using FastFood.Data;
    using FastFood.DataProcessor.Dto.Import;
    using FastFood.Models;
    using FastFood.Models.Enums;
    using Newtonsoft.Json;

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public static class Deserializer
    {
        private const string FailureMessage = "Invalid data format.";
        private const string SuccessMessage = "Record {0} successfully imported.";

        public static string ImportEmployees(FastFoodDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var deserializedEmployees = JsonConvert.DeserializeObject<EmployeeDto[]>(jsonString);

            var employees = new List<Employee>();

            foreach (var employeeDto in deserializedEmployees)
            {
                if (!IsValid(employeeDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                Position position = GetPosition(context, employeeDto.Position);

                var employee = new Employee
                {
                    Name = employeeDto.Name,
                    Age = employeeDto.Age,
                    Position = position
                };

                employees.Add(employee);

                sb.AppendLine(string.Format(SuccessMessage, employee.Name));
            }

            context.Employees.AddRange(employees);

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportItems(FastFoodDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var deserializedItems = JsonConvert.DeserializeObject<ItemDto[]>(jsonString);

            var items = new List<Item>();

            foreach (var itemDto in deserializedItems)
            {
                if (!IsValid(itemDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var itemExists = items.Any(n => n.Name == itemDto.Name);

                if (itemExists)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                Category category = GetCategory(context, itemDto.Category);

                var item = new Item
                {
                    Name = itemDto.Name,
                    Price = itemDto.Price,
                    Category = category
                };

                items.Add(item);

                sb.AppendLine(string.Format(SuccessMessage, item.Name));
            }

            context.Items.AddRange(items);

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOrders(FastFoodDbContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var serializer = new XmlSerializer(typeof(OrderDto[]), new XmlRootAttribute("Orders"));

            var deserializedOrders = (OrderDto[])serializer.Deserialize(new StringReader(xmlString));

            var orderItems = new List<OrderItem>();
            var orders = new List<Order>();

            foreach (var orderDto in deserializedOrders)
            {
                bool isValidItem = true;

                if (!IsValid(orderDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                foreach (var itemDto in orderDto.Items)
                {
                    if (!IsValid(itemDto))
                    {
                        sb.AppendLine(FailureMessage);
                        isValidItem = false;
                        break;
                    }
                }

                if (!isValidItem)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var employee = context.Employees.FirstOrDefault(n => n.Name == orderDto.Employee);

                if (employee == null)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var areValidItems = AreValidItems(context, orderDto.Items);

                if (!areValidItems)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var date = DateTime.ParseExact(orderDto.DateTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

                var orderType = Enum.Parse<OrderType>(orderDto.Type);

                var order = new Order
                {
                    Customer = orderDto.Customer,
                    Employee = employee,
                    DateTime = date,
                    Type = orderType
                };

                orders.Add(order);

                foreach (var itemDto in orderDto.Items)
                {
                    var item = context.Items.FirstOrDefault(n => n.Name == itemDto.Name);

                    var orderItem = new OrderItem
                    {
                        Order = order,
                        Item = item,
                        Quantity = itemDto.Quantity
                    };

                    orderItems.Add(orderItem);
                }

                sb.AppendLine($"Order for {orderDto.Customer} on {date.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)} added");
            }

            context.Orders.AddRange(orders);
            context.SaveChanges();

            context.OrderItems.AddRange(orderItems);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool AreValidItems(FastFoodDbContext context, List<OrderItemDto> items)
        {
            foreach (var item in items)
            {
                var itemExists = context.Items.Any(n => n.Name == item.Name);

                if (!itemExists)
                {
                    return false;
                }
            }

            return true;
        }
        private static Position GetPosition(FastFoodDbContext context, string positionName)
        {
            var position = context.Positions.FirstOrDefault(n => n.Name == positionName);

            if (position == null)
            {
                position = new Position
                {
                    Name = positionName
                };

                context.Positions.Add(position);

                context.SaveChanges();
            }

            return position;
        }
        private static Category GetCategory(FastFoodDbContext context, string categoryName)
        {
            var category = context.Categories.FirstOrDefault(n => n.Name == categoryName);

            if (category == null)
            {
                category = new Category
                {
                    Name = categoryName
                };

                context.Categories.Add(category);

                context.SaveChanges();
            }

            return category;
        }
        private static bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, validationResults, true);
        }
    }
}