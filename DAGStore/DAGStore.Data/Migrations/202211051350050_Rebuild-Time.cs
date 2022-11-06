namespace DAGStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RebuildTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ImportBill", "CreateOn", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ImportBill", "CreateOn");
        }
    }
}
