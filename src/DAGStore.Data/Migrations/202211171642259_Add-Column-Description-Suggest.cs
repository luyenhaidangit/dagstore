namespace DAGStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnDescriptionSuggest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Suggest", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Suggest", "Description");
        }
    }
}
