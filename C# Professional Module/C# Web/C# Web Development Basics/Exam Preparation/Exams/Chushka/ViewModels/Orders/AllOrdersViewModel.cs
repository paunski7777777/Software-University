namespace Chushka.ViewModels.Orders
{
    using System.Collections.Generic;

    public class AllOrdersViewModel
    {
        public IEnumerable<OrderViewModel> OrderViewModels { get; set; }
    }
}