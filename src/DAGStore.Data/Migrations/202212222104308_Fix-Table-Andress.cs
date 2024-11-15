namespace DAGStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixTableAndress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerAndress", "CustomerID", c => c.Int(nullable: false));
            CreateIndex("dbo.CustomerAndress", "CustomerID");
            AddForeignKey("dbo.CustomerAndress", "CustomerID", "dbo.Customer", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerAndress", "CustomerID", "dbo.Customer");
            DropIndex("dbo.CustomerAndress", new[] { "CustomerID" });
            DropColumn("dbo.CustomerAndress", "CustomerID");
        }
    }
}
