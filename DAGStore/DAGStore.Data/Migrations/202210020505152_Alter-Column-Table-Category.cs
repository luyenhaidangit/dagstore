namespace DAGStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterColumnTableCategory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Category", "Category_ID", "dbo.Category");
            DropIndex("dbo.Category", new[] { "Category_ID" });
            DropColumn("dbo.Category", "Category_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Category", "Category_ID", c => c.Int());
            CreateIndex("dbo.Category", "Category_ID");
            AddForeignKey("dbo.Category", "Category_ID", "dbo.Category", "ID");
        }
    }
}
