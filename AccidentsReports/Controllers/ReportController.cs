using AccidentsReports.Data;
using AccidentsReports.Models;
using System;
using System.Collections.Generic;
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
        public ActionResult Create(ReportDetail request) {
            using (var db = new ARDbContext()) {

                var vehicles = new List<Data.Entities.Vehicle>();
                foreach (var vehicle in request.Vehicles) {
                    vehicles.Add(new Data.Entities.Vehicle() {
                        DriverLicence = vehicle.LicenceNumber,
                        Class = vehicle.Class,
                        ModelName = vehicle.ModelName
                    });
                }

                var images = new List<Data.Entities.Image>();
                int count=0;
                foreach (var Image in request.ImagePaths) {
                    images.Add(new Data.Entities.Image() {
                        ImagePath = $"~/Content/images/reports/{currentUser}-{DateTime.Now.Date}-{count}.png"
                    });
                    count++;
                }

                var newReport = new Data.Entities.Report() {
                    AuthorLicence = db.Drivers.FirstOrDefault(d => d.DriverNIC.Equals(currentUser)).LicenceId,
                    Vehicles = vehicles,
                    Images= images
                };

                var reportMeta = new Data.Entities.ReportMeta() {
                    Title = request.Title,
                    Cause = request.Cause,
                    DateTime = DateTime.Now,
                    Description = request.Description,
                    IsVehicleVehicle = request.IsVehicleVehicle,
                    IsVehicleProperty = request.IsVehicleProperty,
                    IsVehiclePedestrian = request.IsVehiclePedestrian,
                    Latitude = request.Latitude,
                    Longitude = request.Longitude,
                    Scale = request.Scale,
                    Report = newReport
                };

            }
            return View();
        }
    }
}