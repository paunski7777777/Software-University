
namespace Chushka.Controllers
{
    using Chushka.Data;

    using SIS.MvcFramework;

    public abstract class BaseController : Controller
    {
        protected readonly ChushkaContext db;

        protected BaseController()
        {
            this.db = new ChushkaContext();
        }
    }
}