namespace AccidentsReports.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsuranceReport : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Reports", "CalimedBy");
            AddForeignKey("dbo.Reports", "CalimedBy", "dbo.Insurances", "EmpId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reports", "CalimedBy", "dbo.Insurances");
            DropIndex("dbo.Reports", new[] { "CalimedBy" });
        }
    }
}
