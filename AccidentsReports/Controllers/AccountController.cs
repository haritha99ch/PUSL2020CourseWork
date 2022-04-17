using AccidentsReports.Data;
using AccidentsReports.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;

namespace AccidentsReports.Controllers {
    [Authorize]
    public class AccountController : Controller {
        // GET: Account
        public ActionResult Index() {
            long CurrentUserId = (long)Session["CurrentUserID"];
            string CurrentUserEmail = Session["CurrentUserEmail"].ToString();
            bool isDriver = (bool)Session["IsDriver"];
            bool isPolice = (bool)Session["IsPolice"];
            bool isRDA = (bool)Session["IsRDA"];
            bool isInsurance = (bool)Session["IsInsurance"];
            if (isDriver) return RedirectToAction("Driver");
            if (isPolice) return RedirectToAction("Police");
            if (isRDA) return RedirectToAction("RDA");
            if (isInsurance) return RedirectToAction("Insurance");
            return View();
        }
        public PartialViewResult _User() {

            return PartialView();
        }

        #region Police
        public ActionResult Police() {
            long CurrentUserId = (long)Session["CurrentUserID"];
            long profileId = 0;
            Police User = null;
            using (var db = new ARDbContext()) {
                var getUser = db.Users
                    .Join(
                        db.Polices,
                        u => u.NIC,
                        d => d.PoliceNIC,
                        (u, d) => new {
                            u,
                            d,
                        }
                    )
                    .Join(
                        db.Accounts,
                        ud => ud.u.AccountEmail,
                        a => a.Email,
                        (ud, a) => new {
                            account = a,
                            user = ud.u,
                            police = ud.d,
                        }
                    ).FirstOrDefault(u => u.user.NIC.Equals(CurrentUserId));
                if (getUser != null) {
                    string userEmail = Session["CurrentUserEmail"].ToString();
                    User = new Police() {
                        NIC = getUser.user.NIC,
                        FirstName = getUser.user.FirstName,
                        LastName = getUser.user.LastName,
                        Gender = (Gender)Enum.Parse(typeof(Gender), getUser.user.Gender.ToString()),
                        Address = getUser.user.Address,
                        DOB = getUser.user.DOB,
                        PhoneNumber = getUser.user.PhoneNumber,
                        PoliceId = getUser.police.PoliceId,
                        Domain = getUser.police.PoliceDomain,
                        ProfilePic = $"~/Content/images/{db.Accounts.Single(a => a.Email.Equals(userEmail)).ProfilePic}",
                        Email = getUser.account.Email
                    };
                    profileId = User.PoliceId;
                }
            }
            ViewBag.List = GetReports(profileId);
            return View(User);
        }
        #endregion

        #region Driver
        public ActionResult Driver() {
            long CurrentUserId = (long)Session["CurrentUserID"];
            long profileId=0;
            Driver User = null;
            using (var db = new ARDbContext()) {
                var getUser = db.Users
                    .Join(
                        db.Drivers,
                        u => u.NIC,
                        d => d.DriverNIC,
                        (u, d) => new {
                            u,
                            d,
                        }
                    )
                    .Join(
                        db.Accounts,
                        ud => ud.u.AccountEmail,
                        a => a.Email,
                        (ud, a) => new {
                            account = a,
                            user = ud.u,
                            driver = ud.d,
                        }
                    ).FirstOrDefault(u => u.user.NIC.Equals(CurrentUserId));
                if (getUser != null) {
                    string userEmail = Session["CurrentUserEmail"].ToString();
                    User = new Driver() {
                        NIC = getUser.user.NIC,
                        FirstName = getUser.user.FirstName,
                        LastName = getUser.user.LastName,
                        Gender = (Gender)Enum.Parse(typeof(Gender), getUser.user.Gender.ToString()),
                        Address = getUser.user.Address,
                        DOB = getUser.user.DOB,
                        PhoneNumber = getUser.user.PhoneNumber,
                        LicenceNumber = getUser.driver.LicenceId,
                        ProfilePic = $"~/Content/images/{db.Accounts.Single(a => a.Email.Equals(userEmail)).ProfilePic}",
                        Email = getUser.account.Email
                    };
                    profileId = User.LicenceNumber;
                }
            }
            ViewBag.List = GetReports(profileId);
            return View(User);
        }
        #endregion

