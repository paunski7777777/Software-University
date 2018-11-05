namespace MishMash.Controllers
{
    using MishMash.Data;

    using SIS.MvcFramework;

    public abstract class BaseController : Controller
    {
        protected readonly MishMashContext db;

        protected BaseController()
        {
            this.db = new MishMashContext();
        }
    }
}