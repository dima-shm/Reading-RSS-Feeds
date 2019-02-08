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
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult PostPage(ArticlesViewModel model, [System.Web.Http.FromBody]string selectedChannel, [System.Web.Http.FromBody]int sortBy)
        {
            Channel channel;
            if (selectedChannel != "All")
            {
                channel = context.Channels.First(c => c.Description == selectedChannel);
                model.Articles = context.Articles.Where(a => a.ChannelId == channel.Link).ToList();
            }
            else
            {
                model.Articles = context.Articles.ToList();
            }
            if (sortBy == 1)
                model.Articles = model.Articles.OrderByDescending(a => a.PubDate).ToList();
            else if (sortBy == 2)
                model.Articles = model.Articles.OrderByDescending(a => a.ChannelId).ToList();
            model.Channels = context.Channels.ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult AjaxPage()
        {
            return View();
        }   
    }
}