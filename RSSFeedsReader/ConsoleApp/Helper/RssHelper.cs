using ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Xml;

namespace ConsoleApp.Helper
{
    class RssHelper
    {
        private XmlDocument document = new XmlDocument();

        public Channel Channel { get; private set; } = new Channel();

        public List<Article> Articles { get; private set; } = new List<Article>();

        public RssHelper(string resourceLink)
        {
            try
            {
                document.Load(resourceLink);
                getFeeds();
            }
            catch (Exception ex)
            {

            }
        }

        private void getFeeds()
        {
            XmlNodeList nodeList = document.DocumentElement.ChildNodes;
            XmlNode node = nodeList.Item(0);
            Channel = getChannel(node);
            Articles = getArticles(node);
        }

        private Channel getChannel(XmlNode channelNodes)
        {
            Channel channel = new Channel();
            foreach (XmlNode node in channelNodes)
            {
                if (node.Name == "title")
                    channel.Title = node.InnerText;
                if (node.Name == "link")
                    channel.Link = node.InnerText;
                if (node.Name == "description")
                    channel.Description = node.InnerText;
                if (node.Name == "language")
                    channel.Language = node.InnerText;
            }
            return channel;
        }

        private List<Article> getArticles(XmlNode channelNode)
        {
            List<Article> articles = new List<Article>();
            foreach (XmlNode node in channelNode)
            {
                if (node.Name == "item")  
                    articles.Add(getArticle(node));
            }
            return articles;
        }

        private Article getArticle(XmlNode node)
        {
            XmlNodeList childNodes = node.ChildNodes;
            Article article = new Article();
            foreach (XmlNode childNode in childNodes)
            {
                if (childNode.Name == "title")
                    article.Title = childNode.InnerText;
                if (childNode.Name == "link")
                    article.Link = childNode.InnerText;
                if (childNode.Name == "description")
                    article.Description = childNode.InnerText;
                if (childNode.Name == "pubDate")
                    article.PubDate = childNode.InnerText;
            }
            article.ChannelId = Channel.Link;
            return article;
        }
    }
}