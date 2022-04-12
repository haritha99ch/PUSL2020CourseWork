namespace AccidentsReports.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CauseStrignLen : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ReportMetas", "Cause", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ReportMetas", "Cause", c => c.String(nullable: false, maxLength: 10));
        }
    }
}
