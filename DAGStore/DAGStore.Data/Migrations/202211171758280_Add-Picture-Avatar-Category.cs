namespace DAGStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPictureAvatarCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Category", "PictureAvatar", c => c.String(maxLength: 4000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Category", "PictureAvatar");
        }
    }
}
