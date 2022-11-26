namespace DAGStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableProductConfig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductConfiguration",
                c => new
                    {
                        ProductItemID = c.Int(nullable: false),
                        VariationOptionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductItemID, t.VariationOptionID })
                .ForeignKey("dbo.ProductItem", t => t.ProductItemID, cascadeDelete: false)
                .ForeignKey("dbo.VariationOption", t => t.VariationOptionID, cascadeDelete: false)
                .Index(t => t.ProductItemID)
                .Index(t => t.VariationOptionID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductConfiguration", "VariationOptionID", "dbo.VariationOption");
            DropForeignKey("dbo.ProductConfiguration", "ProductItemID", "dbo.ProductItem");
            DropIndex("dbo.ProductConfiguration", new[] { "VariationOptionID" });
            DropIndex("dbo.ProductConfiguration", new[] { "ProductItemID" });
            DropTable("dbo.ProductConfiguration");
        }
    }
}
