namespace P03_SalesDatabase.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Sale
    {
        public int SaleId { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [ForeignKey("Store")]
        public int StoreId { get; set; }
        public Store Store { get; set; }
    }
}