namespace ProductShop.App
{
    using ProductShop.App.Dtos.Import;
    using ProductShop.Models;

    using AutoMapper;
    using System.IO;
    using System.Xml.Serialization;
    using System;
    using System.Collections.Generic;
    using DataAnnotations = System.ComponentModel.DataAnnotations;
    using ProductShop.Data;
    using System.Linq;
    using ProductShop.App.Dtos.Export;
    using System.Text;
    using System.Xml;

    public class StartUp
    {
        public static void Main()
        {
            // var xmlUsersString = File.ReadAllText("../../../Xml/users.xml");
            // var xmlProductsString = File.ReadAllText("../../../Xml/products.xml");
            // var xmlCategoriesString = File.ReadAllText("../../../Xml/categories.xml");

            // var serializer = new XmlSerializer(typeof(UserDto[]), new XmlRootAttribute("users"));
            // var serializer = new XmlSerializer(typeof(ProductDto[]), new XmlRootAttribute("products"));
            // var serializer = new XmlSerializer(typeof(CategoryDto[]), new XmlRootAttribute("categories"));

            // var deserializedUsers = (UserDto[])serializer.Deserialize(new StringReader(xmlUsersString));
            // var deserializedProducts = (ProductDto[])serializer.Deserialize(new StringReader(xmlProductsString));
            // var deserializedCategories = (CategoryDto[])serializer.Deserialize(new StringReader(xmlCategoriesString));

            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.AddProfile<ProductShopProfile>();
            //});

            //var mapper = config.CreateMapper();

            // var users = new List<User>();
            // var products = new List<Product>();
            //  var categories = new List<Category>();

            //foreach (var userDto in deserializedUsers)
            //{
            //    if (!IsValid(userDto))
            //    {
            //        continue;
            //    }

            //    var user = mapper.Map<User>(userDto);

            //    users.Add(user);
            //}

            //int count = 1;

            //foreach (var productDto in deserializedProducts)
            //{
            //    if (!IsValid(productDto))
            //    {
            //        continue;
            //    }

            //    var product = mapper.Map<Product>(productDto);

            //    var buyerId = new Random().Next(1, 30);
            //    var sellerId = new Random().Next(31, 56);

            //    product.BuyerId = buyerId;
            //    product.SellerId = sellerId;

            //    if (count == 4)
            //    {
            //        product.BuyerId = null;
            //        count = 0;
            //    }

            //    products.Add(product);

            //    count++;
            //}

            //foreach (var categoryDto in deserializedCategories)
            //{
            //    if (!IsValid(categoryDto))
            //    {
            //        continue;
            //    }

            //    var category = mapper.Map<Category>(categoryDto);

            //    categories.Add(category);
            //}

            //var categoryProducts = new List<CategoryProduct>();

            //for (int prodcutId = 3; prodcutId <= 202; prodcutId++)
            //{
            //    var categoryId = new Random().Next(1, 12);

            //    var categoryProduct = new CategoryProduct()
            //    {
            //        ProductId = prodcutId,
            //        CategoryId = categoryId
            //    };

            //    categoryProducts.Add(categoryProduct);
            //}

            var context = new ProductShopContext();
            // context.Users.AddRange(users);
            // context.Products.AddRange(products);
            // context.Categories.AddRange(categories);
            // context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            var db = new ProductShopContext();

            // GetProductsInRange(db);
            // GetSoldProducts(db);
            // GetCategoriesByProductsCount(db);
            // GetUserAndProducts(db);
        }

        private static void GetUserAndProducts(ProductShopContext db)
        {
            var users = new UserRootDto
            {
                Count = db.Users.Count(),
                Users = db.Users
                                      .Where(x => x.ProductsSold.Count >= 1)
                                      .Select(x => new UserPdto
                                      {
                                          FirstName = x.FirstName,
                                          LastName = x.LastName,
                                          Age = x.Age.ToString(),
                                          SoldProducts = new SoldProductDto
                                          {
                                              Count = x.ProductsSold.Count(),
                                              ProductUdtos = x.ProductsSold
                                                             .Select(k => new ProductUdto
                                                             {
                                                                 Name = k.Name,
                                                                 Price = k.Price
                                                             })
                                                             .ToList()
                                          }
                                      })
                                      .ToList()
            };

            var sb = new StringBuilder();
            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            var serializer = new XmlSerializer(typeof(UserRootDto), new XmlRootAttribute("users"));
            serializer.Serialize(new StringWriter(sb), users, xmlNamespaces);

            File.WriteAllText("../../../Xml/users-and-products.xml", sb.ToString());
        }

        private static void GetCategoriesByProductsCount(ProductShopContext db)
        {
            var categories = db.Categories
                            .OrderByDescending(c => c.CategoryProducts.Count)
                            .Select(x => new CategoryDTO
                            {
                                Name = x.Name,
                                Count = x.CategoryProducts.Count,
                                AveragePrice = x.CategoryProducts.Select(p => p.Product.Price).DefaultIfEmpty(0).Average(),
                                TotalRevenue = x.CategoryProducts.Sum(p => p.Product.Price)
                            })
                            .ToList();

            var sb = new StringBuilder();
            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            var serializer = new XmlSerializer(typeof(List<CategoryDTO>), new XmlRootAttribute("categories"));
            serializer.Serialize(new StringWriter(sb), categories, xmlNamespaces);

            File.WriteAllText("../../../Xml/categories-by-products.xml", sb.ToString());
        }

        private static void GetSoldProducts(ProductShopContext db)
        {
            var users = db.Users
                .Where(p => p.ProductsSold.Count >= 1)
                .OrderBy(ln => ln.LastName)
                .ThenBy(fn => fn.FirstName)
                .Select(x => new UserDTO
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SoldProducts = x.ProductsSold
                                    .Select(s => new SoldProduct
                                    {
                                        Name = s.Name,
                                        Price = s.Price
                                    })
                                    .ToList()
                })
                .ToList();

            var sb = new StringBuilder();
            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            var serializer = new XmlSerializer(typeof(List<UserDTO>), new XmlRootAttribute("users"));
            serializer.Serialize(new StringWriter(sb), users, xmlNamespaces);

            File.WriteAllText("../../../Xml/users-sold-products.xml", sb.ToString());
        }

        private static void GetProductsInRange(ProductShopContext db)
        {
            var products = db.Products
                .Where(p => p.Price >= 1000 && p.Price <= 2000 && p.Buyer != null)
                .OrderBy(p => p.Price)
                .Select(x => new ProductDTO
                {
                    Name = x.Name,
                    Price = x.Price,
                    Buyer = x.Buyer.FirstName + " " + x.Buyer.LastName ?? x.Buyer.LastName
                })
                .ToList();

            var sb = new StringBuilder();
            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            var serializer = new XmlSerializer(typeof(List<ProductDTO>), new XmlRootAttribute("products"));
            serializer.Serialize(new StringWriter(sb), products, xmlNamespaces);

            File.WriteAllText("../../../Xml/products-in-range.xml", sb.ToString());
        }

        //public static bool IsValid(object obj)
        //{
        //    var validationContext = new DataAnnotations.ValidationContext(obj);
        //    var validationResult = new List<DataAnnotations.ValidationResult>();

        //    return DataAnnotations.Validator.TryValidateObject(obj, validationContext, validationResult, true);
        //}
    }
}