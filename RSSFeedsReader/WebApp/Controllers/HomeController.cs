using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PostPage()
        {
            return View();
        }

        public ActionResult AjaxPage()
        {
            return View();
        }
    }
}