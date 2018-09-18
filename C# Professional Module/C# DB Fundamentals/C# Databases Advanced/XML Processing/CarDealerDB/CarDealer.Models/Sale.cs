using System.ComponentModel.DataAnnotations;

namespace CarDealer.Models
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Discount { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}