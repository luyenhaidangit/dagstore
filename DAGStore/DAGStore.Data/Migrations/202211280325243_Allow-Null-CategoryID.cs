namespace DAGStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllowNullCategoryID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Variation", "CategoryID", "dbo.Category");
            DropIndex("dbo.Variation", new[] { "CategoryID" });
            AlterColumn("dbo.Variation", "CategoryID", c => c.Int());
            CreateIndex("dbo.Variation", "CategoryID");
            AddForeignKey("dbo.Variation", "CategoryID", "dbo.Category", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Variation", "CategoryID", "dbo.Category");
            DropIndex("dbo.Variation", new[] { "CategoryID" });
            AlterColumn("dbo.Variation", "CategoryID", c => c.Int(nullable: false));
            CreateIndex("dbo.Variation", "CategoryID");
            AddForeignKey("dbo.Variation", "CategoryID", "dbo.Category", "ID", cascadeDelete: true);
        }
    }
}
