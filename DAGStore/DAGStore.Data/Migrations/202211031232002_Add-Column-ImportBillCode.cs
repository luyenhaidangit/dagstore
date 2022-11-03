namespace DAGStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnImportBillCode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ImportBill", "ImportBillCode", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ImportBill", "ImportBillCode");
        }
    }
}
