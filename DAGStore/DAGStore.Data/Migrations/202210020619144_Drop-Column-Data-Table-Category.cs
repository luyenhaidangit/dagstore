namespace DAGStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropColumnDataTableCategory : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Category", "CreateOn");
            DropColumn("dbo.Category", "UpdateOn");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Category", "UpdateOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Category", "CreateOn", c => c.DateTime(nullable: false));
        }
    }
}
