namespace MishMash.Models
{
    using MishMash.Models.Enums;

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        public Role Role { get; set; }

        public virtual ICollection<UserChannel> FollowedChannels { get; set; }

        public User()
        {
            this.FollowedChannels = new HashSet<UserChannel>();
        }
    }
}