        #region RDA
        public ActionResult RDA() {
            long CurrentUserId = (long)Session["CurrentUserID"];
            long profileId = 0;
            RDA User = null;
            using (var db = new ARDbContext()) {
                var getUser = db.Users
                    .Join(
                        db.RDAs,
                        u => u.NIC,
                        d => d.RDANIC,
                        (u, d) => new {
                            u,
                            d,
                        }
                    )
                    .Join(
                        db.Accounts,
                        ud => ud.u.AccountEmail,
                        a => a.Email,
                        (ud, a) => new {
                            account = a,
                            user = ud.u,
                            rda = ud.d,
                        }
                    ).FirstOrDefault(u => u.user.NIC.Equals(CurrentUserId));
                if (getUser != null) {
                    string userEmail = Session["CurrentUserEmail"].ToString();
                    User = new RDA() {
                        NIC = getUser.user.NIC,
                        FirstName = getUser.user.FirstName,
                        LastName = getUser.user.LastName,
                        Gender = (Gender)Enum.Parse(typeof(Gender), getUser.user.Gender.ToString()),
                        Address = getUser.user.Address,
                        DOB = getUser.user.DOB,
                        PhoneNumber = getUser.user.PhoneNumber,
                        EmployeeId = getUser.rda.EmpId,
                        Domain = getUser.rda.RDADomain,
                        ProfilePic = $"~/Content/images/{db.Accounts.Single(a => a.Email.Equals(userEmail)).ProfilePic}",
                        Email = getUser.account.Email
                    };
                    profileId = User.EmployeeId;
                }
            }
            ViewBag.List = GetReports(profileId);
            return View(User);
        }
        #endregion

        #region Insurance
        public ActionResult Insurance() {
            long CurrentUserId = (long)Session["CurrentUserID"];
            long profileId = 0;
            Insurance User = null;
            using (var db = new ARDbContext()) {
                var getUser = db.Users
                    .Join(
                        db.Insurances,
                        u => u.NIC,
                        d => d.InsuranceNIC,
                        (u, d) => new {
                            u,
                            d,
                        }
                    )
                    .Join(
                        db.Accounts,
                        ud => ud.u.AccountEmail,
                        a => a.Email,
                        (ud, a) => new {
                            account = a,
                            user = ud.u,
                            insurance = ud.d,
                        }
                    ).FirstOrDefault(u => u.user.NIC.Equals(CurrentUserId));
                if (getUser != null) {
                    string userEmail = Session["CurrentUserEmail"].ToString();
                    User = new Insurance() {
                        NIC = getUser.user.NIC,
                        FirstName = getUser.user.FirstName,
                        LastName = getUser.user.LastName,
                        Gender = (Gender)Enum.Parse(typeof(Gender), getUser.user.Gender.ToString()),
                        Address = getUser.user.Address,
                        DOB = getUser.user.DOB,
                        PhoneNumber = getUser.user.PhoneNumber,
                        EmployeeId = getUser.insurance.EmpId,
                        Company = getUser.insurance.Company,
                        ProfilePic = $"~/Content/images/{db.Accounts.Single(a => a.Email.Equals(userEmail)).ProfilePic}",
                        Email = getUser.account.Email
                    };
                    profileId = User.EmployeeId;
                }
            }
            ViewBag.List = GetReports(profileId);
            return View(User);
        }
        #endregion

        #region Personal Reports
        public List<ReportDetail> GetReports(long id) {
            List<ReportDetail> reportList = new List<ReportDetail>();
            List<List<string>> VehicleTypes = new List<List<string>>();
            using (var db = new ARDbContext()) {
                var getReportList = db.Reports  //Getting posts reports with all the other tables related to it
                    .Include(r => r.ReportMeta)
                    .Include(r => r.Vehicles)
                    .Include(r => r.Images)
                    .Where(r => r.AuthorLicence.Equals(id) || r.ApprovedBy==id || r.DamageEstimatedBy==id || r.CalimedBy==id)
                    .ToList();
                //Reading all the reports
                foreach (var Report in getReportList) {
                    ReportDetail reportDetail = new ReportDetail() {
                        Id = Report.ReportId,
                        Title = Report.ReportMeta.Title,
                        ImagePath = $"~/Content/images/{db.Images.First(i => i.ReportId == Report.ReportId).ImagePath}",
                        DatetTime = Report.ReportMeta.DateTime,
                        ApprovedBy = Report.ApprovedBy,
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
                ViewBag.VehicleTypes = VehicleTypes;
                ViewBag.List = reportList;
            }
            return reportList;
        }
        public PartialViewResult _Reports(long id) {
            return PartialView();
        }
        #endregion
    }
}