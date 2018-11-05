namespace Torshia.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Torshia.Models.Enums;

    public class Report
    {
        public int Id { get; set; }
        public Status Status { get; set; }

        [Required]
        public DateTime ReportedOn { get; set; }

        [ForeignKey(nameof(Task))]
        public int TaskId { get; set; }
        public Task Task { get; set; }

        [ForeignKey("Reporter")]
        public int ReporterId { get; set; }
        public User Reporter { get; set; }
    }
}