using AccidentsReports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccidentsReports.Controllers {
    public class AboutUsController : Controller {
        // GET: AboutUs
        public ActionResult Index() {
            var Services = Enum.GetValues(typeof(Service))
                .Cast<Service>()
                .Select(s => s.ToString())
                .ToList();
            ViewBag.Services=Services;
            return View();
        }
    }
}