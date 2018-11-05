namespace Torshia.App.Controllers
{
    using SIS.Framework.ActionResults;
    using SIS.Framework.Attributes.Action;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Torshia.App.Controllers.Base;
    using Torshia.App.ViewModels;
    using Torshia.Models;
    using Torshia.Models.Enums;
    using Torshia.Services.Contracts;

    public class ReportsController : BaseController
    {
        private readonly IReportService reportService;
        private readonly IUserService userService;

        public ReportsController(IReportService reportService, IUserService userService)
        {
            this.reportService = reportService;
            this.userService = userService;
        }

        [Authorize("Admin")]
        public IActionResult All()
        {
            var reports = this.reportService.All().ToList();

            var reportViewModels = new List<ReportViewModel>();

            foreach (var report in reports)
            {
                reportViewModels.Add(new ReportViewModel
                {
                    Task = report.Task.Title,
                    Id = report.Id,
                    Level = report.Task.AffectedSectors.Count,
                    Status = report.Status.ToString()
                });
            }

            this.Model.Data["Reports"] = reportViewModels;

            return this.View();
        }

        [Authorize("Admin")]
        public IActionResult Details(int id)
        {
            var report = this.reportService.GetById(id);

            var reportViewModel = new ReportDetailsViewModel
            {
                Id = report.Id,
                Task = report.Task.Title,
                Level = report.Task.AffectedSectors.Count,
                Status = report.Status.ToString(),
                DueDate = report.Task.DueDate?.ToShortDateString(),
                AffectedSectors = string.Join(", ", report.Task.AffectedSectors.Select(s => s.Sector)),
                Participants = report.Task.Participants,
                ReportedOn = report.ReportedOn.ToShortDateString(),
                Reporter = report.Reporter.Username,
                Description = report.Task.Description
            };

            this.Model.Data["ReportDetails"] = reportViewModel;

            return this.View();
        }

        [Authorize]
        public IActionResult Report(int taskId)
        {
            var user = this.userService.GetNyUsermame(this.Identity.Username);

            var randomStatus = new Random().Next(0, 100) > 25 ? Status.Completed : Status.Archived;

            var report = new Report
            {
                ReportedOn = DateTime.Now,
                Reporter = user,
                TaskId = taskId,
                Status = randomStatus
            };

            this.reportService.CreateReport(report);

            return this.RedirectToAction("/");
        }
    }
}