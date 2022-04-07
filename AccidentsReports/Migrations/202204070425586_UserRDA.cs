namespace AccidentsReports.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserRDA : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.RDAs", "RDANIC");
            AddForeignKey("dbo.RDAs", "RDANIC", "dbo.Users", "NIC", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RDAs", "RDANIC", "dbo.Users");
            DropIndex("dbo.RDAs", new[] { "RDANIC" });
        }
    }
}
