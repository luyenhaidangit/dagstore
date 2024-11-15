﻿namespace DAGStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropertySellPriceActualProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "SellPriceActual", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "SellPriceActual");
        }
    }
}
