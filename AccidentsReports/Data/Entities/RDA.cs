using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AccidentsReports.Data.Entities {
    public class RDA {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long EmpId { get; set; }
        public long RDANIC { get; set; }
        [Required]
        [StringLength(50)]
        public string RDADomain { get; set; }


        [ForeignKey("RDANIC")]
        public User User { get; set; }
        public ICollection<Report> Reports { get; set; }
    }
}