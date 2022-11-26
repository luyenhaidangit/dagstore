namespace DAGStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVariationCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Variation",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CategoryID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Category", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.VariationOption",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        VariationID = c.Int(nullable: false),
                        Value = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Variation", t => t.VariationID, cascadeDelete: true)
                .Index(t => t.VariationID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VariationOption", "VariationID", "dbo.Variation");
            DropForeignKey("dbo.Variation", "CategoryID", "dbo.Category");
            DropIndex("dbo.VariationOption", new[] { "VariationID" });
            DropIndex("dbo.Variation", new[] { "CategoryID" });
            DropTable("dbo.VariationOption");
            DropTable("dbo.Variation");
        }
    }
}
