namespace AccidentsReports.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserDriver : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drivers", "DriverNIC", c => c.Int(nullable: false));
            CreateIndex("dbo.Drivers", "DriverNIC");
            AddForeignKey("dbo.Drivers", "DriverNIC", "dbo.Users", "NIC", cascadeDelete: true);
            DropColumn("dbo.Drivers", "UserNIC");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Drivers", "UserNIC", c => c.Int(nullable: false));
            DropForeignKey("dbo.Drivers", "DriverNIC", "dbo.Users");
            DropIndex("dbo.Drivers", new[] { "DriverNIC" });
            DropColumn("dbo.Drivers", "DriverNIC");
        }
    }
}
