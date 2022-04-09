using AccidentsReports.Data;
using AccidentsReports.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccidentsReports.Controllers {
    public class AccountController : Controller {
        // GET: Account

        public ActionResult Index() {
            long Id = 1234567890;
            Session["IsDriver"] = true;
            bool isDriver = (bool)Session["IsDriver"];
            //bool isPolice = (bool)Session["IsPolice"];
            //bool isRDA = (bool)Session["IsRDA"];
            //bool isInsurance = (bool)Session["IsInsurance"];
            //if (true) {
            if (isDriver) return RedirectToAction("Driver");
            //}
            //else if (isPolice) {
            //    Police loggedUser = null;
            //}

            return View();
        }
        public PartialViewResult User() {
            return PartialView();
        }

        public ActionResult Driver() {
            Driver User=null;
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
                    ).FirstOrDefault(u => u.user.NIC.Equals(1234567890));
                if (getUser != null) {
                    User = new Driver() {
                        NIC = getUser.user.NIC,
                        FirstName = getUser.user.FirstName,
                        LastName = getUser.user.LastName,
                        Gender = (Gender)Enum.Parse(typeof(Gender), getUser.user.Gender.ToString()),
                        Address = getUser.user.Address,
                        DOB = getUser.user.DOB,
                        PhoneNumber = getUser.user.PhoneNumber,
                        LicenceNumber = getUser.driver.LicenceId,
                        Email = getUser.account.Email,
                        ImagePath = "~/Content/images/Defualt.png"
                    };
                }
            }

            return View(User);
        }
    }
}