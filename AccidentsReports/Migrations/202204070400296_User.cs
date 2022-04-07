namespace AccidentsReports.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        NIC = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Gender = c.String(nullable: false, maxLength: 6),
                        Age = c.Int(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        Address = c.String(nullable: false, maxLength: 200),
                        PhoneNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NIC);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
