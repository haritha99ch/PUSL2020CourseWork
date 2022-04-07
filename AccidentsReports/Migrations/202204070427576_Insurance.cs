namespace AccidentsReports.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Insurance : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Insurances",
                c => new
                    {
                        EmpId = c.Int(nullable: false),
                        InsuranceNIC = c.Int(nullable: false),
                        Company = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.EmpId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Insurances");
        }
    }
}
