namespace DAGStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableImportBill : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImportBill",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SupplierID = c.Int(nullable: false),
                        TotalPriceBill = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ActualPriceBill = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(maxLength: 4000),
                        Status = c.Boolean(nullable: false),
                        CreateOn = c.DateTime(nullable: false),
                        UpdateOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Supplier", t => t.SupplierID, cascadeDelete: true)
                .Index(t => t.SupplierID);
            
            CreateTable(
                "dbo.ImportBillDetail",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ImportBillID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        ImportPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalImportPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ImportBill", t => t.ImportBillID, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ImportBillID)
                .Index(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ImportBillDetail", "ProductID", "dbo.Product");
            DropForeignKey("dbo.ImportBillDetail", "ImportBillID", "dbo.ImportBill");
            DropForeignKey("dbo.ImportBill", "SupplierID", "dbo.Supplier");
            DropIndex("dbo.ImportBillDetail", new[] { "ProductID" });
            DropIndex("dbo.ImportBillDetail", new[] { "ImportBillID" });
            DropIndex("dbo.ImportBill", new[] { "SupplierID" });
            DropTable("dbo.ImportBillDetail");
            DropTable("dbo.ImportBill");
        }
    }
}
