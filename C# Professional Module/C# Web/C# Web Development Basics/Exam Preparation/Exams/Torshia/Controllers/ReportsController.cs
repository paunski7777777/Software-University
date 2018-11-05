namespace Torshia.Controllers
{
    using SIS.HTTP.Responses;

    using SIS.MvcFramework;

    using System.Linq;

    using Torshia.Models.Enums;
    using Torshia.ViewModels.Reports;

    public class ReportsController : BaseController
    {
        [Authorize(nameof(Role.Admin))]
        public IHttpResponse All()
        {
            var reports = this.db.Reports.Select(r => new ReportViewModel
            {
                Id = r.Id,
                Task = r.Task.Title,
                Level = r.Task.AffectedSectors.Count,
                Status = r.Status.ToString()
            })
            .ToList();

            var reportsAllViewModel = new ReportsAllViewModel
            {
                Reports = reports
            };

            return this.View(reportsAllViewModel);
        }

        [Authorize(nameof(Role.Admin))]
        public IHttpResponse Details(int id)
        {
            var report = this.db.Reports.FirstOrDefault(r => r.Id == id);

            if (report == null)
            {
                return this.BadRequestError("Invalid report id!");
            }

            var reportDetailsViewModel = new ReportDetailsViewModel
            {
                Id = report.Id,
                Task = report.Task.Title,
                Level = report.Task.AffectedSectors.Count,
                Status = report.Status.ToString(),
                DueDate = report.Task.DueDate.ToShortDateString(),
                ReportedOn = report.ReportedOn.ToShortDateString(),
                Reporter = report.Reporter.Username,
                Participants = report.Task.Participants,
                AffectedSectors = string.Join(", ", report.Task.AffectedSectors.Select(s => s.Sector.ToString())),
                TaskDescription = report.Task.Description
            };

            return this.View(reportDetailsViewModel);
        }
    }
}