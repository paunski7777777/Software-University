namespace Torshia.Models
{
    using Torshia.Models.Enums;

    public class TaskSector
    {
        public int TaskId { get; set; }
        public virtual Task Task { get; set; }

        public int SectorId { get; set; }
        public virtual Sector Sector { get; set; }
    }
}