namespace AccidentsReports.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReportImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "ReportId", c => c.Int());
            CreateIndex("dbo.Images", "ReportId");
            AddForeignKey("dbo.Images", "ReportId", "dbo.Reports", "ReportId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "ReportId", "dbo.Reports");
            DropIndex("dbo.Images", new[] { "ReportId" });
            DropColumn("dbo.Images", "ReportId");
        }
    }
}
