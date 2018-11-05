namespace Torshia.Services
{
    using System.Linq;

    using Torshia.Data;
    using Torshia.Models;
    using Torshia.Services.Contracts;

    public class ReportService : IReportService
    {
        private readonly TorshiaContext db;
        private readonly ITaskService taskService;

        public ReportService(TorshiaContext db, ITaskService taskService)
        {
            this.db = db;
            this.taskService = taskService;
        }

        public IQueryable<Report> All() => this.db.Reports;

        public void CreateReport(Report report)
        {
            this.db.Reports.Add(report);

            var task = this.db.Tasks.Find(report.TaskId);
            task.IsReported = true;

            this.db.SaveChanges();
        }

        public Report GetById(int id) => this.db.Reports.FirstOrDefault(t => t.Id == id);
    }
}