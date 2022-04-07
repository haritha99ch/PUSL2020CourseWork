namespace AccidentsReports.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReportMeta : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReportMetas",
                c => new
                    {
                        ReportId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 20),
                        DateTime = c.DateTime(nullable: false),
                        Latitude = c.Single(nullable: false),
                        Longitude = c.Single(nullable: false),
                        Cause = c.String(nullable: false, maxLength: 10),
                        IsVehicleVehicle = c.Boolean(nullable: false),
                        IsVehicleProperty = c.Boolean(nullable: false),
                        IsVehiclePedestrian = c.Boolean(nullable: false),
                        Scale = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.ReportId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ReportMetas");
        }
    }
}
