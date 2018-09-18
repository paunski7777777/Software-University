namespace Instagraph.DataProcessor.Dtos.Import
{
    using System.ComponentModel.DataAnnotations;

    public class PictureDto
    {
        [Required]
        public string Path { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public decimal Size { get; set; }
    }
}