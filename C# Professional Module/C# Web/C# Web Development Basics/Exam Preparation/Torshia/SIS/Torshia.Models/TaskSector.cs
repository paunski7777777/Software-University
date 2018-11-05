namespace Torshia.Models
{
    using Torshia.Models.Enums;

    public class TaskSector
    {
        public int TaskId { get; set; }
        public Task Task { get; set; }

        public int SectorId { get; set; }
        public Sector Sector { get; set; }
    }
}