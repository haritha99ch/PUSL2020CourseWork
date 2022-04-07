namespace AccidentsReports.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Report : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        ReportId = c.Int(nullable: false, identity: true),
                        AuthorLicence = c.Int(nullable: false),
                        ApprovedBy = c.Int(),
                        Status = c.String(),
                        CalimedBy = c.Int(),
                        DamageEstimatedBy = c.Int(),
                        Damage = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ReportId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Reports");
        }
    }
}
