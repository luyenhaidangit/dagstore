namespace DAGStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCustomer : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customer", "BirthDay");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customer", "BirthDay", c => c.DateTime(nullable: false));
        }
    }
}
