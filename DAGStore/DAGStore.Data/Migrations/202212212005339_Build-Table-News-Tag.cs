namespace DAGStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BuildTableNewsTag : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NewsTag",
                c => new
                    {
                        NewsID = c.Int(nullable: false),
                        TagID = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => new { t.NewsID, t.TagID })
                .ForeignKey("dbo.News", t => t.NewsID, cascadeDelete: true)
                .ForeignKey("dbo.Tag", t => t.TagID, cascadeDelete: true)
                .Index(t => t.NewsID)
                .Index(t => t.TagID);
            
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 50, unicode: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Type = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.News", "ViewCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NewsTag", "TagID", "dbo.Tag");
            DropForeignKey("dbo.NewsTag", "NewsID", "dbo.News");
            DropIndex("dbo.NewsTag", new[] { "TagID" });
            DropIndex("dbo.NewsTag", new[] { "NewsID" });
            DropColumn("dbo.News", "ViewCount");
            DropTable("dbo.Tag");
            DropTable("dbo.NewsTag");
        }
    }
}
