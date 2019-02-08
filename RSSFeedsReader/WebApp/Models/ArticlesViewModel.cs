using System.Collections.Generic;

namespace WebApp.Models
{
    public class ArticlesViewModel
    {
        public string SelectedChannel { get; set; }

        public Channel Channel { get; set; }

        public List<Channel> Channels { get; set; }

        public List<Article> Articles { get; set; }
    }
}