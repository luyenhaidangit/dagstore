namespace DAGStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteColumnAliasCategory : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Category", "Alias");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Category", "Alias", c => c.String(nullable: false, maxLength: 500));
        }
    }
}
