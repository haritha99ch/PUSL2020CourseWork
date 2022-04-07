using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AccidentsReports.Data.Entities {
    public class Image {
        [Key]
        public int ImageId { get; set; }
        [Required]
        [StringLength(100)]
        public string ImagePath { get; set; }
        public int? ReportId { get; set; }


        [ForeignKey("ReportId")]
        public Report Report { get; set; }
    }
}