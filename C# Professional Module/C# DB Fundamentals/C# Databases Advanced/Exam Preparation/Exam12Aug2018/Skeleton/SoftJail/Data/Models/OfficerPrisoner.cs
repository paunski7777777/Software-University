namespace SoftJail.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class OfficerPrisoner
    {
        public int PrisonerId { get; set; }
        [Required]
        public Prisoner Prisoner { get; set; }

        public int OfficerId { get; set; }
        [Required]
        public Officer Officer { get; set; }
    }
}