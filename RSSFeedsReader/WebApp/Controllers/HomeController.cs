using System.Linq;
using System.Web.Mvc;
using WebApp.Context;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext context = new ApplicationContext();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult PostPage()
        {
            //ViewBag.Channels = new SelectList(context.Channels.ToList(), "Description", "Description");
            ArticlesViewModel model = new ArticlesViewModel
            {
                Channels = context.Channels.ToList()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult PostPage(ArticlesViewModel model)
        {
            ViewBag.Channels = new SelectList(context.Channels);
            return View();
        }

        [HttpGet]
        public ActionResult AjaxPage()
        {
            return View();
        }

        
    }
}