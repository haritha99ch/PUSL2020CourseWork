namespace AccidentsReports.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReportReportMeta : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ReportMetas");
            AlterColumn("dbo.ReportMetas", "ReportId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ReportMetas", "ReportId");
            CreateIndex("dbo.ReportMetas", "ReportId");
            AddForeignKey("dbo.ReportMetas", "ReportId", "dbo.Reports", "ReportId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReportMetas", "ReportId", "dbo.Reports");
            DropIndex("dbo.ReportMetas", new[] { "ReportId" });
            DropPrimaryKey("dbo.ReportMetas");
            AlterColumn("dbo.ReportMetas", "ReportId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.ReportMetas", "ReportId");
        }
    }
}
