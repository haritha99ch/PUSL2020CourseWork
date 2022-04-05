namespace AccidentsReports.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        NIC = c.Int(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        ProfilePic = c.Int(),
                    })
                .PrimaryKey(t => t.NIC)
                .ForeignKey("dbo.Images", t => t.ProfilePic)
                .ForeignKey("dbo.Users", t => t.NIC)
                .Index(t => t.NIC)
                .Index(t => t.ProfilePic);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Path = c.String(nullable: false),
                        Report_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Reports", t => t.Report_Id)
                .Index(t => t.Report_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        NIC = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        PhoneNumber = c.Int(nullable: false),
                        Address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.NIC);
            
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        LicenceNumber = c.Int(nullable: false, identity: true),
                        NIC = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LicenceNumber)
                .ForeignKey("dbo.Users", t => t.NIC, cascadeDelete: true)
                .Index(t => t.NIC);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        PlateNumber = c.Int(nullable: false, identity: true),
                        ModelNumber = c.String(),
                        ModelName = c.String(),
                        Type = c.String(nullable: false),
                        Driver_LicenceNumber = c.Int(),
                        Report_Id = c.Int(),
                    })
                .PrimaryKey(t => t.PlateNumber)
                .ForeignKey("dbo.Drivers", t => t.Driver_LicenceNumber)
                .ForeignKey("dbo.Reports", t => t.Report_Id)
                .Index(t => t.Driver_LicenceNumber)
                .Index(t => t.Report_Id);
            
            CreateTable(
                "dbo.Insurances",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        NIC = c.Int(nullable: false),
                        Company = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Users", t => t.NIC, cascadeDelete: true)
                .Index(t => t.NIC);
            
            CreateTable(
                "dbo.Police",
                c => new
                    {
                        PoliceId = c.Int(nullable: false, identity: true),
                        NIC = c.Int(nullable: false),
                        PoliceDomain = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PoliceId)
                .ForeignKey("dbo.Users", t => t.NIC, cascadeDelete: true)
                .Index(t => t.NIC);
            
            CreateTable(
                "dbo.RDAs",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        NIC = c.Int(nullable: false),
                        RDADomain = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Users", t => t.NIC, cascadeDelete: true)
                .Index(t => t.NIC);
            
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Author = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Latitude = c.Single(nullable: false),
                        Longitude = c.Single(nullable: false),
                        Category = c.String(nullable: false),
                        ApprovedBy = c.Int(),
                        EstimatedBy = c.Int(),
                        ClaimedBy = c.Int(),
                        DamageScale = c.Single(),
                        Damage = c.Single(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Drivers", t => t.Author, cascadeDelete: true)
                .ForeignKey("dbo.Insurances", t => t.ClaimedBy)
                .ForeignKey("dbo.Police", t => t.ApprovedBy)
                .ForeignKey("dbo.RDAs", t => t.EstimatedBy)
                .Index(t => t.Author)
                .Index(t => t.ApprovedBy)
                .Index(t => t.EstimatedBy)
                .Index(t => t.ClaimedBy);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "Report_Id", "dbo.Reports");
            DropForeignKey("dbo.Reports", "EstimatedBy", "dbo.RDAs");
            DropForeignKey("dbo.Reports", "ApprovedBy", "dbo.Police");
            DropForeignKey("dbo.Reports", "ClaimedBy", "dbo.Insurances");
            DropForeignKey("dbo.Images", "Report_Id", "dbo.Reports");
            DropForeignKey("dbo.Reports", "Author", "dbo.Drivers");
            DropForeignKey("dbo.RDAs", "NIC", "dbo.Users");
            DropForeignKey("dbo.Police", "NIC", "dbo.Users");
            DropForeignKey("dbo.Insurances", "NIC", "dbo.Users");
            DropForeignKey("dbo.Vehicles", "Driver_LicenceNumber", "dbo.Drivers");
            DropForeignKey("dbo.Drivers", "NIC", "dbo.Users");
            DropForeignKey("dbo.Accounts", "NIC", "dbo.Users");
            DropForeignKey("dbo.Accounts", "ProfilePic", "dbo.Images");
            DropIndex("dbo.Reports", new[] { "ClaimedBy" });
            DropIndex("dbo.Reports", new[] { "EstimatedBy" });
            DropIndex("dbo.Reports", new[] { "ApprovedBy" });
            DropIndex("dbo.Reports", new[] { "Author" });
            DropIndex("dbo.RDAs", new[] { "NIC" });
            DropIndex("dbo.Police", new[] { "NIC" });
            DropIndex("dbo.Insurances", new[] { "NIC" });
            DropIndex("dbo.Vehicles", new[] { "Report_Id" });
            DropIndex("dbo.Vehicles", new[] { "Driver_LicenceNumber" });
            DropIndex("dbo.Drivers", new[] { "NIC" });
            DropIndex("dbo.Images", new[] { "Report_Id" });
            DropIndex("dbo.Accounts", new[] { "ProfilePic" });
            DropIndex("dbo.Accounts", new[] { "NIC" });
            DropTable("dbo.Reports");
            DropTable("dbo.RDAs");
            DropTable("dbo.Police");
            DropTable("dbo.Insurances");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Drivers");
            DropTable("dbo.Users");
            DropTable("dbo.Images");
            DropTable("dbo.Accounts");
        }
    }
}
