namespace AccidentsReports.Migrations {
    using System;
    using System.Data.Entity.Migrations;

    public partial class VehicleReport : DbMigration {
        public override void Up() {
            CreateTable(
                "dbo.VehicleReports",
                c => new {
                    VehiclePlateNumber = c.String(nullable: false, maxLength: 20),
                    ReportId = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.VehiclePlateNumber, t.ReportId })
                .ForeignKey("dbo.Vehicles", t => t.VehiclePlateNumber, cascadeDelete: true)
                .ForeignKey("dbo.Reports", t => t.ReportId, cascadeDelete: true)
                .Index(t => t.VehiclePlateNumber)
                .Index(t => t.ReportId);

        }

        public override void Down() {
            DropForeignKey("dbo.VehicleReports", "ReportId", "dbo.Reports");
            DropForeignKey("dbo.VehicleReports", "VehiclePlateNumber", "dbo.Vehicles");
            DropIndex("dbo.VehicleReports", new[] { "ReportId" });
            DropIndex("dbo.VehicleReports", new[] { "VehiclePlateNumber" });
            DropTable("dbo.VehicleReports");
        }
    }
}
