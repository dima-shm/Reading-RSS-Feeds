using System.Collections.Generic;

namespace WebApp.Models
{
    public class ArticlesViewModel
    {
        public List<Channel> Channels { get; set; }

        public List<Article> Articles { get; set; }
    }
}