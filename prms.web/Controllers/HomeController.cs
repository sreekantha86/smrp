using System.Web.Mvc;

namespace prms.web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AnotherLink()
        {
            return View("Index");
        }
        public ActionResult Controls()
        {
            return View();
        }
    }
}
