using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AccidentsReports.Models {
    public enum Service {
        Excelent,
        Good,
        Neutral,
        Poor
    }
    public class AboutUs {
        [Required]
        [Display(Name = "How satisfied were you with our Service?")]
        public Service Service { get; set; }
        [Required]
        [Display(Name = "Feedback")]
        [StringLength(200)]
        public string Feedback { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name ="Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name="Email")]
        [EmailAddress]
        public string Email { get; set; }
    }
}