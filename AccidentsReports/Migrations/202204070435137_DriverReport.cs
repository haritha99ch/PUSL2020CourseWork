namespace AccidentsReports.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DriverReport : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Reports", "AuthorLicence");
            AddForeignKey("dbo.Reports", "AuthorLicence", "dbo.Drivers", "LicenceId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reports", "AuthorLicence", "dbo.Drivers");
            DropIndex("dbo.Reports", new[] { "AuthorLicence" });
        }
    }
}
