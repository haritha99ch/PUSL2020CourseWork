namespace AccidentsReports.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LocationUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReportMetas", "City", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.ReportMetas", "No", c => c.Int(nullable: false));
            AddColumn("dbo.ReportMetas", "Street1", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.ReportMetas", "Street2", c => c.String(maxLength: 20));
            AddColumn("dbo.ReportMetas", "Street3", c => c.String(maxLength: 20));
            DropColumn("dbo.ReportMetas", "Latitude");
            DropColumn("dbo.ReportMetas", "Longitude");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ReportMetas", "Longitude", c => c.Single(nullable: false));
            AddColumn("dbo.ReportMetas", "Latitude", c => c.Single(nullable: false));
            DropColumn("dbo.ReportMetas", "Street3");
            DropColumn("dbo.ReportMetas", "Street2");
            DropColumn("dbo.ReportMetas", "Street1");
            DropColumn("dbo.ReportMetas", "No");
            DropColumn("dbo.ReportMetas", "City");
        }
    }
}
