namespace AccidentsReports.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserPolice : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Police", "PoliceNIC");
            AddForeignKey("dbo.Police", "PoliceNIC", "dbo.Users", "NIC", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Police", "PoliceNIC", "dbo.Users");
            DropIndex("dbo.Police", new[] { "PoliceNIC" });
        }
    }
}
