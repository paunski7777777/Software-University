namespace PandaWebApp.ViewModels.Packages
{
    using System.Collections.Generic;

    public class DeliveredPackagesViewModel
    {
        public IEnumerable<PackageAdminViewModel> DeliveredPackages { get; set; }
    }
}