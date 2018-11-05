namespace PandaWebApp.ViewModels.Packages
{
    using System.Collections.Generic;

    public class PendingPackagesViewModel
    {
        public IEnumerable<PackageAdminViewModel> PendingPackages { get; set; }
    }
}