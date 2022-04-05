using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AccidentsReports.Data.Entities {
    public class RDA {
        [Key]
        public int EmployeeId { get; set; }
        [ForeignKey("User")]
        public int NIC { get; set; }
        [Required]
        public string RDADomain { get; set; }
        public virtual User User { get; set; }
    }
}