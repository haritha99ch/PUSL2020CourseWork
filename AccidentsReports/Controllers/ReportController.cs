using AccidentsReports.Data;
using AccidentsReports.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccidentsReports.Controllers {
    public class ReportController : Controller {
        long currentUser;
        // GET: Report
        public ActionResult Index() {
            currentUser = (long)Session["CurrentUserID"];
            return View();
        }
        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ReportDetail request, List<Vehicle> rVehicles) {
            if(rVehicles != null) {
                @ViewBag.Msg = rVehicles[2].PlateNumber;
            }
            #region ToDo

            //using (var db = new ARDbContext()) {    //By Using Database

            //    //Adding New Vehicle to to Vehicle model
            //    var vehicles = new List<Data.Entities.Vehicle>();
            //    foreach (var vehicle in rVehicles) {
            //        vehicles.Add(new Data.Entities.Vehicle() {
            //            DriverLicence = vehicle.LicenceNumber,
            //            Class = vehicle.Class.ToString(),
            //            ModelName = vehicle.ModelName
            //        });
            //    }

            //    //Adding New Images to to Images model
            //    var images = new List<Data.Entities.Image>();
            //    int count=0;
            //    foreach (var Item in request.Images) {
            //        string fileName=Path.GetFileNameWithoutExtension(Item.ImageFile.ToString());
            //        string fileExtention = Path.GetExtension(Item.ImageFile.ToString());
            //        fileName = $"{currentUser}-{DateTime.Now:O}-{count}.{fileExtention}";
            //        Item.ImagePath = $"~/Content/images/{fileName}";
            //        fileName = Path.Combine(Server.MapPath("~/Content/images/"), fileName);
            //        fileName = Path.Combine(Server.MapPath("~/Content/images/"), fileName);
            //        Item.ImageFile.SaveAs(fileName);
            //        images.Add(new Data.Entities.Image() {
            //            ImagePath = Item.ImagePath
            //        });

            //        count++;
            //    }

            //    //Add the new Report to the Report model
            //    var newReport = new Data.Entities.Report() {
            //        AuthorLicence = db.Drivers.FirstOrDefault(d => d.DriverNIC.Equals(currentUser)).LicenceId,
            //        Vehicles = vehicles,    //Foreign Reference
            //        Images = images  //Foreign Reference
            //    };

            //    //Add the ReportMeta to the ReportMeta model
            //    var reportMeta = new Data.Entities.ReportMeta() {
            //        Title = request.Title,
            //        Cause = request.Cause.ToString(),
            //        DateTime = DateTime.Now,
            //        Description = request.Description,
            //        IsVehicleVehicle = request.IsVehicleVehicle,
            //        IsVehicleProperty = request.IsVehicleProperty,
            //        IsVehiclePedestrian = request.IsVehiclePedestrian,
            //        Latitude = request.Latitude,
            //        Longitude = request.Longitude,
            //        Scale = request.Scale,
            //        Report = newReport  //Foreign Reference
            //    };
            //    db.ReportMetas.Add(reportMeta); //Adding just reportMeta will automatically add all other entities by using reverse references
            //    db.SaveChanges();

            //}

            #endregion
            return View();
        }

        public PartialViewResult NewVehicle() {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult NewVehicle(Vehicle vehicle) {
            ViewBag.Added = true;
            return PartialView();
        }

        public PartialViewResult NewImage() {

            return PartialView();
        }

    }
}