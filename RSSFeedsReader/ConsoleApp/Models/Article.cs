using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp.Models
{
    class Article
    {
        [Key, Column(Order = 1)]
        public string Title { get; set; }

        public string Link { get; set; }

        public string Description { get; set; }

        [Key, Column(Order = 2)]
        public string PubDate { get; set; }

        public string ChannelId { get; set; }
        [ForeignKey("ChannelId")]
        private Channel Channel { get; set; }

        public Article() { }

        public Article(string title, string link, string description, string pubDate, string channelId)
        {
            Title = title;
            Link = link;
            Description = description;
            PubDate = pubDate;
            ChannelId = channelId;
        }      
    }
}