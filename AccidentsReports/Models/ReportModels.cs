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

    public abstract class Report {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public long Author { get; set; }
        public DateTime DatetTime { get; set; }
        [Required]
        public float Latitude { get; set; }
        [Required]
        public float Longitude { get; set; }
        [Required]
        public Cause Cause { get; set; }
        [Required]
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
        public bool IsVehicleVehicle { get; set; }
        [Required]
        public bool IsVehicleProperty { get; set; }
        [Required]
        public bool IsVehiclePedestrian { get; set; }
        public float Damage { get; set; }
        public long ApprovedBy { get; set; }
        public long DamageEstimatedBy { get; set; }
        public long ClaimedBy { get; set; }
        public List<Image> Images { get; set; }
    }
}