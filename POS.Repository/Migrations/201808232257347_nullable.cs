namespace POS.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SellDetails", "SellId", "dbo.Sells");
            DropIndex("dbo.SellDetails", new[] { "SellId" });
            AlterColumn("dbo.SellDetails", "SellId", c => c.Int());
            CreateIndex("dbo.SellDetails", "SellId");
            AddForeignKey("dbo.SellDetails", "SellId", "dbo.Sells", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SellDetails", "SellId", "dbo.Sells");
            DropIndex("dbo.SellDetails", new[] { "SellId" });
            AlterColumn("dbo.SellDetails", "SellId", c => c.Int(nullable: false));
            CreateIndex("dbo.SellDetails", "SellId");
            AddForeignKey("dbo.SellDetails", "SellId", "dbo.Sells", "Id", cascadeDelete: true);
        }
    }
}
