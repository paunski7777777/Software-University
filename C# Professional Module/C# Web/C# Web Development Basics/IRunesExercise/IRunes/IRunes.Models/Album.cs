namespace IRunes.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Album : BaseModel<string>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Cover { get; set; }

        public decimal? Price => this.Tracks.Sum(t => t.Track.Price) * 0.87m;

        public virtual ICollection<TrackAlbum> Tracks { get; set; } = new List<TrackAlbum>();
    }
}