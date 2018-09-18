namespace TeamBuilder.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class EventTeam
    {
        [ForeignKey("Event")]
        public int EventId { get; set; }
        public Event Event { get; set; }

        [ForeignKey("Team")]
        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}