using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AccidentsReports.Data.Entities {
    public class Image {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Path { get; set; }
    }
}