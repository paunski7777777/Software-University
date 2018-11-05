namespace PandaWebApp.Models
{
    using PandaWebApp.Models.Enums;

    using System;

    public class Package
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Weight { get; set; }
        public string ShippingAddress { get; set; }
        public Status Status { get; set; }
        public DateTime? EstimatedDeliveryDate { get; set; }

        public int RecipientId { get; set; }
        public virtual User Recipient { get; set; }

        public Package()
        {
            this.Status = Status.Pending;
        }
    }
}