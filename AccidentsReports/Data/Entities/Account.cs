using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AccidentsReports.Data.Entities {
    public class Account {
        [Key]
        public int UserId { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [StringLength(20)]
        public string Password { get; set; }
        [Required]
        public bool IsDriver { get; set; }
        [Required]
        public bool IsPolice { get; set; }
        [Required]
        public bool IsInsurance { get; set; }
        [Required]
        public bool IsRDA { get; set; }
        public int? ProfilePic { get; set; }


        [ForeignKey("UserId")]
        public User User { get; set; }
        [ForeignKey("ProfilePic")]
        public Image Image { get; set; }
    }
}