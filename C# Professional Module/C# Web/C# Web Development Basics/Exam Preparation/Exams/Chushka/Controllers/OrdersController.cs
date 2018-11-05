namespace Chushka.Controllers
{
    using Chushka.Models.Enums;
    using Chushka.ViewModels.Orders;

    using SIS.HTTP.Responses;

    using SIS.MvcFramework;

    using System.Linq;

    public class OrdersController : BaseController
    {
        [Authorize(nameof(Role.Admin))]
        public IHttpResponse All()
        {
            var orders = this.db.Orders
                                .Select(vm => new OrderViewModel
                                {
                                    Id = vm.Id,
                                    Customer = vm.Client.Username,
                                    Product = vm.Product.Name,
                                    OrderedOn = vm.OrderedOn
                                })
                                .ToList();

            var allOrdersViewModel = new AllOrdersViewModel
            {
                OrderViewModels = orders
            };

            return this.View(allOrdersViewModel);
        }
    }
}