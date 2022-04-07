namespace AccidentsReports.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RDAReport : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Reports", "DamageEstimatedBy");
            AddForeignKey("dbo.Reports", "DamageEstimatedBy", "dbo.RDAs", "EmpId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reports", "DamageEstimatedBy", "dbo.RDAs");
            DropIndex("dbo.Reports", new[] { "DamageEstimatedBy" });
        }
    }
}
