namespace Torshia.App.Controllers
{
    using SIS.Framework.ActionResults;

    using System.Collections.Generic;
    using System.Linq;

    using Torshia.App.Controllers.Base;
    using Torshia.App.ViewModels;
    using Torshia.Services.Contracts;

    public class HomeController : BaseController
    {
        private readonly ITaskService taskService;

        public HomeController(ITaskService taskService)
        {
            this.taskService = taskService;
        }

        public IActionResult Index()
        {
            var userLoggedIn = this.Identity != null;
            if (!userLoggedIn)
            {
                return this.View();
            }

            var tasks = this.taskService.All().ToList();

            var taskViewModels = new List<TaskViewModel>();

            var wrapperViewModels = new List<TaskViewModelWrapper>
            {
                new TaskViewModelWrapper()
            };

            for (int i = 0; i < tasks.Count(); i++)
            {
                if (i != 0 && i % 5 == 0)
                {
                    wrapperViewModels.Add(new TaskViewModelWrapper());
                }

                var lastAddedWrapper = wrapperViewModels.Last();
                lastAddedWrapper.TaskViewModels.Add(new TaskViewModel
                {
                    Id = tasks[i].Id,
                    EmptyTask = "block",
                    BackgroundColor = "torshia",
                    Level = tasks[i].AffectedSectors.Count,
                    Title = tasks[i].Title
                });
            }

            var lastWrapper = wrapperViewModels.Last();
            var emptyViewModelCount = 5 - lastWrapper.TaskViewModels.Count;

            for (int i = 0; i < emptyViewModelCount; i++)
            {
                var lastAddedWrapper = wrapperViewModels.Last();
                lastAddedWrapper.TaskViewModels.Add(new TaskViewModel
                {
                    EmptyTask = "none",
                    BackgroundColor = "white"
                });
            }

            this.Model.Data["TaskViewModels"] = wrapperViewModels;

            return this.View();
        }
    }
}