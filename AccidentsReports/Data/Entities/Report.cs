﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AccidentsReports.Data.Entities {
    public class Report {
        [Key]
        public int ReportId { get; set; }
        public int AuthorLicence { get; set; }
        public int? ApprovedBy { get; set; }
        public string Status { get; set; }
        public int? DamageEstimatedBy { get; set; }
        public float Damage { get; set; }
        public int? CalimedBy { get; set; }



        [ForeignKey("AuthorLicence")]
        public Driver Driver { get; set; }
        [ForeignKey("ApprovedBy")]
        public Police Police { get; set; }
        [ForeignKey("DamageEstimatedBy")]
        public RDA RDA { get; set; }
        [ForeignKey("CalimedBy")]
        public Insurance Insurance { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
        public ICollection<Image> Images { get; set; }
    }
}