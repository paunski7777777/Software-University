namespace Torshia.ViewModels.Home
{
    using System.Collections.Generic;

    using Torshia.ViewModels.Tasks;

    public class IndexViewModel
    {
        public IEnumerable<TaskViewModel> Tasks { get; set; }
    }
}
