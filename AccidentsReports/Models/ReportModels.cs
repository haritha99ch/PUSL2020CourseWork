using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AccidentsReports.Models {

    public enum Cause {
        Distraction,
        Dunk,
        Dizzyness,
        [Display(Name ="High Speed")]HighSpeed,
        [Display(Name ="Bad Weather")]BadWeather
    }

    public class Report {
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public long Author { get; set; }
        public DateTime DatetTime { get; set; }
        [Required]
        [StringLength(20)]
        public string City { get; set; }
        [Required]
        [Range(0, 100, ErrorMessage = "Please Enter a valid number")]
        public int No { get; set; }
        [Required]
        [StringLength(20)]
        public string Streat1 { get; set; }
        [StringLength(20)]
        public string Streat2 { get; set; }
        [StringLength(20)]
        public string Streat3 { get; set; }
        [Required]
        public Cause Cause { get; set; }
        public long? ApprovedBy { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }
        [Required]
        [Range(0, 5, ErrorMessage ="Scale is upto 5")]
        public int Scale { get; set; }
        public string ImagePath { get; set; }
        public string Status { get; set; }
    }
    public class ReportDetail:Report {
        [Required]
        public List<Vehicle> Vehicles { get; set; }
        [Required]
        [Display(Name = "Vehicle With Vehicle")]
        public bool IsVehicleVehicle { get; set; }
        [Required]
        [Display(Name = "Vehicle With Property")]
        public bool IsVehicleProperty { get; set; }
        [Required]
        [Display(Name = "Vehicle With Pedestrian")]
        public bool IsVehiclePedestrian { get; set; }
        public float Damage { get; set; }
        public long DamageEstimatedBy { get; set; }
        public long ClaimedBy { get; set; }
        public List<Image> Images { get; set; }
    }
}