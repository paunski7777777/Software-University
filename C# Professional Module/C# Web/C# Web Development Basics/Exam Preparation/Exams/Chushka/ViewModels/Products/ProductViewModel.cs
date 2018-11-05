namespace Chushka.ViewModels.Products
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public string FormatedDescription
            => this.Description?.Length > 50 ? this.Description.Substring(0, 50) + "..." : this.Description;
    }
}