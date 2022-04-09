using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AccidentsReports.Models {
    public abstract class Report {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public long Author { get; set; }
        [Required]
        public DateTime DatetTime { get; set; }
        [Required]
        public float Latitude { get; set; }
        [Required]
        public float Longitude { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Cause { get; set; }
        [Required]
        public List<string> VehicleClasses { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Scale { get; set; }
        public string ImagePath { get; set; }
        public string Status { get; set; }
    }
    public class ReportDetail:Report {
        public List<Vehicle> Vehicles { get; set; }
        [Required]
        public bool IsVehicleVehicle { get; set; }
        [Required]
        public bool IsVehicleProperty { get; set; }
        [Required]
        public bool IsVehiclePedestrian { get; set; }
        [Required]
        public float Damage { get; set; }
        public long ApprovedBy { get; set; }
        public long DamageEstimatedBy { get; set; }
        public long ClaimedBy { get; set; }
        public List<string> ImagePaths { get; set; }
    }
}