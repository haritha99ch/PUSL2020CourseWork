using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AccidentsReports.Data.Entities {
    public class Vehicle {
        [Key]
        public int PlateNumber { get; set; }
        public string? ModelNumber { get; set; }
        public string? ModelName { get; set; }
        [Required]
        public string Type { get; set; }
    }
}