namespace DAGStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "ShortDescriptionEndow", c => c.String(maxLength: 4000));
            DropColumn("dbo.Product", "AllowCustomerReviews");
            DropColumn("dbo.Product", "IsShipEnabled");
            DropColumn("dbo.Product", "AdditionalShippingCharge");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "AdditionalShippingCharge", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Product", "IsShipEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Product", "AllowCustomerReviews", c => c.Boolean(nullable: false));
            DropColumn("dbo.Product", "ShortDescriptionEndow");
        }
    }
}
