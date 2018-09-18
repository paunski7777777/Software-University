namespace CarDealer.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string BirthDate { get; set; }

        [DefaultValue(false)]
        public bool IsYoungDriver { get; set; }

        public ICollection<Sale> Sales { get; set; } = new List<Sale>();
    }
}