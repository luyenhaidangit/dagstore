namespace DAGStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterTableCategory : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Category", "Products");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Category", "Products", c => c.String());
        }
    }
}
