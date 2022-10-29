namespace DAGStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableBrand : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Brand", "Description", c => c.String());
            AddColumn("dbo.Brand", "Deleted", c => c.Boolean(nullable: false));
            DropColumn("dbo.Brand", "MetaKeywords");
            DropColumn("dbo.Brand", "MetaDescription");
            DropColumn("dbo.Brand", "MetaTitle");
            DropColumn("dbo.Brand", "Alias");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Brand", "Alias", c => c.String(nullable: false, maxLength: 500));
            AddColumn("dbo.Brand", "MetaTitle", c => c.String(maxLength: 500));
            AddColumn("dbo.Brand", "MetaDescription", c => c.String(maxLength: 4000));
            AddColumn("dbo.Brand", "MetaKeywords", c => c.String(maxLength: 500));
            DropColumn("dbo.Brand", "Deleted");
            DropColumn("dbo.Brand", "Description");
        }
    }
}
