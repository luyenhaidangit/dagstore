namespace DAGStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteColumnSliderID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Suggest", "SliderID", "dbo.Slider");
            DropIndex("dbo.Suggest", new[] { "SliderID" });
            RenameColumn(table: "dbo.Suggest", name: "SliderID", newName: "Slider_ID");
            AlterColumn("dbo.Suggest", "Slider_ID", c => c.Int());
            CreateIndex("dbo.Suggest", "Slider_ID");
            AddForeignKey("dbo.Suggest", "Slider_ID", "dbo.Slider", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Suggest", "Slider_ID", "dbo.Slider");
            DropIndex("dbo.Suggest", new[] { "Slider_ID" });
            AlterColumn("dbo.Suggest", "Slider_ID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Suggest", name: "Slider_ID", newName: "SliderID");
            CreateIndex("dbo.Suggest", "SliderID");
            AddForeignKey("dbo.Suggest", "SliderID", "dbo.Slider", "ID", cascadeDelete: true);
        }
    }
}
