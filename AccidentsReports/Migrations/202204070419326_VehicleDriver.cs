namespace AccidentsReports.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VehicleDriver : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Vehicles", "DriverLicence");
            AddForeignKey("dbo.Vehicles", "DriverLicence", "dbo.Drivers", "LicenceId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "DriverLicence", "dbo.Drivers");
            DropIndex("dbo.Vehicles", new[] { "DriverLicence" });
        }
    }
}
