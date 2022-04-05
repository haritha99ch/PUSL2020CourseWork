using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AccidentsReports.Data.Entities {
    public class Account {
        [Key]
        [ForeignKey("User")]
        public int NIC { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [ForeignKey("Image")]
        public int? ProfilePic { get; set; }
        public virtual Image Image { get; set; }
        public virtual User User { get; set; }
    }
}