namespace Chushka.Models
{
    using System;
    using System.Collections.Generic;

    public class Order
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int ClientId { get; set; }
        public virtual User Client { get; set; }

        public DateTime OrderedOn { get; set; }

        public Order()
        {
            this.OrderedOn = DateTime.UtcNow;
        }
    }
}