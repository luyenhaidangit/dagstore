namespace DAGStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixcolumn : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ImportBill", "ImportBillID", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ImportBill", "ImportBillID", c => c.String(nullable: false, maxLength: 10));
        }
    }
}
