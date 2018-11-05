namespace Chushka.ViewModels.Home
{
    using Chushka.ViewModels.Products;

    using System.Collections.Generic;

    public class IndexViewModel
    {
        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}