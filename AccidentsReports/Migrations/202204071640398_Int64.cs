namespace AccidentsReports.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Int64 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reports", "AuthorLicence", "dbo.Drivers");
            DropForeignKey("dbo.Vehicles", "DriverLicence", "dbo.Drivers");
            DropForeignKey("dbo.Reports", "CalimedBy", "dbo.Insurances");
            DropForeignKey("dbo.Insurances", "InsuranceNIC", "dbo.Users");
            DropForeignKey("dbo.Police", "PoliceNIC", "dbo.Users");
            DropForeignKey("dbo.RDAs", "RDANIC", "dbo.Users");
            DropForeignKey("dbo.Drivers", "DriverNIC", "dbo.Users");
            DropForeignKey("dbo.Reports", "ApprovedBy", "dbo.Police");
            DropForeignKey("dbo.Reports", "DamageEstimatedBy", "dbo.RDAs");
            DropIndex("dbo.Drivers", new[] { "DriverNIC" });
            DropIndex("dbo.Reports", new[] { "AuthorLicence" });
            DropIndex("dbo.Reports", new[] { "ApprovedBy" });
            DropIndex("dbo.Reports", new[] { "DamageEstimatedBy" });
            DropIndex("dbo.Reports", new[] { "CalimedBy" });
            DropIndex("dbo.Insurances", new[] { "InsuranceNIC" });
            DropIndex("dbo.Police", new[] { "PoliceNIC" });
            DropIndex("dbo.RDAs", new[] { "RDANIC" });
            DropIndex("dbo.Vehicles", new[] { "DriverLicence" });
            DropPrimaryKey("dbo.Drivers");
            DropPrimaryKey("dbo.Insurances");
            DropPrimaryKey("dbo.Users");
            DropPrimaryKey("dbo.Police");
            DropPrimaryKey("dbo.RDAs");
            AlterColumn("dbo.Drivers", "LicenceId", c => c.Long(nullable: false));
            AlterColumn("dbo.Drivers", "DriverNIC", c => c.Long(nullable: false));
            AlterColumn("dbo.Reports", "AuthorLicence", c => c.Long(nullable: false));
            AlterColumn("dbo.Reports", "ApprovedBy", c => c.Long());
            AlterColumn("dbo.Reports", "DamageEstimatedBy", c => c.Long());
            AlterColumn("dbo.Reports", "CalimedBy", c => c.Long());
            AlterColumn("dbo.Insurances", "EmpId", c => c.Long(nullable: false));
            AlterColumn("dbo.Insurances", "InsuranceNIC", c => c.Long(nullable: false));
            AlterColumn("dbo.Users", "NIC", c => c.Long(nullable: false));
            AlterColumn("dbo.Police", "PoliceId", c => c.Long(nullable: false));
            AlterColumn("dbo.Police", "PoliceNIC", c => c.Long(nullable: false));
            AlterColumn("dbo.RDAs", "EmpId", c => c.Long(nullable: false));
            AlterColumn("dbo.RDAs", "RDANIC", c => c.Long(nullable: false));
            AlterColumn("dbo.Vehicles", "DriverLicence", c => c.Long());
            AddPrimaryKey("dbo.Drivers", "LicenceId");
            AddPrimaryKey("dbo.Insurances", "EmpId");
            AddPrimaryKey("dbo.Users", "NIC");
            AddPrimaryKey("dbo.Police", "PoliceId");
            AddPrimaryKey("dbo.RDAs", "EmpId");
            CreateIndex("dbo.Drivers", "DriverNIC");
            CreateIndex("dbo.Reports", "AuthorLicence");
            CreateIndex("dbo.Reports", "ApprovedBy");
            CreateIndex("dbo.Reports", "DamageEstimatedBy");
            CreateIndex("dbo.Reports", "CalimedBy");
            CreateIndex("dbo.Insurances", "InsuranceNIC");
            CreateIndex("dbo.Police", "PoliceNIC");
            CreateIndex("dbo.RDAs", "RDANIC");
            CreateIndex("dbo.Vehicles", "DriverLicence");
            AddForeignKey("dbo.Reports", "AuthorLicence", "dbo.Drivers", "LicenceId", cascadeDelete: true);
            AddForeignKey("dbo.Vehicles", "DriverLicence", "dbo.Drivers", "LicenceId");
            AddForeignKey("dbo.Reports", "CalimedBy", "dbo.Insurances", "EmpId");
            AddForeignKey("dbo.Insurances", "InsuranceNIC", "dbo.Users", "NIC", cascadeDelete: true);
            AddForeignKey("dbo.Police", "PoliceNIC", "dbo.Users", "NIC", cascadeDelete: true);
            AddForeignKey("dbo.RDAs", "RDANIC", "dbo.Users", "NIC", cascadeDelete: true);
            AddForeignKey("dbo.Drivers", "DriverNIC", "dbo.Users", "NIC", cascadeDelete: true);
            AddForeignKey("dbo.Reports", "ApprovedBy", "dbo.Police", "PoliceId");
            AddForeignKey("dbo.Reports", "DamageEstimatedBy", "dbo.RDAs", "EmpId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reports", "DamageEstimatedBy", "dbo.RDAs");
            DropForeignKey("dbo.Reports", "ApprovedBy", "dbo.Police");
            DropForeignKey("dbo.Drivers", "DriverNIC", "dbo.Users");
            DropForeignKey("dbo.RDAs", "RDANIC", "dbo.Users");
            DropForeignKey("dbo.Police", "PoliceNIC", "dbo.Users");
            DropForeignKey("dbo.Insurances", "InsuranceNIC", "dbo.Users");
            DropForeignKey("dbo.Reports", "CalimedBy", "dbo.Insurances");
            DropForeignKey("dbo.Vehicles", "DriverLicence", "dbo.Drivers");
            DropForeignKey("dbo.Reports", "AuthorLicence", "dbo.Drivers");
            DropIndex("dbo.Vehicles", new[] { "DriverLicence" });
            DropIndex("dbo.RDAs", new[] { "RDANIC" });
            DropIndex("dbo.Police", new[] { "PoliceNIC" });
            DropIndex("dbo.Insurances", new[] { "InsuranceNIC" });
            DropIndex("dbo.Reports", new[] { "CalimedBy" });
            DropIndex("dbo.Reports", new[] { "DamageEstimatedBy" });
            DropIndex("dbo.Reports", new[] { "ApprovedBy" });
            DropIndex("dbo.Reports", new[] { "AuthorLicence" });
            DropIndex("dbo.Drivers", new[] { "DriverNIC" });
            DropPrimaryKey("dbo.RDAs");
            DropPrimaryKey("dbo.Police");
            DropPrimaryKey("dbo.Users");
            DropPrimaryKey("dbo.Insurances");
            DropPrimaryKey("dbo.Drivers");
            AlterColumn("dbo.Vehicles", "DriverLicence", c => c.Int());
            AlterColumn("dbo.RDAs", "RDANIC", c => c.Int(nullable: false));
            AlterColumn("dbo.RDAs", "EmpId", c => c.Int(nullable: false));
            AlterColumn("dbo.Police", "PoliceNIC", c => c.Int(nullable: false));
            AlterColumn("dbo.Police", "PoliceId", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "NIC", c => c.Int(nullable: false));
            AlterColumn("dbo.Insurances", "InsuranceNIC", c => c.Int(nullable: false));
            AlterColumn("dbo.Insurances", "EmpId", c => c.Int(nullable: false));
            AlterColumn("dbo.Reports", "CalimedBy", c => c.Int());
            AlterColumn("dbo.Reports", "DamageEstimatedBy", c => c.Int());
            AlterColumn("dbo.Reports", "ApprovedBy", c => c.Int());
            AlterColumn("dbo.Reports", "AuthorLicence", c => c.Int(nullable: false));
            AlterColumn("dbo.Drivers", "DriverNIC", c => c.Int(nullable: false));
            AlterColumn("dbo.Drivers", "LicenceId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.RDAs", "EmpId");
            AddPrimaryKey("dbo.Police", "PoliceId");
            AddPrimaryKey("dbo.Users", "NIC");
            AddPrimaryKey("dbo.Insurances", "EmpId");
            AddPrimaryKey("dbo.Drivers", "LicenceId");
            CreateIndex("dbo.Vehicles", "DriverLicence");
            CreateIndex("dbo.RDAs", "RDANIC");
            CreateIndex("dbo.Police", "PoliceNIC");
            CreateIndex("dbo.Insurances", "InsuranceNIC");
            CreateIndex("dbo.Reports", "CalimedBy");
            CreateIndex("dbo.Reports", "DamageEstimatedBy");
            CreateIndex("dbo.Reports", "ApprovedBy");
            CreateIndex("dbo.Reports", "AuthorLicence");
            CreateIndex("dbo.Drivers", "DriverNIC");
            AddForeignKey("dbo.Reports", "DamageEstimatedBy", "dbo.RDAs", "EmpId");
            AddForeignKey("dbo.Reports", "ApprovedBy", "dbo.Police", "PoliceId");
            AddForeignKey("dbo.Drivers", "DriverNIC", "dbo.Users", "NIC", cascadeDelete: true);
            AddForeignKey("dbo.RDAs", "RDANIC", "dbo.Users", "NIC", cascadeDelete: true);
            AddForeignKey("dbo.Police", "PoliceNIC", "dbo.Users", "NIC", cascadeDelete: true);
            AddForeignKey("dbo.Insurances", "InsuranceNIC", "dbo.Users", "NIC", cascadeDelete: true);
            AddForeignKey("dbo.Reports", "CalimedBy", "dbo.Insurances", "EmpId");
            AddForeignKey("dbo.Vehicles", "DriverLicence", "dbo.Drivers", "LicenceId");
            AddForeignKey("dbo.Reports", "AuthorLicence", "dbo.Drivers", "LicenceId", cascadeDelete: true);
        }
    }
}
