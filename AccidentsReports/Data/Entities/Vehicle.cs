using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AccidentsReports.Data.Entities {
    public class Vehicle {
        [Key]
        [StringLength(20)]
        public string PlateNumber { get; set; }
        public int? DriverLicence { get; set; }
        [StringLength(20)]
        public string ModelName { get; set; }
        [Required]
        [StringLength(20)]
        public string Class { get; set; }
        

        [ForeignKey("DriverLicence")]
        public Driver Driver { get; set; }
        public ICollection<Report> Reports { get; set; }
    }
}