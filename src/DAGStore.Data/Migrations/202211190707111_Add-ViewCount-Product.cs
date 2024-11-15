namespace DAGStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddViewCountProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "ViewCount", c => c.Int(nullable: false, defaultValue: 0));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "ViewCount");
        }
    }
}
