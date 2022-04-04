using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccidentsReports.Models {
    public class ReportModels {
    }
    public abstract class Report {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public float DamageScale { get; set; }
        public string ImagePath { get; set; }
    }
    public class ReportDetail:Report {
        public string Cause { get; set; }
        public string ApprovedBy { get; set; }
        public string DamageEstimatedBy { get; set; }
        public string ClaimedBy { get; set; }
        public List<string> ImagePaths { get; set; }
    }
}