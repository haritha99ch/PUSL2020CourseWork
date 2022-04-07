using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AccidentsReports.Data.Entities {
    public class Insurance {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmpId { get; set; }
        public int InsuranceNIC { get; set; }
        [Required]
        [StringLength(50)]
        public string Company { get; set; }


        [ForeignKey("InsuranceNIC")]
        public User User { get; set; }
        public ICollection<Report> Reports { get; set; }
    }
}