using ConsoleApp.Context;
using ConsoleApp.Helper;
using ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        private static Channel channel;

        private static List<Article> articles;

        private static ApplicationContext context = new ApplicationContext();

        private static string[] links = new string[]
        {
            "https://habr.com/ru/rss/all/all/",
             //"https://www.interfax.by/news/feed", //this RSS service is not valid - missing initial <rss> tag
            "https://www.belstu.by/rss"
        };

        private static int countOfSavedArticles;

        static void Main(string[] args)
        {
            foreach (string link in links)
            {
                RssHelper rssHelper = new RssHelper(link);
                channel = rssHelper.Channel;
                articles = rssHelper.Articles;
                writeToDB();
                printInfo();
                countOfSavedArticles = 0;
            }
            Console.Read();
        }

        private static void writeToDB()
        {
            saveChannel();
            saveArticles();
        }

        private static void saveChannel()
        {
            if (!isChannelExists(channel))
            {
                context.Channels.Add(channel);
                context.SaveChanges();
            }
        }

        private static bool isChannelExists(Channel channel)
        {
            return context.Channels.Find(channel.Link) != null;
        }

        private static void saveArticles()
        {
            foreach (Article article in articles)
            {
                if (!isArticleExists(article))
                {
                    context.Articles.Add(article);
                    context.SaveChanges();
                    countOfSavedArticles++;
                }
            }
        }

        private static bool isArticleExists(Article article)
        {
            return context.Articles.Find(article.Title, article.PubDate) != null;
        }

        private static void printInfo()
        {
            printChannelInfo();
            Console.WriteLine("Read articles:  {0}", articles.Count);
            Console.WriteLine("Saved articles: {0}", countOfSavedArticles);
            Console.WriteLine();
        }

        private static void printChannelInfo()
        {
            Console.WriteLine("Title:          {0}", channel.Title);
            Console.WriteLine("Link:           {0}", channel.Link);
            Console.WriteLine("Description:    {0}", channel.Description);
            Console.WriteLine("Language:       {0}", channel.Language);
        }

        private static void printArticles()
        {
            foreach (Article item in articles)
            {
                Console.WriteLine(item.Title);
                Console.WriteLine(item.Link);
                Console.WriteLine(item.Description);
                Console.WriteLine(item.PubDate);
                Console.WriteLine();
            }
        }
    }
}