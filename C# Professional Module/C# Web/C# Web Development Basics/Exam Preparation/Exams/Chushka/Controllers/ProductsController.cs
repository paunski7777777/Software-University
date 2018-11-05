namespace Chushka.Controllers
{
    using Chushka.Models;
    using Chushka.Models.Enums;
    using Chushka.ViewModels.Products;

    using SIS.HTTP.Responses;

    using SIS.MvcFramework;

    using System;
    using System.Linq;

    public class ProductsController : BaseController
    {
        [Authorize]
        public IHttpResponse Details(int id)
        {
            var product = this.db.Products
                                 .Select(p => new ProductDetailsViewModel
                                 {
                                     Id = p.Id,
                                     Name = p.Name,
                                     Description = p.Description,
                                     Price = p.Price,
                                     Type = p.Type
                                 })
                                 .FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return this.BadRequestError("Invalid product id.");
            }

            return this.View(product);
        }

        [Authorize]
        public IHttpResponse Order(int id)
        {
            var user = this.db.Users.FirstOrDefault(u => u.Username == this.User.Username);

            if (user == null)
            {
                return this.BadRequestError("Invalid user!");
            }

            var order = new Order
            {
                ProductId = id,
                ClientId = user.Id
            };

            this.db.Orders.Add(order);
            this.db.SaveChanges();

            return this.Redirect("/");
        }

        [Authorize(nameof(Role.Admin))]
        public IHttpResponse Create() => this.View();

        [Authorize(nameof(Role.Admin))]
        [HttpPost]
        public IHttpResponse Create(ProductCreateViewModel model)
        {
            if (!Enum.TryParse(model.Type, out ProductType productType))
            {
                return this.BadRequestErrorWithView("Invalid product type!");
            }

            var product = new Product
            {
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                Type = productType
            };

            this.db.Products.Add(product);
            this.db.SaveChanges();

            return this.Redirect($"/Products/Details?id={product.Id}");
        }

        [Authorize(nameof(Role.Admin))]
        public IHttpResponse Edit(int id)
        {
            var product = this.db.Products
                              .Select(p => new ProductEditOrDeleteViewModel
                              {
                                  Id = p.Id,
                                  Name = p.Name,
                                  Price = p.Price,
                                  Description = p.Description,
                                  Type = p.Type.ToString()
                              })
                              .FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return this.BadRequestError("Invalid product id.");
            }

            return this.View(product);
        }

        [Authorize(nameof(Role.Admin))]
        [HttpPost]
        public IHttpResponse Edit(ProductEditOrDeleteViewModel model)
        {
            var product = this.db.Products.FirstOrDefault(p => p.Id == model.Id);

            if (product == null)
            {
                return this.BadRequestError("Product not found!");
            }

            if (!Enum.TryParse(model.Type, out ProductType productType))
            {
                return this.BadRequestError("Invalid product type");
            }

            product.Name = model.Name;
            product.Price = model.Price;
            product.Description = model.Description;
            product.Type = productType;

            this.db.SaveChanges();

            return this.Redirect($"/Products/Details?id={product.Id}");
        }

        [Authorize(nameof(Role.Admin))]
        public IHttpResponse Delete(int id)
        {
            var product = this.db.Products
                           .Select(p => new ProductEditOrDeleteViewModel
                           {
                               Id = p.Id,
                               Name = p.Name,
                               Price = p.Price,
                               Description = p.Description,
                               Type = p.Type.ToString()
                           })
                           .FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return this.BadRequestError("Invalid product id.");
            }

            return this.View(product);

        }

        [Authorize(nameof(Role.Admin))]
        [HttpPost]
        public IHttpResponse Delete(int id, string name)
        {
            var product = this.db.Products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return this.Redirect("/");
            }

            this.db.Products.Remove(product);
            this.db.SaveChanges();

            return this.Redirect("/");
        }
    }
}