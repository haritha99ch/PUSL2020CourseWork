using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AccidentsReports.Models {
    public class Vehicle {
        [Required]
        [Display(Name ="Plate Number")]
        public int PlateNumber { get; set; }
        [Display(Name = "Model Number")]
        public string? ModelNumber { get; set; }
        [Display(Name = "Model Name")]
        public string? ModelName { get; set; }
        [Required]
        [Display(Name = "Vehicle Type")]
        public string Type { get; set; }
        [Display(Name = "Licence Number")]
        public int? LicenceNumber { get; set; }
    }
}