namespace DAGStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignBrandIDProduct : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Product", "BrandID");
            AddForeignKey("dbo.Product", "BrandID", "dbo.Brand", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "BrandID", "dbo.Brand");
            DropIndex("dbo.Product", new[] { "BrandID" });
        }
    }
}
