namespace POS.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sellsellDetails : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SellDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        ItemTotal = c.Single(nullable: false),
                        SellId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: true)
                .ForeignKey("dbo.Sells", t => t.SellId, cascadeDelete: true)
                .Index(t => t.ItemId)
                .Index(t => t.SellId);
            
            CreateTable(
                "dbo.Sells",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PayBy = c.Int(nullable: false),
                        OverallDiscount = c.Single(nullable: false),
                        Cash = c.Single(nullable: false),
                        ChangeAmount = c.Single(nullable: false),
                        Due = c.Single(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Customer = c.String(),
                        Comment = c.String(),
                        TokenNO = c.Int(nullable: false),
                        Total = c.Single(nullable: false),
                        SubTotal = c.Single(nullable: false),
                        Tax = c.Single(nullable: false),
                        TotalPayable = c.Single(nullable: false),
                        TotalItemType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SellDetails", "SellId", "dbo.Sells");
            DropForeignKey("dbo.SellDetails", "ItemId", "dbo.Items");
            DropIndex("dbo.SellDetails", new[] { "SellId" });
            DropIndex("dbo.SellDetails", new[] { "ItemId" });
            DropTable("dbo.Sells");
            DropTable("dbo.SellDetails");
        }
    }
}
