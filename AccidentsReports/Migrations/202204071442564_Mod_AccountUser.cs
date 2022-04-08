namespace AccidentsReports.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mod_AccountUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Accounts", "UserId", "dbo.Users");
            DropIndex("dbo.Accounts", new[] { "UserId" });
            DropPrimaryKey("dbo.Accounts");
            AddColumn("dbo.Users", "AccountEmail", c => c.String(maxLength: 100));
            AddPrimaryKey("dbo.Accounts", "Email");
            CreateIndex("dbo.Users", "AccountEmail");
            AddForeignKey("dbo.Users", "AccountEmail", "dbo.Accounts", "Email");
            DropColumn("dbo.Accounts", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Accounts", "UserId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Users", "AccountEmail", "dbo.Accounts");
            DropIndex("dbo.Users", new[] { "AccountEmail" });
            DropPrimaryKey("dbo.Accounts");
            DropColumn("dbo.Users", "AccountEmail");
            AddPrimaryKey("dbo.Accounts", "UserId");
            CreateIndex("dbo.Accounts", "UserId");
            AddForeignKey("dbo.Accounts", "UserId", "dbo.Users", "NIC");
        }
    }
}
