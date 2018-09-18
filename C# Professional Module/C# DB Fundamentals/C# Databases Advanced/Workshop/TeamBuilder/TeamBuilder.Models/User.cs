namespace TeamBuilder.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        [Key]
        public int Id { get; set; }

        [MinLength(3)]
        [MaxLength(25)]
        [Required]
        public string Username { get; set; }

        [MinLength(6)]
        [MaxLength(30)]
        [Required]
        public string Password { get; set; }

        [MaxLength(25)]
        public string FirstName { get; set; }

        [MaxLength(25)]
        public string LastName { get; set; }

        public int Age { get; set; }
        public Gender Gender { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<Event> CreatedEvents { get; set; }
        public ICollection<UserTeam> UserTeams { get; set; }
        public ICollection<UserTeam> CreatedUserTeams { get; set; }
        public ICollection<Invitation> ReceivedInvitations { get; set; }

        public User()
        {
            this.CreatedEvents = new List<Event>();
            this.UserTeams = new List<UserTeam>();
            this.CreatedUserTeams = new List<UserTeam>();
            this.ReceivedInvitations = new List<Invitation>();
        }
    }
}