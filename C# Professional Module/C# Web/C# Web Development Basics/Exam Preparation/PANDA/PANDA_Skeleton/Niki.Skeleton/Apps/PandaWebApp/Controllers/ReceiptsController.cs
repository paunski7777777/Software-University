namespace PandaWebApp.Controllers
{
    using PandaWebApp.ViewModels.Receipts;

    using SIS.HTTP.Responses;

    using SIS.MvcFramework;

    using System.Collections.Generic;
    using System.Linq;

    public class ReceiptsController : BaseController
    {
        [Authorize]
        public IHttpResponse Index()
        {
            var user = this.db.Users.FirstOrDefault(u => u.Username == this.User.Username);

            if (user == null)
            {
                return this.BadRequestError("Invalid user");
            }

            var receipts = this.db.Receipts
                                  .Where(u => u.Recipient.Username == user.Username)
                                  .ToList();

            var receiptViewModels = new List<ReceiptViewModel>();

            foreach (var receipt in receipts)
            {
                var fee = (decimal)receipt.Package.Weight * (decimal)2.67;

                var receiptViewModel = new ReceiptViewModel
                {
                    Id = receipt.Id,
                    IssuedOn = receipt.IssuedOn.ToShortDateString(),
                    Recipient = receipt.Recipient.Username,
                    Fee = fee
                };

                receiptViewModels.Add(receiptViewModel);
            }

            var recieptsViewModel = new ReceiptsViewModel
            {
                Receipts = receiptViewModels
            };

            return this.View(recieptsViewModel);
        }

        [Authorize]
        public IHttpResponse Details(int id)
        {
            var user = this.db.Users.FirstOrDefault(u => u.Username == this.User.Username);

            if (user == null)
            {
                return this.BadRequestError("Invalid user!");
            }

            var receipt = this.db.Receipts
                                  .Where(u => u.Recipient.Username == user.Username)
                                  .FirstOrDefault(r => r.Id == id);

            if (receipt == null)
            {
                return this.BadRequestError("Invalid receipt id!");
            }

            var total = (decimal)receipt.Package.Weight * (decimal)2.67;

            var receiptDetailsViewModel = new ReceiptDetailsViewModel
            {
                Id = receipt.Id,
                IssuedOn = receipt.IssuedOn.ToShortDateString(),
                DeliveryAddress = receipt.Package.ShippingAddress,
                PackageWeight = receipt.Package.Weight,
                PackageDescription = receipt.Package.Description,
                Recipient = receipt.Recipient.Username,
                Total = total
            };

            return this.View(receiptDetailsViewModel);
        }
    }
}