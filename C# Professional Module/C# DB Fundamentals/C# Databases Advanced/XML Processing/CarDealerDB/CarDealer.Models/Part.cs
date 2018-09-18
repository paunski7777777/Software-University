namespace CarDealer.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Part
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }
        
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        public ICollection<PartCar> Cars { get; set; } = new List<PartCar>();
    }
}