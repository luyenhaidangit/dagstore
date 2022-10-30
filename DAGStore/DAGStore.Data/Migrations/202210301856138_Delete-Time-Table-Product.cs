namespace DAGStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteTimeTableProduct : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Product", "CreateOn");
            DropColumn("dbo.Product", "UpdateOn");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "UpdateOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Product", "CreateOn", c => c.DateTime(nullable: false));
        }
    }
}
