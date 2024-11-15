namespace DAGStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductItem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductItem",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        SKU = c.String(nullable: false, maxLength: 500),
                        InventoryQuantity = c.Int(nullable: false),
                        CostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SellPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SellPriceActual = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Published = c.Boolean(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductItem", "ProductID", "dbo.Product");
            DropIndex("dbo.ProductItem", new[] { "ProductID" });
            DropTable("dbo.ProductItem");
        }
    }
}
