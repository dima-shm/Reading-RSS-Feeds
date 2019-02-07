namespace ConsoleApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Title = c.String(nullable: false, maxLength: 128),
                        PubDate = c.String(nullable: false, maxLength: 128),
                        Link = c.String(),
                        Description = c.String(),
                        ChannelId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Title, t.PubDate })
                .ForeignKey("dbo.Channels", t => t.ChannelId)
                .Index(t => t.ChannelId);
            
            CreateTable(
                "dbo.Channels",
                c => new
                    {
                        Link = c.String(nullable: false, maxLength: 128),
                        Title = c.String(),
                        Description = c.String(),
                        Language = c.String(),
                    })
                .PrimaryKey(t => t.Link);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articles", "ChannelId", "dbo.Channels");
            DropIndex("dbo.Articles", new[] { "ChannelId" });
            DropTable("dbo.Channels");
            DropTable("dbo.Articles");
        }
    }
}
