namespace DAGStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Category", "Products", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Category", "Products");
        }
    }
}
