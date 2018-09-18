namespace P03_SalesDatabase.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Product
    {
        public int ProductId { get; set; }

        [Column(TypeName = "NVARCHAR(50)")]
        public string Name { get; set; }
        public double Quantity { get; set; }
        public decimal Price { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }
        public ICollection<Sale> Sales { get; set; } = new List<Sale>();
    }
}