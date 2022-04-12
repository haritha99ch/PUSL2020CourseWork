using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AccidentsReports.Models {
    public class Image {
        public int Id { get; set; }
        [Display(Name ="Add an Image")]
        public string ImagePath { get; set; }
        [Required]
        [Display(Name ="Upload Photo")]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}