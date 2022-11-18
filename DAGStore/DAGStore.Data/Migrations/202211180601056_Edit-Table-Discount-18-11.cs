namespace DAGStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditTableDiscount1811 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Discount", "FullDescription", c => c.String());
            AddColumn("dbo.Discount", "PictureAvatar", c => c.String(maxLength: 4000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Discount", "PictureAvatar");
            DropColumn("dbo.Discount", "FullDescription");
        }
    }
}
