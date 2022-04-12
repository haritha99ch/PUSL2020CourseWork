using AccidentsReports.Data;
using AccidentsReports.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AccidentsReports.Controllers {
    [Authorize]
    public class ReportController : Controller {
        long currentUser = 1234567890;
        // GET: Report
        public ActionResult Index() {
            currentUser = 1234567890;
            return View();
        }
        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ReportDetail request) {
            var errors = new List<string>();
            //Partial view model validation
            if (request.Vehicles == null) {
                errors.Add("There has to be atlest one Vehicle");
            }
            if (request.Images == null) {
                errors.Add("There has to be atlest one Photo");
            }
            if (errors.Count() > 0) {
                ViewBag.Errors = errors;
                return View();
            }

            using (var db = new ARDbContext()) {    //Accesseing the database using Entity Framework
                //Table: Vehicles
                var Vehicles = new List<Data.Entities.Vehicle>();
                var exisitingVehicles = new List<Vehicle>();
                foreach (var vehicle in request.Vehicles) {
                    bool exisits = db.Vehicles.Any(v => v.PlateNumber.Equals(vehicle.PlateNumber));
                    if (!exisits) {
                        var Vehicle = new Data.Entities.Vehicle() {
                            PlateNumber = vehicle.PlateNumber,
                            Class = vehicle.Class.ToString(),
                            ModelName = vehicle.ModelName,
                        };
                        Vehicles.Add(Vehicle);
                    }
                    else {
                        exisitingVehicles.Add(vehicle);
                    }
                }
                //Table: Images
                var Images = new List<Data.Entities.Image>();
                foreach (var image in request.Images.Select((value, index) => new {value, index})) {    //Projection: Accessing the index value of selected item in the list
                    string fileExt = Path.GetExtension(image.value.ImageFile.FileName);
                    string fileName = $"{currentUser}-{image.index}{DateTime.Now:yyyy-dd-M--HH-mm-ss}.{fileExt}";   //Giving a new file name and using Date time and a counter to-
                    string serverLocation = Server.MapPath("~/Content/images/");    //Assigning server location.    //-avoid duplications
                    string path = Path.Combine(serverLocation, fileName);
                    image.value.ImageFile.SaveAs(path);     //Saving the file in the server
                    var Image = new Data.Entities.Image() {
                        ImagePath = fileName    //Adding the image server location in the database.
                    };
                    Images.Add(Image);
                }
                //Table: ReportMetas
                var ReportDetails = new Data.Entities.ReportMeta() {
                    DateTime = DateTime.Now,
                    Title = request.Title,
                    Cause = request.Cause.ToString(),
                    Description = request.Description,
                    City = request.City,
                    No = request.No,
                    Street1 = request.Streat1,
                    Street2 = request.Streat2,
                    Street3 = request.Streat3,
                    IsVehiclePedestrian = request.IsVehiclePedestrian,
                    IsVehicleProperty = request.IsVehicleProperty,
                    IsVehicleVehicle=request.IsVehicleVehicle,
                    Scale = request.Scale
                };
                //Table: Reprts
                var Report = new Data.Entities.Report() {
                    AuthorLicence = db.Drivers.Single(d => d.DriverNIC.Equals(currentUser)).LicenceId,
                    Images = Images,    //Reference: Table Images
                    Vehicles=Vehicles,  //Reference: Table Vehicles
                    ReportMeta = ReportDetails, //Reference: Table ReportMeta
                    Status = "Pending"
                };
                db.Reports.Add(Report); //Adding just Report will automatically insert the other tables that are refred through foreign references
                db.SaveChanges();   //Saving changes to the database.
            }
            return View();
        }

        public PartialViewResult NewVehicle() {
            Session["VehicleCount"] = (int)Session["VehicleCount"] + 1;
            return PartialView();
        }

        public PartialViewResult NewImage() {
            Session["PhotoCount"] = (int)Session["PhotoCount"] + 1;
            return PartialView();
        }
    }
}