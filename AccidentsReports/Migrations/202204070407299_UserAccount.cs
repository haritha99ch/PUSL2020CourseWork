namespace AccidentsReports.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserAccount : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Accounts");
            AlterColumn("dbo.Accounts", "UserId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Accounts", "UserId");
            CreateIndex("dbo.Accounts", "UserId");
            AddForeignKey("dbo.Accounts", "UserId", "dbo.Users", "NIC");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accounts", "UserId", "dbo.Users");
            DropIndex("dbo.Accounts", new[] { "UserId" });
            DropPrimaryKey("dbo.Accounts");
            AlterColumn("dbo.Accounts", "UserId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Accounts", "UserId");
        }
    }
}
