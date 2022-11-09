namespace DAGStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReCreateColumnSliderID : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Suggest", name: "Slider_ID", newName: "SliderID");
            RenameIndex(table: "dbo.Suggest", name: "IX_Slider_ID", newName: "IX_SliderID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Suggest", name: "IX_SliderID", newName: "IX_Slider_ID");
            RenameColumn(table: "dbo.Suggest", name: "SliderID", newName: "Slider_ID");
        }
    }
}
