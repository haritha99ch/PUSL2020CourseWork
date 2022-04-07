using AccidentsReports.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AccidentsReports.Data {
    public class ARDbContext:DbContext {
        public ARDbContext() : base("ARDbContext") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Police> Polices { get; set; }
        public DbSet<RDA> RDAs { get; set; }
        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<ReportMeta> ReportMetas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
        }
    }
}