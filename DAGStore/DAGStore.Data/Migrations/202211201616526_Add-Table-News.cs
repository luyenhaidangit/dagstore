namespace DAGStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableNews : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.News", "Title", c => c.String(maxLength: 500));
            AddColumn("dbo.News", "PictureAvatar", c => c.String(maxLength: 4000));
            AddColumn("dbo.News", "Content", c => c.String());
            AddColumn("dbo.News", "CreateOn", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.News", "CreateOn");
            DropColumn("dbo.News", "Content");
            DropColumn("dbo.News", "PictureAvatar");
            DropColumn("dbo.News", "Title");
        }
    }
}
