namespace AccidentsReports.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReportMetaReportMod : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ReportMetas", "ReportId", "dbo.Reports");
            DropIndex("dbo.ReportMetas", new[] { "ReportId" });
            DropPrimaryKey("dbo.ReportMetas");
            AddColumn("dbo.Reports", "ReporMetatId", c => c.Int(nullable: false));
            AlterColumn("dbo.ReportMetas", "ReportId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.ReportMetas", "ReportId");
            CreateIndex("dbo.Reports", "ReporMetatId");
            AddForeignKey("dbo.Reports", "ReporMetatId", "dbo.ReportMetas", "ReportId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reports", "ReporMetatId", "dbo.ReportMetas");
            DropIndex("dbo.Reports", new[] { "ReporMetatId" });
            DropPrimaryKey("dbo.ReportMetas");
            AlterColumn("dbo.ReportMetas", "ReportId", c => c.Int(nullable: false));
            DropColumn("dbo.Reports", "ReporMetatId");
            AddPrimaryKey("dbo.ReportMetas", "ReportId");
            CreateIndex("dbo.ReportMetas", "ReportId");
            AddForeignKey("dbo.ReportMetas", "ReportId", "dbo.Reports", "ReportId");
        }
    }
}
