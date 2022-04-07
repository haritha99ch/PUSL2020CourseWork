namespace AccidentsReports.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RDA : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RDAs",
                c => new
                    {
                        EmpId = c.Int(nullable: false),
                        RDANIC = c.Int(nullable: false),
                        RDADomain = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.EmpId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RDAs");
        }
    }
}
