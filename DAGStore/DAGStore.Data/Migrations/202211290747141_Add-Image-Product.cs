namespace DAGStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageProduct : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImageProduct",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        ImagePath = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ImageProduct", "ProductID", "dbo.Product");
            DropIndex("dbo.ImageProduct", new[] { "ProductID" });
            DropTable("dbo.ImageProduct");
        }
    }
}
