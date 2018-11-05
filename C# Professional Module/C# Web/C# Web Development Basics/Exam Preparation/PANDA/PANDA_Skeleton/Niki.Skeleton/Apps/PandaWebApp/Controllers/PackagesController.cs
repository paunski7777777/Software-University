namespace PandaWebApp.Controllers
{
    using PandaWebApp.Models;
    using PandaWebApp.Models.Enums;
    using PandaWebApp.ViewModels.Packages;

    using SIS.HTTP.Responses;

    using SIS.MvcFramework;

    using System;
    using System.Linq;

    public class PackagesController : BaseController
    {
        [Authorize]
        public IHttpResponse Details(int id)
        {
            var package = this.db.Packages
                              .Where(u => u.Recipient.Username == this.User.Username || this.User.Role == "Admin")
                              .FirstOrDefault(p => p.Id == id);

            if (package == null)
            {
                return this.BadRequestError("Invalid package id!");
            }

            var packageDetailsViewModel = new PackageDetailsViewModel
            {
                Address = package.ShippingAddress,
                EstimatedDeliveryDate = package.EstimatedDeliveryDate?.ToShortDateString(),
                Status = package.Status.ToString(),
                Weight = package.Weight,
                Recipient = package.Recipient.Username,
                Description = package.Description
            };

            return this.View(packageDetailsViewModel);
        }

        [Authorize(nameof(Role.Admin))]
        public IHttpResponse Create()
        {
            var recipients = this.db.Users.Select(u => new RecipientViewModel
            {
                Username = u.Username
            })
            .ToList();

            var recipientsViewModel = new RecipientsViewModel
            {
                Recipients = recipients
            };

            return this.View("Packages/Create", recipientsViewModel);
        }

        [Authorize(nameof(Role.Admin))]
        [HttpPost]
        public IHttpResponse Create(PackageCreateViewModel model)
        {
            var user = this.db.Users.FirstOrDefault(u => u.Username == model.Recipient);

            if (user == null)
            {
                return this.BadRequestError("Invalid username");
            }

            var package = new Package
            {
                Id = model.Id,
                Description = model.Description,
                Weight = model.Weight,
                ShippingAddress = model.ShippingAddress,
                Recipient = user,
                EstimatedDeliveryDate = null
            };

            this.db.Packages.Add(package);
            this.db.SaveChanges();

            return this.Redirect($"/Packages/Details?id={package.Id}");
        }

        [Authorize(nameof(Role.Admin))]
        public IHttpResponse Pending()
        {
            var pendingPackages = this.db.Packages
                                         .Where(s => s.Status == Status.Pending)
                                         .Select(vm => new PackageAdminViewModel
                                         {
                                             Id = vm.Id,
                                             Description = vm.Description,
                                             Weight = vm.Weight,
                                             ShippingAddress = vm.ShippingAddress,
                                             Recipient = vm.Recipient.Username
                                         })
                                         .ToList();

            var pendingPackagesViewModel = new PendingPackagesViewModel
            {
                PendingPackages = pendingPackages
            };

            return this.View(pendingPackagesViewModel);
        }

        [Authorize(nameof(Role.Admin))]
        public IHttpResponse Shipped()
        {
            var shippedPackages = this.db.Packages
                                         .Where(s => s.Status == Status.Shipped)
                                         .Select(vm => new PackageAdminViewModel
                                         {
                                             Id = vm.Id,
                                             Description = vm.Description,
                                             Weight = vm.Weight,
                                             ShippingAddress = vm.ShippingAddress,
                                             Recipient = vm.Recipient.Username
                                         })
                                         .ToList();

            var pendingPackagesViewModel = new ShippedPackagesViewModel
            {
                ShippedPackages = shippedPackages
            };

            return this.View(pendingPackagesViewModel);
        }


        [Authorize(nameof(Role.Admin))]
        public IHttpResponse Delivered()
        {
            var deliveredPackages = this.db.Packages
                                         .Where(s => s.Status == Status.Delivered || s.Status == Status.Acquired)
                                         .Select(vm => new PackageAdminViewModel
                                         {
                                             Id = vm.Id,
                                             Description = vm.Description,
                                             Weight = vm.Weight,
                                             ShippingAddress = vm.ShippingAddress,
                                             Recipient = vm.Recipient.Username
                                         })
                                         .ToList();

            var deliveredPackagesViewModel = new DeliveredPackagesViewModel
            {
                DeliveredPackages = deliveredPackages
            };

            return this.View(deliveredPackagesViewModel);
        }

        [Authorize(nameof(Role.Admin))]
        public IHttpResponse Ship(int id)
        {
            var package = this.db.Packages.FirstOrDefault(p => p.Id == id);

            if (package == null)
            {
                return this.BadRequestError("Invalid package id!");
            }

            package.Status = Status.Shipped;
            package.EstimatedDeliveryDate = DateTime.UtcNow.AddDays(new Random().Next(20, 40));

            this.db.SaveChanges();

            return this.Redirect("/Packages/Shipped");
        }

        [Authorize(nameof(Role.Admin))]
        public IHttpResponse Deliver(int id)
        {
            var package = this.db.Packages.FirstOrDefault(p => p.Id == id);

            if (package == null)
            {
                return this.BadRequestError("Invalid package id!");
            }

            package.Status = Status.Delivered;

            this.db.SaveChanges();

            return this.Redirect("/Packages/Delivered");
        }

        [Authorize]
        public IHttpResponse Acquire(int id)
        {
            var package = this.db.Packages.FirstOrDefault(p => p.Id == id);

            if (package == null)
            {
                return this.BadRequestError("Invalid package id!");
            }

            package.Status = Status.Acquired;

            var fee = (decimal)package.Weight * (decimal)2.67;

            var receipt = new Receipt
            {
                Package = package,
                PackageId = package.Id,
                Recipient = package.Recipient,
                Fee = fee
            };

            this.db.Receipts.Add(receipt);
            //this.db.Packages.Remove(package);
            this.db.SaveChanges();

            return this.Redirect($"/Receipts/Details?id={receipt.Id}");
        }

    }
}