using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApp.Context;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ArticlesController : ApiController
    {
        private ApplicationContext context = new ApplicationContext();

        public IHttpActionResult Get([FromUri]string selectedChannel, [FromUri]int selectedSort)
        {
            Channel channel;
            List<Article> articlesInChannel;
            if (selectedChannel != "Все")
            {
                channel = context.Channels.First(c => c.Description == selectedChannel);
                articlesInChannel = context.Articles.Where(a => a.ChannelId == channel.Link).ToList();
            }
            else
            {
                articlesInChannel = context.Articles.ToList();
            }
            if (selectedSort == 1)
                articlesInChannel = articlesInChannel.OrderByDescending(a => a.PubDate).ToList();
            else if (selectedSort == 2)
                articlesInChannel = articlesInChannel.OrderByDescending(a => a.ChannelId).ToList();
            return Ok(articlesInChannel);
        }
    }
}