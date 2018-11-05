namespace Torshia.Controllers
{
    using SIS.MvcFramework;

    using Torshia.Data;
    public abstract class BaseController : Controller
    {
        protected readonly TorshiaContext db;

        protected BaseController()
        {
            this.db = new TorshiaContext();
        }
    }
}