using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AccidentsReports.Data.Entities {
    public class ReportMeta {
        [Key]
        public int ReportId { get; set; }
        [Required]
        [StringLength(20)]
        public string Title { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        public float Latitude { get; set; }
        [Required]
        public float Longitude { get; set; }
        [Required]
        [StringLength(10)]
        public string Cause { get; set; }
        [Required]
        public bool IsVehicleVehicle { get; set; }
        [Required]
        public bool IsVehicleProperty { get; set; }
        [Required]
        public bool IsVehiclePedestrian { get; set; }
        [Required]
        public int Scale { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }


        [ForeignKey("ReportId")]
        public Report Report { get; set; }
    }
}