using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AccidentsReports.Data.Entities {
    public class Report {
        public int Id { get; set; }
        [ForeignKey("Driver")]
        public int Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float Latitude { get; set; }
        public float Altitude { get; set; }
        public string Category { get; set; }
        [ForeignKey("Police")]
        public int ApprovedBy { get; set; }
        [ForeignKey("RDA")]
        public int EstimatedBy { get; set; }
        [ForeignKey("Insurance")]
        public int ClaimedBy { get; set; }
        public float DamageScale { get; set; }
        public float Damage { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
        public ICollection<Image> Images { get; set; }
        public virtual Driver Driver { get; set; }
        public virtual Police Police { get; set; }
        public virtual RDA RDA { get; set; }
        public virtual Insurance Insurance { get; set; }
    }
}