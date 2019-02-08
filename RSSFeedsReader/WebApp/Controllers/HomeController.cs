using System.Collections.Generic;
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
            ArticlesViewModel model = new ArticlesViewModel
            {
                Channels = context.Channels.ToList(),
                Articles = context.Articles.ToList()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult PostPage(ArticlesViewModel model, [System.Web.Http.FromBody]int selectedSort)
        {
            Channel channel;
            if (model.SelectedChannel != "Все")
            {
                channel = context.Channels.First(c => c.Description == model.SelectedChannel);
                model.Articles = context.Articles.Where(a => a.ChannelId == channel.Link).ToList();
            }
            else
            {
                model.Articles = context.Articles.ToList();
            }
            if (selectedSort == 1)
                model.Articles = model.Articles.OrderByDescending(a => a.PubDate).ToList();
            else if (selectedSort == 2)
                model.Articles = model.Articles.OrderByDescending(a => a.ChannelId).ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult AjaxPage()
        {
            return View();
        }   
    }
}