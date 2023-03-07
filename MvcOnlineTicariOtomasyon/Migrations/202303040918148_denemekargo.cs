namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class denemekargo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CargoDetails",
                c => new
                    {
                        CargoDetailId = c.Int(nullable: false, identity: true),
                        Statement = c.String(maxLength: 100, unicode: false),
                        TrackingCode = c.String(maxLength: 10, unicode: false),
                        Employee = c.String(maxLength: 25, unicode: false),
                        Receiver = c.String(maxLength: 25, unicode: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CargoDetailId);
            
            CreateTable(
                "dbo.CargoTrackings",
                c => new
                    {
                        CargoTrackingId = c.Int(nullable: false, identity: true),
                        TrackingCode = c.String(maxLength: 10, unicode: false),
                        Statement = c.String(maxLength: 100, unicode: false),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CargoTrackingId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CargoTrackings");
            DropTable("dbo.CargoDetails");
        }
    }
}
