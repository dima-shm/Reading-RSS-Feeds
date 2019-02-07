using WebApp.Models;
using System.Data.Entity;

namespace WebApp.Context
{
    class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("RSSReaderDB") { }

        public DbSet<Channel> Channels { get; set; }

        public DbSet<Article> Articles { get; set; }
    }
}