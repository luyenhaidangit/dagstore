namespace DAGStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableMenuRecordAndMenuItemRecord : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles");
            DropForeignKey("dbo.IdentityUserClaims", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserLogins", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserRoles", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropIndex("dbo.IdentityUserRoles", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaims", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserLogins", new[] { "ApplicationUser_Id" });
            AddColumn("dbo.MenuRecord", "ContentBody", c => c.String());
            DropTable("dbo.Category");
            DropTable("dbo.Errors");
            DropTable("dbo.News");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderItems");
            DropTable("dbo.Product");
            DropTable("dbo.IdentityRoles");
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.ApplicationUsers");
            DropTable("dbo.IdentityUserClaims");
            DropTable("dbo.IdentityUserLogins");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.IdentityUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.IdentityUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ApplicationUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(maxLength: 500),
                        Andress = c.String(maxLength: 2000),
                        Birthday = c.DateTime(),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 500),
                        ShortDescription = c.String(maxLength: 4000),
                        FullDescription = c.String(),
                        ShowOnHomePage = c.Boolean(nullable: false),
                        MetaKeywords = c.String(maxLength: 500),
                        MetaDescription = c.String(maxLength: 4000),
                        MetaTitle = c.String(maxLength: 500),
                        Alias = c.String(nullable: false, maxLength: 500),
                        AllowCustomerReviews = c.Boolean(nullable: false),
                        IsShipEnabled = c.Boolean(nullable: false),
                        AdditionalShippingCharge = c.Decimal(precision: 18, scale: 2),
                        StockQuantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OldPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HasDiscountsApplied = c.Boolean(nullable: false),
                        DisplayOrder = c.Int(nullable: false),
                        Published = c.Boolean(nullable: false),
                        CreateOn = c.DateTime(nullable: false),
                        UpdateOn = c.DateTime(nullable: false),
                        PicturePath = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        TotalTax = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalShipping = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        ShippingAddress = c.String(maxLength: 4000),
                        OrderStatus = c.Boolean(nullable: false),
                        ShippingStatus = c.Boolean(nullable: false),
                        PaymentStatus = c.Boolean(nullable: false),
                        OrderTax = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderShipping = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CustomerOrderComment = c.String(),
                        CreateOn = c.DateTime(nullable: false),
                        UpdateOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 500),
                        PicturePath = c.String(maxLength: 4000),
                        Content = c.String(nullable: false),
                        Published = c.Boolean(nullable: false),
                        AllowComments = c.Boolean(nullable: false),
                        CreateOn = c.DateTime(nullable: false),
                        MetaKeywords = c.String(maxLength: 500),
                        MetaDescription = c.String(maxLength: 4000),
                        MetaTitle = c.String(maxLength: 500),
                        Alias = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Errors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Message = c.String(nullable: false, maxLength: 4000),
                        StackTrace = c.String(nullable: false, maxLength: 4000),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 500),
                        Alias = c.String(maxLength: 500),
                        MetaKeywords = c.String(maxLength: 500),
                        MetaDescription = c.String(maxLength: 4000),
                        MetaTitle = c.String(maxLength: 500),
                        ParentCategoryID = c.Int(nullable: false),
                        ImageAvatarPath = c.String(),
                        ShowOnHomePage = c.Boolean(nullable: false),
                        Published = c.Boolean(nullable: false),
                        DisplayOrder = c.Int(nullable: false),
                        CreateOn = c.DateTime(nullable: false),
                        UpdateOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            DropColumn("dbo.MenuRecord", "ContentBody");
            CreateIndex("dbo.IdentityUserLogins", "ApplicationUser_Id");
            CreateIndex("dbo.IdentityUserClaims", "ApplicationUser_Id");
            CreateIndex("dbo.IdentityUserRoles", "ApplicationUser_Id");
            CreateIndex("dbo.IdentityUserRoles", "IdentityRole_Id");
            AddForeignKey("dbo.IdentityUserRoles", "ApplicationUser_Id", "dbo.ApplicationUsers", "Id");
            AddForeignKey("dbo.IdentityUserLogins", "ApplicationUser_Id", "dbo.ApplicationUsers", "Id");
            AddForeignKey("dbo.IdentityUserClaims", "ApplicationUser_Id", "dbo.ApplicationUsers", "Id");
            AddForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles", "Id");
        }
    }
}
