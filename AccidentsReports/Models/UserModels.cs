using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AccidentsReports.Models {
    public enum Gender {
        Male,
        Female,
    }

    public abstract class User : Account {
        [Required]
        [Display(Name = "NIC Number")]
        [Range(0, 999999999999, ErrorMessage = "Please Enter a Valid NIC Number")]
        public long NIC { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Maximum Length 50")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Maximum Length 50")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Gender")]
        public Gender Gender { get; set; }
        public int Age { get; private set; }
        private DateTime _DOB { get; set; }
        [Required]
        [Display(Name = "Date Of Birth")]
        public DateTime DOB {
            get => _DOB;
            set {
                _DOB = value;
                Age = DateTime.Now.Year - value.Year;
            }
        }
        [Required]
        [StringLength(200, ErrorMessage = "Maximum Length 200")]
        public string Address { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        [Range(0, 0999999999, ErrorMessage = "Please Enter a Valid Phone Number")]
        public int PhoneNumber { get; set; }
        [Required]
        [Display(Name = "SignUp As")]
        public List<Report>? Reports { get; set; }
    }

    public class Driver : User {
        [Required]
        [Display(Name = "Licence Number")]
        [Range(0, long.MaxValue, ErrorMessage = "Please Enter a Valid Licence Number")]
        public long LicenceNumber { get; set; }
        public List<Vehicle> Vehicles { get; set; }
    }

    public class Police : User {
        [Required]
        [Display(Name = "Police Id")]
        [Range(0, long.MaxValue, ErrorMessage = "Please Enter a Valid PoliceId")]
        public long PoliceId { get; set; }
        [Required]
        [Display(Name = "Police Domain")]
        public string Domain { get; set; }
    }

    public class RDA : User {
        [Required]
        [Display(Name = "Employee Number")]
        [Range(0, long.MaxValue, ErrorMessage = "Please Enter a Valid EmployeeId")]
        public long EmployeeId { get; set; }
        [Required]
        [Display(Name = "RDA Domain")]
        public string Domain { get; set; }
    }

    public class Insurance : User {
        [Required]
        [Display(Name = "Employee Number")]
        [Range(0, long.MaxValue, ErrorMessage = "Please Enter a Valid EmployeeId")]
        public long EmployeeId { get; set; }
        [Required]
        [Display(Name = "Company Name")]
        public string Company { get; set; }
    }
}