namespace P03_SalesDatabase.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Customer
    {
        public int CustomerId { get; set; }

        [Column(TypeName = "NVARCHAR(100)")]
        public string Name { get; set; }

        [Column(TypeName = "VARCHAR(80)")]
        public string Email { get; set; }
        public string CreditCardNumber { get; set; }
        public ICollection<Sale> Sales { get; set; }
    }
}