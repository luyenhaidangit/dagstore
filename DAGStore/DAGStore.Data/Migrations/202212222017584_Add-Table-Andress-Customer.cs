namespace DAGStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableAndressCustomer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerAndress",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 500),
                        NumberPhone = c.String(maxLength: 10),
                        Andress = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CustomerAndress");
        }
    }
}
