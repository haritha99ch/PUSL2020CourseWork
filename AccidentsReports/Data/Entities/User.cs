using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AccidentsReports.Data.Entities {
    public class User {
        [Key]
        public int NIC { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public int Age { get; private set; }
        [Required]
        public DateTime DOB {
            get => DOB;
            set {
                Age=DateTime.Now.Year - value.Year;
                DOB=value;
            }
        }
        [Required]
        public int PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }
    }
}