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
            List<Article> articles;
            articles = getArticlesFromChannel(context.Articles.ToList(), selectedChannel);
            articles = getArticlesWithSort(articles, selectedSort);
            return Ok(articles);
        }

        private List<Article> getArticlesFromChannel(List<Article> articles, string channelName)
        {
            List<Article> articlesInChannel = articles;
            Channel channel;
            if (channelName != "All")
            {
                channel = context.Channels.First(c => c.Description == channelName);
                articlesInChannel = context.Articles.Where(a => a.ChannelId == channel.Link).ToList();
            }
            else
            {
                articlesInChannel = context.Articles.ToList();
            }
            return articlesInChannel;
        }

        private List<Article> getArticlesWithSort(List<Article> articles, int sortMode)
        {
            List<Article> sortedArticles = articles;
            if (sortMode == 1)
                sortedArticles = articles.OrderByDescending(a => a.PubDate).ToList();
            else if (sortMode == 2)
                sortedArticles = articles.OrderByDescending(a => a.ChannelId).ToList();
            return sortedArticles;
        }
    }
}