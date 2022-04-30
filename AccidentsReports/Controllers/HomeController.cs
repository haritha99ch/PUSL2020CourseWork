using AccidentsReports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccidentsReports.Controllers {
    public class HomeController : Controller {
        // GET: Home
        public ActionResult Index() {
            return View();
        }
        public ActionResult AboutUs() {
            ViewBag.Posted = false;
            return View();
        }
        [HttpPost]
        public ActionResult AboutUs(AboutUs request) {
            return RedirectToAction("PostFeedBack");
            return View();
        }
        public ActionResult PostFeedBack() {
            return View();
        }
    }
}