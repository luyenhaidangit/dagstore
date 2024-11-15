namespace DAGStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableSlider : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Slider",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 500),
                        Position = c.String(maxLength: 500),
                        TypeSlider = c.String(maxLength: 500),
                        Page = c.String(maxLength: 500),
                        BackgroundColor = c.String(maxLength: 4000),
                        DisplayOrder = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SliderItem",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SliderID = c.Int(nullable: false),
                        Content = c.String(maxLength: 500),
                        ImagePath = c.String(maxLength: 4000),
                        URL = c.String(maxLength: 4000),
                        DisplayOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Slider", t => t.SliderID, cascadeDelete: true)
                .Index(t => t.SliderID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SliderItem", "SliderID", "dbo.Slider");
            DropIndex("dbo.SliderItem", new[] { "SliderID" });
            DropTable("dbo.SliderItem");
            DropTable("dbo.Slider");
        }
    }
}
