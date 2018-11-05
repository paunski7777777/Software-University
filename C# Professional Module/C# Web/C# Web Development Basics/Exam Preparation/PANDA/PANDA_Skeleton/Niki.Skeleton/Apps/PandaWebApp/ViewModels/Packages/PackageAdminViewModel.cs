namespace PandaWebApp.ViewModels.Packages
{
    public class PackageAdminViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Weight { get; set; }
        public string ShippingAddress { get; set; }
        public string Recipient { get; set; }
    }
}