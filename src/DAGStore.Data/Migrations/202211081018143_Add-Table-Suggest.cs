namespace DAGStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableSuggest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Suggest",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 500),
                        ImagePath = c.String(maxLength: 4000),
                        TextColor = c.String(maxLength: 500),
                        BackgroundColor = c.String(maxLength: 500),
                        SliderID = c.Int(nullable: false),
                        DisplayOrder = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Slider", t => t.SliderID, cascadeDelete: true)
                .Index(t => t.SliderID);
            
            CreateTable(
                "dbo.SuggestProduct",
                c => new
                    {
                        SuggestID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SuggestID, t.ProductID })
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Suggest", t => t.SuggestID, cascadeDelete: true)
                .Index(t => t.SuggestID)
                .Index(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SuggestProduct", "SuggestID", "dbo.Suggest");
            DropForeignKey("dbo.SuggestProduct", "ProductID", "dbo.Product");
            DropForeignKey("dbo.Suggest", "SliderID", "dbo.Slider");
            DropIndex("dbo.SuggestProduct", new[] { "ProductID" });
            DropIndex("dbo.SuggestProduct", new[] { "SuggestID" });
            DropIndex("dbo.Suggest", new[] { "SliderID" });
            DropTable("dbo.SuggestProduct");
            DropTable("dbo.Suggest");
        }
    }
}
