using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AccidentsReports.Models {
    public class Account {
        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        [Required]
        [MinLength(8, ErrorMessage = "Password Minimum Length 8")]
        [MaxLength(20, ErrorMessage = "Password Maximum Length 20")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name ="Re-Enter Password")]
        [Compare("Password", ErrorMessage ="Passwords Did Not Match")]
        public string RePassword { get; set; }
        public Image? Image { get; set; }
    }
}