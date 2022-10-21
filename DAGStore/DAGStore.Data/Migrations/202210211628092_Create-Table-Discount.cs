namespace DAGStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableDiscount : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Discount",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 500),
                        UsePercentage = c.Boolean(nullable: false),
                        DiscountPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RequiresCouponCode = c.Boolean(nullable: false),
                        CouponCode = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(nullable: false),
                        PicturePath = c.String(maxLength: 4000),
                        ColorBackGround = c.String(maxLength: 100),
                        ColorText = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProductDiscount",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        DiscountID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductID, t.DiscountID })
                .ForeignKey("dbo.Discount", t => t.DiscountID, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.DiscountID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductDiscount", "ProductID", "dbo.Product");
            DropForeignKey("dbo.ProductDiscount", "DiscountID", "dbo.Discount");
            DropIndex("dbo.ProductDiscount", new[] { "DiscountID" });
            DropIndex("dbo.ProductDiscount", new[] { "ProductID" });
            DropTable("dbo.ProductDiscount");
            DropTable("dbo.Discount");
        }
    }
}
