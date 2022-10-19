namespace DAGStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableBrand : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brand",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 500),
                        PicturePath = c.String(maxLength: 4000),
                        MetaKeywords = c.String(maxLength: 500),
                        MetaDescription = c.String(maxLength: 4000),
                        MetaTitle = c.String(maxLength: 500),
                        Alias = c.String(nullable: false, maxLength: 500),
                        Published = c.Boolean(nullable: false),
                        DisplayOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Brand");
        }
    }
}
