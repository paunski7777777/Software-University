namespace Torshia.Controllers
{
    using SIS.HTTP.Responses;

    using SIS.MvcFramework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Torshia.Models;
    using Torshia.Models.Enums;

    using Torshia.ViewModels.Tasks;

    public class TasksController : BaseController
    {
        [Authorize]
        public IHttpResponse Details(int id)
        {
            var task = this.db.Tasks.FirstOrDefault(t => t.Id == id);

            if (task == null)
            {
                return this.BadRequestError("Invalid task id!");
            }

            var taskDetailsViewModel = new TaskDetailsViewModel
            {
                Title = task.Title,
                Level = task.AffectedSectors.Count,
                DueDate = task.DueDate.ToShortDateString(),
                Participants = task.Participants,
                AffectedSectors = string.Join(", ", task.AffectedSectors.Select(s => s.Sector.ToString())),
                Description = task.Description
            };

            return this.View(taskDetailsViewModel);
        }

        [Authorize(nameof(Role.Admin))]
        public IHttpResponse Create() => this.View();

        [Authorize(nameof(Role.Admin))]
        [HttpPost]
        public IHttpResponse Create(TaskCreateViewModel model)
        {
            var affectedSectors = new List<TaskSector>();

            var sectors = new List<string>()
            {
                model.AffectedSectorsCustomers?.ToString(),
                model.AffectedSectorsFinances?.ToString(),
                model.AffectedSectorsInternal?.ToString(),
                model.AffectedSectorsManagement?.ToString(),
                model.AffectedSectorsMarketing?.ToString()
            };

            foreach (var sector in sectors)
            {
                if (sector == null)
                {
                    continue;
                }

                if (!Enum.TryParse(sector, out Sector sectorValue))
                {
                    return this.BadRequestError("Invalid sector!");
                }

                affectedSectors.Add(new TaskSector
                {
                    Sector = sectorValue,
                    SectorId = (int)sectorValue
                });
            }

            var task = new Task
            {
                Title = model.Title,
                DueDate = DateTime.Parse(model.DueDate),
                Participants = model.Participants,
                Description = model.Description,
                AffectedSectors = affectedSectors
            };

            this.db.Tasks.Add(task);
            this.db.SaveChanges();

            return this.Redirect($"/Tasks/Details?id={task.Id}");
        }

        [Authorize]
        public IHttpResponse Report(int id)
        {
            var user = this.db.Users.FirstOrDefault(u => u.Username == this.User.Username);

            if (user == null)
            {
                return this.BadRequestError("Invalid user!");
            }

            var task = this.db.Tasks.FirstOrDefault(t => t.Id == id);

            if (task == null)
            {
                return this.BadRequestError("Indaliv task!");
            }

            var randomStatus = new Random().Next(0, 100) > 25 ? Status.Completed : Status.Archived;

            var report = new Report
            {
                ReporterId = user.Id,
                TaskId = id,
                Status = randomStatus,
            };

            task.IsReported = true;

            this.db.Reports.Add(report);
            this.db.SaveChanges();

            return this.Redirect("/");
        }
    }
}