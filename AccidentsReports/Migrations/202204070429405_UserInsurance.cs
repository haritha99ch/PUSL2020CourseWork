namespace AccidentsReports.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserInsurance : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Insurances", "InsuranceNIC");
            AddForeignKey("dbo.Insurances", "InsuranceNIC", "dbo.Users", "NIC", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Insurances", "InsuranceNIC", "dbo.Users");
            DropIndex("dbo.Insurances", new[] { "InsuranceNIC" });
        }
    }
}
