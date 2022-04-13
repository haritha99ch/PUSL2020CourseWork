using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AccidentsReports.Data.Entities;
using AccidentsReports.Data;
using AccidentsReports;
using System.Web.Security;

namespace AccidentsReports.Controllers {
    public class SignInController : Controller {
        // GET: SignIn
        public ActionResult Index() {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Models.SignIn request, string ReturnUrl) {

            using (var db = new ARDbContext()) {
                var account = db.Accounts
                    .FirstOrDefault(
                        a =>
                            a.Email == request.Email &&
                            a.Password == request.Password
                    );
                if (account == null) {
                    ViewBag.Error = "Invalid Login";
                    return View();
                }
                Session["CurrentUserEmail"] = request.Email;
                Session["CurrentUserID"] = db.Users
                    .FirstOrDefault(
                        u =>
                            u.AccountEmail.Equals(request.Email)
                    ).NIC;
                Session["IsDriver"] = account.IsDriver;
                Session["IsPolice"] = account.IsPolice;
                Session["IsRDA"] = account.IsRDA;
                Session["IsInsurance"] = account.IsInsurance;
                FormsAuthentication.SetAuthCookie(request.Email, false);
                return Redirect(FormsAuthentication.GetRedirectUrl(request.Email, false));
                return View();
            }
        }
    }
}