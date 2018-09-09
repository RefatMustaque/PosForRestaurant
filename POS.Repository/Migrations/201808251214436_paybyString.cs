namespace POS.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class paybyString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Sells", "PayBy", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sells", "PayBy", c => c.Int(nullable: false));
        }
    }
}
