namespace AccidentsReports.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Driver : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        LicenceId = c.Int(nullable: false),
                        UserNIC = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LicenceId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Drivers");
        }
    }
}
