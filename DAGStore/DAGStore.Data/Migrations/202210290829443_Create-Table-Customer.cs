namespace DAGStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableCustomer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 500),
                        NumberPhone = c.String(maxLength: 10),
                        Sex = c.String(maxLength: 10),
                        BirthDay = c.DateTime(nullable: false),
                        Email = c.String(maxLength: 500),
                        Facebook = c.String(maxLength: 500),
                        Andress = c.String(maxLength: 500),
                        DeliveryAndress = c.String(maxLength: 500),
                        Description = c.String(maxLength: 500),
                        Published = c.Boolean(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Customer");
        }
    }
}
