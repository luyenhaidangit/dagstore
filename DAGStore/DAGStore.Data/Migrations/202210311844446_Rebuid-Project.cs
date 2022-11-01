namespace DAGStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RebuidProject : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.ImportBill", "SupplierID");
            AddForeignKey("dbo.ImportBill", "SupplierID", "dbo.Supplier", "ID", cascadeDelete: true);
            DropColumn("dbo.ImportBill", "ImportBillID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ImportBill", "ImportBillID", c => c.String(maxLength: 50));
            DropForeignKey("dbo.ImportBill", "SupplierID", "dbo.Supplier");
            DropIndex("dbo.ImportBill", new[] { "SupplierID" });
        }
    }
}
