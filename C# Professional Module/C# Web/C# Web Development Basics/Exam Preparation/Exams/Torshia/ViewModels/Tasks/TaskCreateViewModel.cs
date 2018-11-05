namespace Torshia.ViewModels.Tasks
{
    public class TaskCreateViewModel
    {
        public string Title { get; set; }
        public string DueDate { get; set; }
        public string Description { get; set; }
        public string Participants { get; set; }
        public string AffectedSectorsCustomers { get; set; }
        public string AffectedSectorsMarketing { get; set; }
        public string AffectedSectorsFinances { get; set; }
        public string AffectedSectorsInternal { get; set; }
        public string AffectedSectorsManagement { get; set; }
    }
}