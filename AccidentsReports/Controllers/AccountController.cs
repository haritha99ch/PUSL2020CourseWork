using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccidentsReports.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Email, string Password)
        {
            if(!(string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))) {
                ViewBag.Email = Email;
                ViewBag.Password = Password;
            }
            return View();
        }
    }
}