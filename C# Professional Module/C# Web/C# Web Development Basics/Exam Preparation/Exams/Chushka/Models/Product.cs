namespace Chushka.Models
{
    using Chushka.Models.Enums;

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string Description { get; set; }
        public ProductType Type { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        public Product()
        {
            this.Orders = new HashSet<Order>();
        }
    }
}