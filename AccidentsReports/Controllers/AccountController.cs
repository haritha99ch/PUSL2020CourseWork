﻿using AccidentsReports.Data;
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
        string CurrentUserEmail;
        public ActionResult Index() {
            long CurrentUserId = 1234567890;
            //CurrentUserEmail = Session["CurrentUserEmail"].ToString();
            //bool isDriver = (bool)Session["IsDriver"];
            //bool isPolice = (bool)Session["IsPolice"];
            //bool isRDA = (bool)Session["IsRDA"];
            //bool isInsurance = (bool)Session["IsInsurance"];
            if (true) return Redirect("Driver");
            //if (isPolice) return RedirectToAction("Police");
            //if (isRDA) return RedirectToAction("RDA");
            //if (isInsurance) return RedirectToAction("Insurance");
            return View();
        }
        public PartialViewResult _User() {
            
            return PartialView();
        }
        #region asd
        
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
                        ProfilePic=$"~/Content/images/{db.Accounts.Single(a => a.Email.Equals(userEmail)).ProfilePic}",
                        Email = getUser.account.Email
                    };
                }
            }

            return View(User);
        }
         
        

        #endregion

    }
}