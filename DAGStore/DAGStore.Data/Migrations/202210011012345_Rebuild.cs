namespace DAGStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rebuild : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ParentCategoryID = c.Int(nullable: false),
                        PicturePath = c.String(maxLength: 4000),
                        Description = c.String(),
                        MetaKeywords = c.String(maxLength: 500),
                        MetaDescription = c.String(maxLength: 4000),
                        MetaTitle = c.String(maxLength: 500),
                        Alias = c.String(nullable: false, maxLength: 500),
                        ShowOnHomePage = c.Boolean(nullable: false),
                        Published = c.Boolean(nullable: false),
                        DisplayOrder = c.Int(nullable: false),
                        CreateOn = c.DateTime(nullable: false),
                        UpdateOn = c.DateTime(nullable: false),
                        Category_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Category", t => t.Category_ID)
                .Index(t => t.Category_ID);
            
            CreateTable(
                "dbo.MenuItemRecord",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        MenuRecordID = c.Int(nullable: false),
                        ParentMenuItemRecordID = c.Int(nullable: false),
                        ProviderName = c.String(nullable: false, maxLength: 100),
                        Model = c.String(nullable: false),
                        Title = c.String(maxLength: 1000),
                        Published = c.Boolean(nullable: false),
                        DisplayOrder = c.Int(nullable: false),
                        Icon = c.String(maxLength: 100),
                        HtmlID = c.String(maxLength: 500),
                        CssClass = c.String(maxLength: 500),
                        IconColor = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MenuRecord", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.MenuRecord",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 500),
                        Template = c.String(nullable: false, maxLength: 100),
                        WidgetZone = c.String(maxLength: 500),
                        Published = c.Boolean(nullable: false),
                        DisplayOrder = c.Int(nullable: false),
                        ContentBody = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        ShippingAddress = c.String(maxLength: 4000),
                        OrderStatus = c.Boolean(nullable: false),
                        ShippingStatus = c.Boolean(nullable: false),
                        PaymentStatus = c.Boolean(nullable: false),
                        OrderTax = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderShipping = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CustomerOrderComment = c.String(),
                        CreateOn = c.DateTime(nullable: false),
                        UpdateOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        TotalTax = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalShipping = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 500),
                        CategoryID = c.Int(nullable: false),
                        PicturePath = c.String(maxLength: 4000),
                        ShortDescription = c.String(maxLength: 4000),
                        FullDescription = c.String(),
                        ShowOnHomePage = c.Boolean(nullable: false),
                        MetaKeywords = c.String(maxLength: 500),
                        MetaDescription = c.String(maxLength: 4000),
                        MetaTitle = c.String(maxLength: 500),
                        Alias = c.String(nullable: false, maxLength: 500),
                        AllowCustomerReviews = c.Boolean(nullable: false),
                        IsShipEnabled = c.Boolean(nullable: false),
                        AdditionalShippingCharge = c.Decimal(precision: 18, scale: 2),
                        StockQuantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OldPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HasDiscountsApplied = c.Boolean(nullable: false),
                        DisplayOrder = c.Int(nullable: false),
                        Published = c.Boolean(nullable: false),
                        CreateOn = c.DateTime(nullable: false),
                        UpdateOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Category", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "CategoryID", "dbo.Category");
            DropForeignKey("dbo.MenuItemRecord", "ID", "dbo.MenuRecord");
            DropForeignKey("dbo.Category", "Category_ID", "dbo.Category");
            DropIndex("dbo.Product", new[] { "CategoryID" });
            DropIndex("dbo.MenuItemRecord", new[] { "ID" });
            DropIndex("dbo.Category", new[] { "Category_ID" });
            DropTable("dbo.Product");
            DropTable("dbo.OrderItems");
            DropTable("dbo.Orders");
            DropTable("dbo.MenuRecord");
            DropTable("dbo.MenuItemRecord");
            DropTable("dbo.Category");
        }
    }
}
