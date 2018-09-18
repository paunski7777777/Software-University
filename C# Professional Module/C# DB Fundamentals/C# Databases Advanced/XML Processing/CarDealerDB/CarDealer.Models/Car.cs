namespace CarDealer.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        public long TravelledDistance { get; set; }

        public ICollection<PartCar> Parts { get; set; } = new List<PartCar>();
        public ICollection<Sale> Sales { get; set; } = new List<Sale>();
    }
}