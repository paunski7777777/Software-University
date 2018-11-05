namespace PandaWebApp.Controllers
{
    using PandaWebApp.Data;

    using SIS.MvcFramework;

    public abstract class BaseController : Controller
    {
        protected readonly PandaContext db;

        public BaseController()
        {
            this.db = new PandaContext();
        }
    }
}