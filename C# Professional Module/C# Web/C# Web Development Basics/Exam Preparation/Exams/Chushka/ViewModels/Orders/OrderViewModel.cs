namespace Chushka.ViewModels.Orders
{
    using System;

    public class OrderViewModel
    {
        public int Id { get; set; }
        public string Customer { get; set; }
        public string Product { get; set; }
        public DateTime OrderedOn { get; set; }
    }
}