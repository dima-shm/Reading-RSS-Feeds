using System.Collections.Generic;

namespace WebApp.Models
{
    public class ArticlesViewModel
    {
        public string SelectedChannel { get; set; }

        public List<Channel> Channels { get; set; }
    }
}