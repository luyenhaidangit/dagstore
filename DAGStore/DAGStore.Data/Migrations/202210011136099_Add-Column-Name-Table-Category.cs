namespace DAGStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnNameTableCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Category", "Name", c => c.String(nullable: false, maxLength: 500));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Category", "Name");
        }
    }
}
