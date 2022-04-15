using AccidentsReports.Data;
using AccidentsReports.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
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
                        Domain=getUser.police.PoliceDomain,
                        ProfilePic = $"~/Content/images/{db.Accounts.Single(a => a.Email.Equals(userEmail)).ProfilePic}",
                        Email = getUser.account.Email
                    };
                }
            }
            return View(User);
        }
        #endregion

        #region Driver
        public ActionResult Driver() {
            long CurrentUserId = (long)Session["CurrentUserID"];
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
                    string userEmail=Session["CurrentUserEmail"].ToString();
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
                }
            }
            return View(User);
        }
        #endregion

        #region RDA
        public ActionResult RDA() {
            long CurrentUserId = (long)Session["CurrentUserID"];
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
                }
            }
            return View(User);
        }
        #endregion

        #region Insurance
        public ActionResult Insurance() {
            long CurrentUserId = (long)Session["CurrentUserID"];
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
                }
            }
            return View(User);
        }
        #endregion
    }
}