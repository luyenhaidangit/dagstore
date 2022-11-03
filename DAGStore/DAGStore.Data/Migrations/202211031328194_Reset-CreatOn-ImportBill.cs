namespace DAGStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ResetCreatOnImportBill : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ImportBill", "CreateOn");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ImportBill", "CreateOn", c => c.DateTime(nullable: false));
        }
    }
}
