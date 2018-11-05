namespace PandaWebApp.Controllers
{
    using PandaWebApp.Models.Enums;
    using PandaWebApp.ViewModels.Packages;
    using SIS.HTTP.Responses;
    using System.Linq;

    public class HomeController : BaseController
    {
        public IHttpResponse Index()
        {
            var user = this.db.Users.FirstOrDefault(u => u.Username == this.User.Username);

            if (user != null)
            {
                var pendingPackages = this.db.Packages
                                             .Where(r => r.Recipient.Username == user.Username
                                                      && r.Status == Status.Pending)
                                             .Select(p => new PackageViewModel
                                             {
                                                 Id = p.Id,
                                                 Description = p.Description
                                             })
                                             .ToList();


                var shippedPackages = this.db.Packages
                                             .Where(r => r.Recipient.Username == user.Username
                                                      && r.Status == Status.Shipped)
                                             .Select(p => new PackageViewModel
                                             {
                                                 Id = p.Id,
                                                 Description = p.Description
                                             })
                                             .ToList();

                var deliveredPackages = this.db.Packages
                                               .Where(r => r.Recipient.Username == user.Username
                                                        && r.Status == Status.Delivered)
                                               .Select(p => new PackageViewModel
                                               {
                                                   Id = p.Id,
                                                   Description = p.Description
                                               })
                                               .ToList();

                var packagesViewModel = new PackagesViewModel
                {
                    PendingPackages = pendingPackages,
                    ShippedPackages = shippedPackages,
                    DeliveredPackages = deliveredPackages
                };

                return this.View("/Home/IndexLoggedIn", packagesViewModel);
            }

            return this.View();
        }
    }
}
