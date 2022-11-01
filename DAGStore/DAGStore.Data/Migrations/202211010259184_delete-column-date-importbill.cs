namespace DAGStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletecolumndateimportbill : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ImportBill", "CreateOn");
            DropColumn("dbo.ImportBill", "UpdateOn");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ImportBill", "UpdateOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.ImportBill", "CreateOn", c => c.DateTime(nullable: false));
        }
    }
}
