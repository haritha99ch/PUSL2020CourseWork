namespace AccidentsReports.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Vehicle : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        PlateNumber = c.String(nullable: false, maxLength: 20),
                        DriverLicence = c.Int(),
                        ModelName = c.String(maxLength: 20),
                        Class = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.PlateNumber);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Vehicles");
        }
    }
}
