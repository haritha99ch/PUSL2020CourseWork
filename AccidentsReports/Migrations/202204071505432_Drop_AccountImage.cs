namespace AccidentsReports.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Drop_AccountImage : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Accounts", "ProfilePic", "dbo.Images");
            DropIndex("dbo.Accounts", new[] { "ProfilePic" });
            AlterColumn("dbo.Accounts", "ProfilePic", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Accounts", "ProfilePic", c => c.Int());
            CreateIndex("dbo.Accounts", "ProfilePic");
            AddForeignKey("dbo.Accounts", "ProfilePic", "dbo.Images", "ImageId");
        }
    }
}
