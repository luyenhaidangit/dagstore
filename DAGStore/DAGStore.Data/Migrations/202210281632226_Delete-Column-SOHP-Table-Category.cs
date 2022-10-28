namespace DAGStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteColumnSOHPTableCategory : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Category", "ShowOnHomePage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Category", "ShowOnHomePage", c => c.Boolean(nullable: false));
        }
    }
}
