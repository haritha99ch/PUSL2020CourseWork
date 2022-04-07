using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AccidentsReports.Data.Entities {
    public class Driver {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LicenceId { get; set; }
        public int DriverNIC { get; set; }


        [ForeignKey("DriverNIC")]
        public User User { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
        public ICollection<Report> Reports { get; set; }

    }
}