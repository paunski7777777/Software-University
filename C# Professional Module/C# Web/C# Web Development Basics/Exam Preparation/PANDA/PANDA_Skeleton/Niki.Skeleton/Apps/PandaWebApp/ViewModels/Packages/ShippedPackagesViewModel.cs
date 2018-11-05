namespace PandaWebApp.ViewModels.Packages
{
    using System.Collections.Generic;

    public class ShippedPackagesViewModel
    {
        public IEnumerable<PackageAdminViewModel> ShippedPackages { get; set; }
    }
}