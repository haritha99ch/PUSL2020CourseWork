namespace AccidentsReports.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DamgeAllowNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reports", "Damage", c => c.Single());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reports", "Damage", c => c.Single(nullable: false));
        }
    }
}
