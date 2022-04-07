namespace AccidentsReports.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AccountImage : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Accounts", "ProfilePic");
            AddForeignKey("dbo.Accounts", "ProfilePic", "dbo.Images", "ImageId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accounts", "ProfilePic", "dbo.Images");
            DropIndex("dbo.Accounts", new[] { "ProfilePic" });
        }
    }
}
