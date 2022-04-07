namespace AccidentsReports.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PoliceReport : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Reports", "ApprovedBy");
            AddForeignKey("dbo.Reports", "ApprovedBy", "dbo.Police", "PoliceId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reports", "ApprovedBy", "dbo.Police");
            DropIndex("dbo.Reports", new[] { "ApprovedBy" });
        }
    }
}
