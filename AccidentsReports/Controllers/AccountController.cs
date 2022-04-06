using AccidentsReports.Data;
using AccidentsReports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccidentsReports.Controllers {
    public class AccountController : Controller {
        Driver? driver;
        Police? police;
        Insurance? insurance;
        RDA? rda;
        // GET: Account
        public ActionResult Login() {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login request) {
            using (var db = new ARDbContext()) {
                var account = db.Accounts
                    .FirstOrDefault(
                    a =>
                    a.Email.Equals(request.Email) &&
                    a.Password == request.Password
                    );
                if (account != null) {
                    Session["UserId"] = account.NIC;
                    Session["Email"] = account.Email;
                    Session["IsDriver"] = account.IsDriver;
                    Session["IsPolice"] = account.IsPolice;
                    Session["IsInsurance"] = account.IsInsurance;
                    Session["IsRDA"] = account.IsRDA;
                    if(account.IsDriver) return RedirectToAction("DriverAccount");
                    if(account.IsPolice) return RedirectToAction("PoliceAccount");
                    if(account.IsInsurance) return RedirectToAction("InsuranceAccount");
                    if(account.IsRDA) return RedirectToAction("RDAAccount");
                }
            }
            return View();
        }
        public ActionResult DriverAccount() {
            using(var db = new ARDbContext()) {
                int userId = (int)Session["UserId"];
                string email = (string)Session["Email"];
                var user = db.Drivers
                    .Join(
                        db.Users,
                        driver => driver.NIC,
                        user => user.NIC,
                        (driver, user ) =>
                        new {
                            Driver = driver,
                            User = user,
                        }
                    )
                    .Where(userDriver => userDriver.Driver.NIC.Equals(userId))
                    .Single();
                driver = new Driver() {
                    Id = userId,
                    FirstName = user.User.LastName,
                    LastName = user.User.FirstName,
                    Gender = user.User.Gender,
                    DOB = user.User.DOB,
                    Address = user.User.Address,
                    Email = email,
                    PhoneNumber = user.User.PhoneNumber,
                    LicenceNumber = user.Driver.LicenceNumber
                };
                List<ReportDetail> reportDetail = new List<ReportDetail>();
                var reports=db.Reports
                    .Where(r=>r.Author.Equals(driver.LicenceNumber)).ToList();
                foreach (var report in reports) {
                    reportDetail.Add(new ReportDetail() {
                        Author = driver.FirstName+" "+driver.LastName,
                        Title = report.Title,
                        ApprovedBy = driver.FirstName,
                        Category=report.Category,
                        Cause = report.Cause,
                        ClaimedBy = driver.LastName,
                        DamageEstimatedBy = "Marunoth gewwa",
                        Description = report.Description,
                        DamageScale=9
                    });
                }
                ViewBag.Reports = reportDetail;
            }
            return View(driver);
        }
    }
}