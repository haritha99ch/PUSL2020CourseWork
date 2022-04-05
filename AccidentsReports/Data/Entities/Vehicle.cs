using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AccidentsReports.Data.Entities {
    public class Vehicle {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PlateNumber { get; set; }
        public string? ModelNumber { get; set; }
        public string? ModelName { get; set; }
        [Required]
        public string Type { get; set; }
    }
}