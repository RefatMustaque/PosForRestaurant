namespace POS.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tableZone : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TableZones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TableName = c.String(),
                        ZoneName = c.String(),
                        AvailableSeatNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TableZones");
        }
    }
}
