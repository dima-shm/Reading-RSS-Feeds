using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:54733/api/Articles/?selectedChannel=" + selectedChannel + "&selectedSort=" + sortBy);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            List<Article> articles = JsonConvert.DeserializeObject<Article[]>(responseString).ToList();
            model.Channels = context.Channels.ToList();
            model.Articles = articles;
            return View(model);
        }

        [HttpGet]
        public ActionResult AjaxPage()
        {
            return View();
        }   
    }
}