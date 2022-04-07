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
        public string? ModelName { get; set; }
        [Required]
        [Display(Name = "Vehicle Class")]
        public string Class { get; set; }
        [Display(Name = "Licence Number")]
        public int? LicenceNumber { get; set; }
    }
}