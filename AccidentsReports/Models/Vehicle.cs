using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AccidentsReports.Models {

    public enum VehicleClass {
        Car,
        Van,
        Bus,
        Truck,
        SUV,
        [Display(Name ="Heavy Vehicle")]Heavy,
    }

    public class Vehicle {
        [Required]
        [Display(Name ="Plate Number")]
        public int PlateNumber { get; set; }
        [Display(Name = "Model Name")]
        public string? ModelName { get; set; }
        [Required]
        [Display(Name = "Vehicle Class")]
        public VehicleClass Class { get; set; }
        [Display(Name = "Licence Number")]
        public int? LicenceNumber { get; set; }
    }
}