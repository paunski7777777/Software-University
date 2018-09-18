namespace ProductShop.App
{
    using AutoMapper;

    using Data;
    using Models;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using DataAnnotations = System.ComponentModel.DataAnnotations;
    using System.IO;
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.AddProfile<ProductShopProfile>();
            //});

            //var mapper = config.CreateMapper();

            var context = new ProductShopContext();

            // ImportUsers(context);
            // ImportProducts(context);
            // ImportCategories(context);
            // ImportCategoryProducts(context);

            // ExportProductsInRange(context);
            // ExportSuccessfullySoldProducts(context);
            // ExportCategoriesByProductsCount(context);
            // ExportUserAndProducts(context);
        }

        private static void ExportUserAndProducts(ProductShopContext context)
        {
            var users = new
            {
                usersCount = context.Users.Count(),
                users = context.Users
                               .OrderByDescending(p => p.ProductsSold.Count)
                               .ThenBy(l => l.LastName)
                               .Where(p => p.ProductsSold.Count >= 1 && p.ProductsSold
                                                                        .Any(b => b.Buyer != null))
                               .Select(u => new
                               {
                                   firstName = u.FirstName,
                                   lastName = u.LastName,
                                   age = u.Age,
                                   soldProducts = new
                                   {
                                       count = u.ProductsSold.Count,
                                       products = u.ProductsSold
                                                  .Select(s => new
                                                  {
                                                      name = s.Name,
                                                      price = s.Price
                                                  })
                                                  .ToList()
                                   }
                               })
                               .ToList()
            };

            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };

            var jsonCategories = JsonConvert.SerializeObject(users, settings);

            File.WriteAllText("../../../Json/users-and-products.json", jsonCategories);
        }

        private static void ExportCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                                  .Select(p => new
                                  {
                                      name = p.Name,
                                      productsCount = p.CategoryProducts.Count,
                                      averagePrice = p.CategoryProducts
                                                     .Sum(pr => pr.Product.Price) / p.CategoryProducts.Count,
                                      totalRevenue = p.CategoryProducts
                                                     .Sum(pro => pro.Product.Price)
                                  })
                                  .OrderByDescending(p => p.productsCount)
                                  .ToList();

            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };

            var jsonCategories = JsonConvert.SerializeObject(categories, settings);

            File.WriteAllText("../../../Json/categories-by-products.json", jsonCategories);
        }

        private static void ExportSuccessfullySoldProducts(ProductShopContext context)
        {
            var users = context.Users
                        .Where(p => p.ProductsSold.Count >= 1 && p.ProductsSold
                                                                 .Any(b => b.Buyer != null))
                        .OrderBy(l => l.LastName)
                        .ThenBy(f => f.FirstName)
                        .Select(u => new
                        {
                            firstName = u.FirstName,
                            lastName = u.LastName,
                            soldProducts = u.ProductsSold
                                           .Where(b => b.Buyer != null)
                                           .Select(p => new
                                           {
                                               name = p.Name,
                                               price = p.Price,
                                               buyerFirstName = p.Buyer.FirstName,
                                               buyerLastName = p.Buyer.LastName
                                           })
                                           .ToList()
                        })
                        .ToList();

            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };

            var jsonUsers = JsonConvert.SerializeObject(users, settings);

            File.WriteAllText("../../../Json/users-sold-products.json", jsonUsers);
        }

        private static void ExportProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                           .Where(p => p.Price >= 500 && p.Price <= 1000)
                           .OrderBy(p => p.Price)
                           .Select(p => new
                           {
                               name = p.Name,
                               price = p.Price,
                               seller = p.Seller.FirstName + " " + p.Seller.LastName ?? p.Seller.LastName
                           })
                           .ToList();

            var jsonProducts = JsonConvert.SerializeObject(products, Formatting.Indented);

            File.WriteAllText("../../../Json/products-in-range.json", jsonProducts);
        }

        private static void ImportCategoryProducts(ProductShopContext context)
        {
            var categoryProducts = new List<CategoryProduct>();

            for (int productId = 1; productId <= 200; productId++)
            {
                var categoryId = new Random().Next(1, 12);

                var categoryProduct = new CategoryProduct
                {
                    CategoryId = categoryId,
                    ProductId = productId
                };

                categoryProducts.Add(categoryProduct);
            }

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();
        }

        private static void DeserializeCategories(ProductShopContext context)
        {
            var jsonString = File.ReadAllText("../../../Json/categories.json");

            var deserializedCategories = JsonConvert.DeserializeObject<Category[]>(jsonString);

            var categories = new List<Category>();

            foreach (var category in deserializedCategories)
            {
                if (IsValid(category))
                {
                    categories.Add(category);
                }
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();
        }

        private static void DeserializeProducts(ProductShopContext context)
        {
            var jsonString = File.ReadAllText("../../../Json/products.json");

            var deserializedProducts = JsonConvert.DeserializeObject<Product[]>(jsonString);

            var products = new List<Product>();

            foreach (var product in deserializedProducts)
            {
                if (!IsValid(product))
                {
                    continue;
                }

                var sellerId = new Random().Next(1, 35);
                var buyerId = new Random().Next(35, 57);

                var random = new Random().Next(1, 4);

                product.SellerId = sellerId;
                product.BuyerId = buyerId;

                if (random == 3)
                {
                    product.BuyerId = null;
                }

                products.Add(product);
            }

            context.Products.AddRange(products);
            context.SaveChanges();
        }

        private static void DeserializeUsers(ProductShopContext context)
        {
            var jsonString = File.ReadAllText("../../../Json/users.json");

            var deserializedUsers = JsonConvert.DeserializeObject<User[]>(jsonString);

            var users = new List<User>();

            foreach (var user in deserializedUsers)
            {
                if (IsValid(user))
                {
                    users.Add(user);
                }
            }

            context.Users.AddRange(users);
            context.SaveChanges();
        }

        public static bool IsValid(object obj)
        {
            var validationContext = new DataAnnotations.ValidationContext(obj);
            var validationResult = new List<DataAnnotations.ValidationResult>();

            return DataAnnotations.Validator.TryValidateObject(obj, validationContext, validationResult, true);
        }
    }
}
