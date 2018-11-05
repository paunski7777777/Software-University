namespace Torshia.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Task
    {
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; }

        public DateTime? DueDate { get; set; }
        public bool IsReported { get; set; }
        public string Description { get; set; }
        public string Participants { get; set; }
        
        public ICollection<TaskSector> AffectedSectors { get; set; }

        public Task()
        {
            this.IsReported = false;
            this.AffectedSectors = new HashSet<TaskSector>();
        }
    }
}