using AccidentsReports.Data;
using AccidentsReports.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AccidentsReports.Controllers {
    [Authorize]
    public class ReportController : Controller {
        // GET: Report
        #region Report Feed
        public ActionResult Index() {
            bool IsDriver = false;
            bool IsPolice = false;
            bool IsRDA = false;
            bool IsInsurance = false;
            if (Session["CurrentUserID"] != null) { //To Avoid Anonymouse Null references
                IsDriver = (bool)Session["IsDriver"];
                IsPolice = (bool)Session["IsPolice"];
                IsRDA = (bool)Session["IsRDA"];
                IsInsurance = (bool)Session["IsInsurance"];
            }
            List<ReportDetail> reportList = new List<ReportDetail>();
            List<List<string>> VehicleTypes = new List<List<string>>();
            using (var db = new ARDbContext()) {
                var getReportList = db.Reports  //Getting posts reports with all the other tables related to it
                    .Include(r => r.ReportMeta)
                    .Include(r => r.Vehicles)
                    .Include(r => r.Images)
                    .OrderByDescending(r=>r.ReportMeta.DateTime)
                    .ToList();
                //Reading all the reports
                foreach (var Report in getReportList) {
                    if (Report.ApprovedBy != null || IsPolice) {
                        ReportDetail reportDetail = new ReportDetail() {
                            Id = Report.ReportId,
                            Title = Report.ReportMeta.Title,
                            ImagePath = $"~/Content/images/{db.Images.First(i => i.ReportId == Report.ReportId).ImagePath}",
                            DatetTime = Report.ReportMeta.DateTime,
                            ApprovedBy = Report.ApprovedBy,
                            ClaimedBy=Report.CalimedBy,
                            Description = Report.ReportMeta.Description,
                            City = Report.ReportMeta.City,
                            No = Report.ReportMeta.No,
                            Streat1 = Report.ReportMeta.Street1,
                            Streat2 = Report.ReportMeta.Street2,
                            Streat3 = Report.ReportMeta.Street3,
                            IsVehiclePedestrian = Report.ReportMeta.IsVehiclePedestrian,
                            IsVehicleProperty = Report.ReportMeta.IsVehicleProperty,
                            IsVehicleVehicle = Report.ReportMeta.IsVehicleVehicle,
                            Cause = (Cause)Enum.Parse(typeof(Cause), Report.ReportMeta.Cause),
                            Scale = Report.ReportMeta.Scale,

                        };
                        long AuthorId = db.Drivers.FirstOrDefault(d => d.LicenceId.Equals(Report.AuthorLicence)).DriverNIC;
                        var Names = db.Users.Where(u => u.NIC.Equals(AuthorId)).Select(u => new { u.FirstName, u.LastName });
                        reportDetail.AuthorName = $"{Names.Select(u => u.FirstName).First()} {Names.Select(u => u.LastName).First()}";
                        List<string> vehicleTypes = new List<string>();
                        foreach (var vehicel in Report.Vehicles) {
                            vehicleTypes.Add(vehicel.Class.ToString());
                        }
                        VehicleTypes.Add(vehicleTypes);
                        reportList.Add(reportDetail);
                    }
                }
                ViewBag.VehicleTypes = VehicleTypes;
                return View(reportList);
            }
        }
        #endregion

        #region Item Details view
        #region View logic
        public ActionResult Details(int id) {
            bool IsDriver = false;
            bool IsPolice = false;
            bool IsRDA = false;
            bool IsInsurance = false;
            if (Session["CurrentUserID"] != null) { //To Avoid Anonymouse Null references
                IsDriver = (bool)Session["IsDriver"];
                IsPolice = (bool)Session["IsPolice"];
                IsRDA = (bool)Session["IsRDA"];
                IsInsurance = (bool)Session["IsInsurance"];
            }
            ReportDetail Report;
            using (var db = new ARDbContext()) {
                var getReport = db.Reports
                    .Include(r => r.ReportMeta)
                    .Include(r => r.Vehicles)
                    .Include(r => r.Images)
                    .First(r => r.ReportId.Equals(id));
                Report = new ReportDetail() {
                    Id = getReport.ReportId,
                    Title = getReport.ReportMeta.Title,
                    DatetTime = getReport.ReportMeta.DateTime,
                    ApprovedBy = getReport.ApprovedBy,
                    DamageEstimatedBy=getReport.DamageEstimatedBy,
                    ClaimedBy=getReport.CalimedBy,
                    Description = getReport.ReportMeta.Description,
                    City = getReport.ReportMeta.City,
                    No = getReport.ReportMeta.No,
                    Streat1 = getReport.ReportMeta.Street1,
                    Streat2 = getReport.ReportMeta.Street2,
                    Streat3 = getReport.ReportMeta.Street3,
                    IsVehiclePedestrian = getReport.ReportMeta.IsVehiclePedestrian,
                    IsVehicleProperty = getReport.ReportMeta.IsVehicleProperty,
                    IsVehicleVehicle = getReport.ReportMeta.IsVehicleVehicle,
                    Cause = (Cause)Enum.Parse(typeof(Cause), getReport.ReportMeta.Cause),
                    Scale = getReport.ReportMeta.Scale,
                    Damage = getReport.Damage,
                };
                long AuthorId = db.Drivers.FirstOrDefault(d => d.LicenceId.Equals(getReport.AuthorLicence)).DriverNIC;
                var Names = db.Users.Where(u => u.NIC.Equals(AuthorId)).Select(u => new { u.FirstName, u.LastName });
                Report.AuthorName = $"{Names.Select(u => u.FirstName).First()} {Names.Select(u => u.LastName).First()}";

                List<Vehicle> VehicleList = new List<Vehicle>();
                foreach (var vehicle in getReport.Vehicles) {
                    var Vehicle = new Vehicle() {
                        PlateNumber = vehicle.PlateNumber,
                        Class = (VehicleClass)Enum.Parse(typeof(VehicleClass), vehicle.Class),
                        ModelName = vehicle.ModelName,
                        LicenceNumber = vehicle.DriverLicence
                    };
                    VehicleList.Add(Vehicle);
                }
                Report.Vehicles = VehicleList;

                List<Image> ImagesList = new List<Image>();
                foreach (var image in getReport.Images) {
                    var Image = new Image() {
                        ImagePath = $"~/Content/images/{image.ImagePath}"
                    };
                    ImagesList.Add(Image);
                }
                Report.Images = ImagesList;
                if (Report.ApprovedBy != null) {
                    string FullName;
                    var Data = db.Polices
                        .Where(p => p.PoliceId == Report.ApprovedBy)
                        .Select(p => new {
                            p.User.FirstName,
                            p.User.LastName,
                            p.PoliceDomain
                        });
                    FullName = $"{Data.First().FirstName} {Data.First().LastName}";
                    ViewBag.ApprovedBy = FullName;
                    ViewBag.ApprovedByDomain = Data.First().PoliceDomain;
                }
                if (Report.DamageEstimatedBy!=null) {
                    string FullName;
                    var Data=db.RDAs
                        .Where(r=>r.EmpId == Report.DamageEstimatedBy)
                        .Select(r => new {
                            r.User.FirstName,
                            r.User.LastName,
                            r.RDADomain
                        });
                    FullName = $"{Data.First().FirstName} {Data.First().LastName}";
                    ViewBag.DamageEstimatedBy = FullName;
                    ViewBag.DamageEstimatedByDomain = Data.First().RDADomain;
                }
                if (Report.ClaimedBy!=null) {
                    string FullName;
                    var Data=db.Insurances
                        .Where(i=>i.EmpId == Report.ClaimedBy)
                        .Select(i => new {
                            i.User.FirstName,
                            i.User.LastName,
                            i.Company
                        });
                    FullName = $"{Data.First().FirstName} {Data.First().LastName}";
                    ViewBag.ClaimedBy = FullName;
                    ViewBag.ClaimedByCompany = Data.First().Company;
                }
            }
            return View(Report);
        }
        #endregion
        #region Moderation Logics
        public void Approve(int id) {
            long UserId = (long)Session["CurrentUserID"];
            using (var db = new ARDbContext()) {
                long PoliceId = db.Polices
                    .FirstOrDefault(p => p.PoliceNIC.Equals(UserId)).PoliceId;
                db.Reports
                    .FirstOrDefault(r => r.ReportId.Equals(id))
                    .ApprovedBy = PoliceId;
                db.SaveChanges();
            }
        }
        [HttpPost]
        public ActionResult Estimate(int id, float? damage) {
            long UserId = (long)Session["CurrentUserId"];
            using (var db = new ARDbContext()) {
                long RdaId = db.RDAs
                    .FirstOrDefault(r => r.RDANIC.Equals(UserId)).EmpId;
                var report = db.Reports
                    .FirstOrDefault(r => r.ReportId.Equals(id));
                report.DamageEstimatedBy = RdaId;
                report.Damage = damage;
                db.SaveChanges();
            }
            return RedirectToAction("Details", new {id});
        }
        public void Claim(int id) {
            long UserId = (long)Session["CurrentUserId"];
            using(var db = new ARDbContext()) {
                long InsuranceId = db.Insurances
                    .FirstOrDefault(i => i.InsuranceNIC.Equals(UserId)).EmpId;
                db.Reports
                    .FirstOrDefault(r=>r.ReportId.Equals(id))
                    .CalimedBy = InsuranceId;
                db.SaveChanges();
            }
        }
        #endregion
        #endregion

        #region ListContent
        public PartialViewResult _ListItem(ReportDetail Item) {
            return PartialView(Item);
        }
        #endregion

        #region Creatinge New Report
        public ActionResult Create() {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ReportDetail request) {
            long currentUser = (long)Session["CurrentUserID"];
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
                foreach (var image in request.Images.Select((value, index) => new { value, index })) {    //Projection: Accessing the index value of selected item in the list
                    string fileExt = Path.GetExtension(image.value.ImageFile.FileName);
                    string fileName = $"{currentUser}-{image.index}{DateTime.Now:yyyy-dd-M--HH-mm-ss}{fileExt}";   //Giving a new file name and using Date time and a counter to-
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
                    IsVehicleVehicle = request.IsVehicleVehicle,
                    Scale = request.Scale
                };
                //Table: Reprts
                var Report = new Data.Entities.Report() {
                    AuthorLicence = db.Drivers.Single(d => d.DriverNIC.Equals(currentUser)).LicenceId,
                    Images = Images,    //Reference: Table Images
                    Vehicles = Vehicles,  //Reference: Table Vehicles
                    ReportMeta = ReportDetails, //Reference: Table ReportMeta
                    Status = "Pending"
                };
                foreach (var vehicle in exisitingVehicles) {
                    //var Vehicle=db.Vehicles.Where(v => v.PlateNumber.Equals(vehicle.PlateNumber)).SelectMany(v=>v.Reports);
                    var Vehicel = db.Vehicles
                        .Include(v => v.Reports)
                        .First(v => v.PlateNumber.Equals(vehicle.PlateNumber));
                    Vehicel.Reports.Add(Report);
                }
                db.Reports.Add(Report); //Adding just Report will automatically insert the other tables that are refred through foreign references
                db.SaveChanges();   //Saving changes to the database.
            }
            return RedirectToAction("Index");
        }

        public PartialViewResult _NewVehicle() {
            Session["VehicleCount"] = (int)Session["VehicleCount"] + 1;
            return PartialView();
        }

        public PartialViewResult _NewImage() {
            Session["PhotoCount"] = (int)Session["PhotoCount"] + 1;
            return PartialView();
        }
        #endregion
    }
}