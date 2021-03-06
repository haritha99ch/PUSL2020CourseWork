using AccidentsReports.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Data.Entity.Core.Objects;

namespace AccidentsReports.Models {
    public class StatisticController : Controller {
        // GET: Statistic
        [Obsolete] //REF:1
        public ActionResult Index() {
            var Causes = Enum.GetValues(typeof(Cause))  //Createing a list from the custom enum
                .Cast<Cause>()
                .Select(c => c.ToString())
                .ToList();
            var Classes = Enum.GetValues(typeof(VehicleClass))  //""
                .Cast<VehicleClass>()
                .Select(c => c.ToString())
                .ToList();
            var dates = Enumerable  //List of one week
                .Range(1, 7)
                .Select(i => DateTime.Now.AddDays(-7)
                .AddDays(i))
                .ToList();
            var categories = new List<string>() {
                "Vehicle With Vehicle",
                "Vehicle With Property",
                "Vehicle With Pedestrian"
            };
            var cause = new Dictionary<string, int>();          //
            var WeeklyCount = new Dictionary<string, int>();    //For Charts
            var category = new Dictionary<string, int>();       //
            var vehicleClasses = new Dictionary<string, int>(); //
            using (var db = new ARDbContext()) {
                foreach (var Cause in Causes) {
                    var count = db.Reports
                        .Include(r => r.ReportMeta)
                        .Count(r => r.ReportMeta.Cause.Equals(Cause.ToString()) && r.ApprovedBy.HasValue);
                    cause.Add(Cause, count);
                }
                foreach (var date in dates) {
                    var count = db.Reports
                        .Include(r => r.ReportMeta)
                        .Count(r => EntityFunctions.TruncateTime(r.ReportMeta.DateTime) == date.Date && r.ApprovedBy.HasValue);
                    //REF:1 https://stackoverflow.com/questions/34050664/best-way-to-compare-date-in-entity-framework
                    WeeklyCount.Add(date.Date.ToString("dd/M/yyyy"), count);
                }
                foreach (var Category in categories) {
                    bool flagVPed = Category.Equals("Vehicle With Pedestrian") ? true : false;
                    bool flagVPro = Category.Equals("Vehicle With Property") ? true : false;
                    bool flagVV = Category.Equals("Vehicle With Vehicle") ? true : false;
                    var count = db.ReportMetas
                        .Count(r => r.IsVehiclePedestrian.Equals(flagVPed) || r.IsVehicleProperty.Equals(flagVPro) || r.IsVehicleVehicle.Equals(flagVV));
                    category.Add(Category, count);
                }
                foreach (var Class in Classes) {
                    var Count = db.Vehicles
                        .Include(v => v.Reports)
                        .Count(v => v.Class.Equals(Class) && v.Reports.Any(r => r.ApprovedBy.HasValue));
                    vehicleClasses.Add(Class, Count);
                }
            }

            ViewBag.xCause = new List<string>(cause.Keys);
            ViewBag.yCause = new List<int>(cause.Values);

            ViewBag.xClass = new List<string>(vehicleClasses.Keys);
            ViewBag.yClass = new List<int>(vehicleClasses.Values);

            ViewBag.xCategory = new List<string>(category.Keys);
            ViewBag.yCategory = new List<int>(category.Values);

            ViewBag.xWeeklyCount = new List<string>(WeeklyCount.Keys);
            ViewBag.yWeeklyCount = new List<int>(WeeklyCount.Values);
            return View();
        }
    }
}