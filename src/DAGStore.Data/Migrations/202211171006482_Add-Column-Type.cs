namespace DAGStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Suggest", "Type", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Suggest", "Type");
        }
    }
}
