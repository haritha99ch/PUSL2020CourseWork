using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AccidentsReports.Data.Entities {
    public class User {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NIC { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public int PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }
    }
}