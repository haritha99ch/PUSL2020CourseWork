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
        [StringLength(20)]
        public string City { get; set; }
        [Required]
        public int No { get; set; }
        [Required]
        [StringLength(20)]
        public string Street1 { get; set; }
        [StringLength(20)]
        public string Street2 { get; set; }
        [StringLength(20)]
        public string Street3 { get; set; }
        [Required]
        [StringLength(20)]
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



    }
}