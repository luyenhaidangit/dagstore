namespace DAGStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnShowOnHomePageSuggest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Suggest", "ShowOnHomePage", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Suggest", "ShowOnHomePage");
        }
    }
}
