using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AccidentsReports.Models {
    public abstract class User {
        [Required]
        [Display(Name ="NIC Number")]
        public int Id { get; set; }
        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        public string Gender { get; set; }
        private int _age { get; set; }
        public int Age {
            get {
                return _age;
            }
        }
        private DateTime _dOB { get; set; }
        [Required]
        [Display(Name = "Date Of Birth")]
        public DateTime DOB {
            get => _dOB;
            set {
                _dOB = value;
                _age = DateTime.Now.Year - value.Year;
            }
        }
        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        public int PhoneNumber { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }
        //TODO: public List<Report> Reports { get; set; }
    }

    public class Driver:User {
        [Required]
        [Display(Name = "Licence Number")]
        public int LicenceNumber { get; set; }
        //TODO: public List<Vehical> Vehicals { get; set; }
    }

    public class Police:User {
        [Required]
        [Display(Name = "Police Id")]
        public int PoliceId { get; set; }
        [Required]
        [Display(Name = "Police Domain")]
        public string Domain { get; set; }
    }

    public class RDA:User {
        [Required]
        [Display(Name = "Employee Number")]
        public int EmployeeId { get; set; }
        [Required]
        [Display(Name = "RDA Domain")]
        public string Domain { get; set; }
    }

    public class Insurance:User {
        [Required]
        [Display(Name = "Employee Number")]
        public int EmployeeId { get; set; }
        [Required]
        [Display(Name = "Company Name")]
        public string Company { get; set; }
    }
}