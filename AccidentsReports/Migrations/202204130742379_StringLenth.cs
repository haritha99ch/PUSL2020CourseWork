namespace AccidentsReports.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StringLenth : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ReportMetas", "Description", c => c.String(nullable: false, maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ReportMetas", "Description", c => c.String(nullable: false, maxLength: 500));
        }
    }
}
