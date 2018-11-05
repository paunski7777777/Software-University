namespace Chushka.Controllers
{
    using Chushka.ViewModels.Home;
    using Chushka.ViewModels.Products;

    using SIS.HTTP.Responses;

    using System.Linq;

    public class HomeController : BaseController
    {
        public IHttpResponse Index()
        {
            if (this.User.IsLoggedIn)
            {
                var products = this.db.Products
                                      .Select(p => new ProductViewModel
                                      {
                                          Id = p.Id,
                                          Name = p.Name,
                                          Description = p.Description,
                                          Price = p.Price
                                      })
                                      .ToList();

                var indexViewModel = new IndexViewModel
                {
                    Products = products
                };

                return this.View("/Home/IndexLoggedIn", indexViewModel);
            }

            return this.View();
        }
    }
}