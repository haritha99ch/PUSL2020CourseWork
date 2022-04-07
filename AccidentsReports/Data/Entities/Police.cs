using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AccidentsReports.Data.Entities {
    public class Police {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PoliceId { get; set; }
        public int PoliceNIC { get; set; }
        [Required]
        [StringLength(100)]
        public string PoliceDomain { get; set; }


        [ForeignKey("PoliceNIC")]
        public User User { get; set; }
        public ICollection<Report> Reports { get; set; }
    }
}