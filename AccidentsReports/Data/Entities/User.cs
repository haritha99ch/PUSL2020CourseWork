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
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(6)]
        public string Gender { get; set; }
        public int Age { get; private set; }
        private DateTime _DOB { get; set; }
        [Required]
        public DateTime DOB {
            get => _DOB;
            set {
                _DOB = value;
                Age = DateTime.Now.Year - value.Year;
            }
        }
        [Required]
        [StringLength(200)]
        public string Address { get; set; }
        [Required]
        public int PhoneNumber { get; set; }
    }
}