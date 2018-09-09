namespace POS.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Barcode = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                        Quantity = c.String(),
                        PurchasePrice = c.Single(nullable: false),
                        SalesPrice = c.Single(nullable: false),
                        DiscountRate = c.Single(nullable: false),
                        ItemCategoryId = c.Int(),
                        Supplier = c.String(),
                        ShopLocation = c.String(),
                        TaxApply = c.Boolean(nullable: false),
                        KitchenItem = c.Boolean(nullable: false),
                        Weight = c.String(),
                        ManufacturingDate = c.DateTime(nullable: false),
                        ExpiryDate = c.DateTime(nullable: false),
                        Image = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ItemCategories", t => t.ItemCategoryId)
                .Index(t => t.ItemCategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "ItemCategoryId", "dbo.ItemCategories");
            DropIndex("dbo.Items", new[] { "ItemCategoryId" });
            DropTable("dbo.Items");
            DropTable("dbo.ItemCategories");
        }
    }
}
