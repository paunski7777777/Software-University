namespace Instagraph.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Caption { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        [ForeignKey("Picture")]
        public int PictureId { get; set; }
        public Picture Picture { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}