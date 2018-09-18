namespace TeamBuilder.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Invitation
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("InvitedUser")]
        public int InvitedUserId { get; set; }
        public User InvitedUser { get; set; }

        [ForeignKey("Team")]
        public int TeamId { get; set; }
        public Team Team { get; set; }

        public bool IsActive { get; set; }

        public Invitation()
        {
            this.IsActive = true;
        }
    }
}