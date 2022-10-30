namespace DAGStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditTableProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "CostPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Product", "SellPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Product", "InventoryQuantity", c => c.Int(nullable: false));
            AddColumn("dbo.Product", "MinimumInventoryQuantity", c => c.Int(nullable: false));
            AddColumn("dbo.Product", "MaximumInventoryQuantity", c => c.Int(nullable: false));
            AddColumn("dbo.Product", "Deleted", c => c.Boolean(nullable: false));
            DropColumn("dbo.Product", "ShowOnHomePage");
            DropColumn("dbo.Product", "MetaKeywords");
            DropColumn("dbo.Product", "MetaDescription");
            DropColumn("dbo.Product", "MetaTitle");
            DropColumn("dbo.Product", "Alias");
            DropColumn("dbo.Product", "StockQuantity");
            DropColumn("dbo.Product", "Price");
            DropColumn("dbo.Product", "OldPrice");
            DropColumn("dbo.Product", "HasDiscountsApplied");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "HasDiscountsApplied", c => c.Boolean(nullable: false));
            AddColumn("dbo.Product", "OldPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Product", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Product", "StockQuantity", c => c.Int(nullable: false));
            AddColumn("dbo.Product", "Alias", c => c.String(nullable: false, maxLength: 500));
            AddColumn("dbo.Product", "MetaTitle", c => c.String(maxLength: 500));
            AddColumn("dbo.Product", "MetaDescription", c => c.String(maxLength: 4000));
            AddColumn("dbo.Product", "MetaKeywords", c => c.String(maxLength: 500));
            AddColumn("dbo.Product", "ShowOnHomePage", c => c.Boolean(nullable: false));
            DropColumn("dbo.Product", "Deleted");
            DropColumn("dbo.Product", "MaximumInventoryQuantity");
            DropColumn("dbo.Product", "MinimumInventoryQuantity");
            DropColumn("dbo.Product", "InventoryQuantity");
            DropColumn("dbo.Product", "SellPrice");
            DropColumn("dbo.Product", "CostPrice");
        }
    }
}
