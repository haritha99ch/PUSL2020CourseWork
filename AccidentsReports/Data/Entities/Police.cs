﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AccidentsReports.Data.Entities {
    public class Police {
        [Key]
        public int PoliceId { get; set; }
        [ForeignKey("User")]
        public int NIC { get; set; }
        [Required]
        public string PoliceDomain { get; set; }
        public virtual User User { get; set; }
    }
}