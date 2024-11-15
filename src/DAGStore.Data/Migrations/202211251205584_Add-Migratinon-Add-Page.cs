namespace DAGStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMigratinonAddPage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Page",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 500),
                        PictureAvatar = c.String(maxLength: 4000),
                        Content = c.String(),
                        Alias = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Page");
        }
    }
}
