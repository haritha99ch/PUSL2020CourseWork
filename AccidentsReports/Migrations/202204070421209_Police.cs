namespace AccidentsReports.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Police : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Police",
                c => new
                    {
                        PoliceId = c.Int(nullable: false),
                        PoliceNIC = c.Int(nullable: false),
                        PoliceDomain = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.PoliceId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Police");
        }
    }
}
