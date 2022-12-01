namespace DAGStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditOrderBill : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "ShippingFormat", c => c.String(nullable: false));
            AddColumn("dbo.Orders", "PaymentFormat", c => c.Int(nullable: false));
            AddColumn("dbo.OrderItems", "TotalMoney", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Orders", "OrderStatus", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "PaymentStatus", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "CustomerID");
            CreateIndex("dbo.OrderItems", "OrderID");
            CreateIndex("dbo.OrderItems", "ProductID");
            AddForeignKey("dbo.Orders", "CustomerID", "dbo.Customer", "ID", cascadeDelete: true);
            AddForeignKey("dbo.OrderItems", "OrderID", "dbo.Orders", "ID", cascadeDelete: true);
            AddForeignKey("dbo.OrderItems", "ProductID", "dbo.Product", "ID", cascadeDelete: true);
            DropColumn("dbo.Orders", "ShippingStatus");
            DropColumn("dbo.Orders", "OrderTax");
            DropColumn("dbo.Orders", "OrderShipping");
            DropColumn("dbo.Orders", "UpdateOn");
            DropColumn("dbo.OrderItems", "TotalTax");
            DropColumn("dbo.OrderItems", "TotalShipping");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderItems", "TotalShipping", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.OrderItems", "TotalTax", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Orders", "UpdateOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "OrderShipping", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Orders", "OrderTax", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Orders", "ShippingStatus", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.OrderItems", "ProductID", "dbo.Product");
            DropForeignKey("dbo.OrderItems", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "CustomerID", "dbo.Customer");
            DropIndex("dbo.OrderItems", new[] { "ProductID" });
            DropIndex("dbo.OrderItems", new[] { "OrderID" });
            DropIndex("dbo.Orders", new[] { "CustomerID" });
            AlterColumn("dbo.Orders", "PaymentStatus", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Orders", "OrderStatus", c => c.Boolean(nullable: false));
            DropColumn("dbo.OrderItems", "TotalMoney");
            DropColumn("dbo.Orders", "PaymentFormat");
            DropColumn("dbo.Orders", "ShippingFormat");
        }
    }
}
