namespace Torshia.App.Controllers
{
    using SIS.Framework.ActionResults;
    using SIS.Framework.Attributes.Action;
    using SIS.Framework.Attributes.Method;

    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    using Torshia.App.Controllers.Base;
    using Torshia.App.ViewModels;
    using Torshia.Models;
    using Torshia.Models.Enums;
    using Torshia.Services.Contracts;

    public class TasksController : BaseController
    {
        private readonly ITaskService taskService;

        public TasksController(ITaskService taskService)
        {
            this.taskService = taskService;
        }

        [Authorize]
        public IActionResult Details(int id)
        {
            var task = this.taskService.GetById(id);

            var taskDetailsViewModel = new TaskDetailsViewModel
            {
                Title = task.Title,
                DueDate = task.DueDate?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                AffectedSectors = string.Join(", ", task.AffectedSectors.Select(s => s.Sector.ToString())),
                Level = task.AffectedSectors.Count,
                Participants = task.Participants,
                Description = task.Description
            };

            this.Model.Data["TaskDetails"] = taskDetailsViewModel;

            return this.View();
        }

        [Authorize("Admin")]
        public IActionResult Create() => this.View();

        [HttpPost]
        [Authorize("Admin")]
        public IActionResult Create(TaskCreateViewModel model)
        {
            var affectedSectors = new List<TaskSector>();
            var sectors = model.AffectedSectors.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var sector in sectors)
            {
                var sectorValue = (Sector)Enum.Parse(typeof(Sector), sector);
                affectedSectors.Add(new TaskSector
                {
                    Sector = sectorValue
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

            this.taskService.CreateTask(task);

            return this.RedirectToAction("/Home/Index");
        }
    }
}