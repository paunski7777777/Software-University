namespace PandaWebApp.ViewModels.Packages
{
    using System.Collections.Generic;

    public class PackagesViewModel
    {
        public IEnumerable<PackageViewModel> PendingPackages { get; set; }
        public IEnumerable<PackageViewModel> ShippedPackages { get; set; }
        public IEnumerable<PackageViewModel> DeliveredPackages { get; set; }
    }
}