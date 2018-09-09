namespace POS.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class byteArray : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Items", "Image", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Items", "Image", c => c.Byte(nullable: false));
        }
    }
}
