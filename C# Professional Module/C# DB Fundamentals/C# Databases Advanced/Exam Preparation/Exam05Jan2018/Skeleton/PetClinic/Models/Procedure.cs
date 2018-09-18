namespace PetClinic.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class Procedure
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Animal")]
        public int AnimalId { get; set; }

        public Animal Animal { get; set; }

        [Required]
        [ForeignKey("Vet")]
        public int VetId { get; set; }
        public Vet Vet { get; set; }

        public ICollection<ProcedureAnimalAid> ProcedureAnimalAids { get; set; } = new List<ProcedureAnimalAid>();

        [NotMapped]
        public decimal Cost => this.ProcedureAnimalAids.Sum(p => p.AnimalAid.Price);

        [Required]
        public DateTime DateTime { get; set; }
    }
}