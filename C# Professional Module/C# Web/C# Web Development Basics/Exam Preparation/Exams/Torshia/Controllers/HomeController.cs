namespace Torshia.Controllers
{
    using SIS.HTTP.Responses;

    using System.Linq;

    using Torshia.ViewModels.Home;
    using Torshia.ViewModels.Tasks;

    public class HomeController : BaseController
    {
        public IHttpResponse Index()
        {
            if (this.User.IsLoggedIn)
            {
                var user = this.db.Users.FirstOrDefault(u => u.Username == this.User.Username);

                if (user != null)
                {
                    var tasks = this.db.Tasks.Where(t => t.IsReported == false)
                                        .Select(vm => new TaskViewModel
                                        {
                                            Id = vm.Id,
                                            Title = vm.Title,
                                            Level = vm.AffectedSectors.Count
                                        });

                    var indexViewModel = new IndexViewModel
                    {
                        Tasks = tasks
                    };

                    return this.View("/Home/IndexLoggedIn", indexViewModel);
                }
            }

            return this.View();
        }
    }
}