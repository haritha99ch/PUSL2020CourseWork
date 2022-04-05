using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AccidentsReports.Data.Entities {
    public class Driver {
        [Key]
        public int LicenceNumber { get; set; }
        [ForeignKey("User")]
        public int NIC { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
        public virtual User User { get; set; }
    }
}