namespace DAGStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableCustomer1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customer", "Sex");
            DropColumn("dbo.Customer", "Facebook");
            DropColumn("dbo.Customer", "Description");
            DropColumn("dbo.Customer", "Published");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customer", "Published", c => c.Boolean(nullable: false));
            AddColumn("dbo.Customer", "Description", c => c.String(maxLength: 500));
            AddColumn("dbo.Customer", "Facebook", c => c.String(maxLength: 500));
            AddColumn("dbo.Customer", "Sex", c => c.String(maxLength: 10));
        }
    }
}
