namespace TeamBuilder.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Team
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(25)]
        [Required]
        public string Name { get; set; }

        [MaxLength(32)]
        public string Description { get; set; }
        public string Acronym { get; set; }

        [ForeignKey("Creator")]
        public int CreatorId { get; set; }
        public User Creator { get; set; }
        
        public ICollection<UserTeam> Members { get; set; }
        public ICollection<EventTeam> Events { get; set; }

        public Team()
        {
            this.Members = new List<UserTeam>();
            this.Events = new List<EventTeam>();
        }
    }
}