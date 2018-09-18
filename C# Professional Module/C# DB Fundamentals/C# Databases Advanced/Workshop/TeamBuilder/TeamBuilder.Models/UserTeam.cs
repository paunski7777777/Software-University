using System.ComponentModel.DataAnnotations.Schema;

namespace TeamBuilder.Models
{
    public class UserTeam
    {
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Team")]
        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}