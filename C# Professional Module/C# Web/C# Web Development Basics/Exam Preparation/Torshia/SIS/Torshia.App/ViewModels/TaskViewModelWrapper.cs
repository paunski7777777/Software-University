namespace Torshia.App.ViewModels
{
    using System.Collections.Generic;

    public class TaskViewModelWrapper
    {
        public TaskViewModelWrapper()
        {
            this.TaskViewModels = new List<TaskViewModel>();
        }

        public ICollection<TaskViewModel> TaskViewModels { get; set; }
    }
}