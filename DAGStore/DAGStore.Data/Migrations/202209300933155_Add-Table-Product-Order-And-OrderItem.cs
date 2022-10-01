namespace DAGStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableProductOrderAndOrderItem : DbMigration
    {
        public override void Up()
        {
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
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Product");
            DropTable("dbo.OrderItems");
            DropTable("dbo.Orders");
        }
    }
}
