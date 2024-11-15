namespace DAGStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddObjectEvent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Event",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 500),
                        ImagePath = c.String(maxLength: 4000),
                        FullDescription = c.String(),
                        DisplayOrder = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                        ShowOnHomePage = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Event");
        }
    }
}
