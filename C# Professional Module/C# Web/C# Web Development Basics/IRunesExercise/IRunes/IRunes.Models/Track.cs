namespace IRunes.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Track : BaseModel<string>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Link { get; set; }

        [Required]
        public decimal Price { get; set; }

        public virtual ICollection<TrackAlbum> Tracks { get; set; } = new List<TrackAlbum>();
    }
}