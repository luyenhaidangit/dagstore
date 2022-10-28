namespace DAGStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ImportBillDetail", "ImportBillID", "dbo.ImportBill");
            DropPrimaryKey("dbo.ImportBill");
            AlterColumn("dbo.ImportBill", "ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.ImportBill", "ImportBillID", c => c.String(maxLength: 50));
            AddPrimaryKey("dbo.ImportBill", "ID");
            AddForeignKey("dbo.ImportBillDetail", "ImportBillID", "dbo.ImportBill", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ImportBillDetail", "ImportBillID", "dbo.ImportBill");
            DropPrimaryKey("dbo.ImportBill");
            AlterColumn("dbo.ImportBill", "ImportBillID", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.ImportBill", "ID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ImportBill", "ID");
            AddForeignKey("dbo.ImportBillDetail", "ImportBillID", "dbo.ImportBill", "ID", cascadeDelete: true);
        }
    }
}
