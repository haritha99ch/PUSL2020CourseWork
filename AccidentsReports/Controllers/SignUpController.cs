using AccidentsReports.Data;
using AccidentsReports;
using AccidentsReports.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccidentsReports.Controllers {
    public class SignUpController : Controller {
        // GET: SignUp

        #region Driver
        public ActionResult Driver() {
            ViewBag.Errors = new List<string>();
            return View();
        }
        [HttpPost]
        public ActionResult Driver(Models.Driver request) {
            using (var db = new ARDbContext()) {
                ViewBag.Errors = IsUserExists(db, request as object);
                if (ViewBag.Errors.Count > 0) {
                    return View();
                }
                db.Drivers.Add(
                    new Driver {
                        User = new User {
                            NIC = request.NIC,
                            FirstName = request.FirstName,
                            LastName = request.LastName,
                            Gender = request.Gender.ToString(),
                            DOB = request.DOB,
                            Address = request.Address,
                            PhoneNumber = request.PhoneNumber,
                            Account = new Account {
                                Email = request.Email,
                                Password = request.Password,
                                IsDriver = true,
                            },
                        },
                        LicenceId = request.LicenceNumber
                    }
                );
                db.SaveChanges();
            }
            return View();
        }
        #endregion
        #region Police
        public ActionResult Police() {
            ViewBag.Errors = new List<string>();
            return View();
        }
        [HttpPost]
        public ActionResult Police(Models.Police request) {
            using(var db = new ARDbContext()) {
                ViewBag.Errors=IsUserExists(db, request as object);
                if (ViewBag.Errors.Count > 0) {
                    return View();
                }
                db.Polices.Add(
                    new Police {
                        User = new User {
                            NIC= request.NIC,
                            FirstName= request.FirstName,
                            LastName= request.LastName,
                            Gender= request.Gender.ToString(),
                            DOB= request.DOB,
                            Address= request.Address,
                            PhoneNumber= request.PhoneNumber,
                            Account= new Account {
                                Email= request.Email,
                                Password=request.Password,
                                IsPolice=true,
                            }
                        },
                        PoliceId=request.PoliceId,
                        PoliceDomain=request.Domain
                    }
                );
                db.SaveChanges();
            }
            return View();
        }
        #endregion
        #region RDA
        public ActionResult RDA() {
            ViewBag.Errors = new List<string>();
            return View();
        }
        [HttpPost]
        public ActionResult RDA(Models.RDA request) {
            using (var db = new ARDbContext()) {
                ViewBag.Errors = IsUserExists(db, request as object);
                if (ViewBag.Errors.Count > 0) {
                    return View();
                }
                db.RDAs.Add(
                    new RDA {
                        User = new User {
                            NIC = request.NIC,
                            FirstName = request.FirstName,
                            LastName = request.LastName,
                            Gender = request.Gender.ToString(),
                            DOB = request.DOB,
                            Address = request.Address,
                            PhoneNumber = request.PhoneNumber,
                            Account = new Account {
                                Email = request.Email,
                                Password = request.Password,
                                IsRDA = true,
                            }
                        },
                        EmpId = request.EmployeeId,
                        RDADomain = request.Domain
                    }
                );
                db.SaveChanges();
            }
            return View();
        }
        #endregion
        #region Insurance
        public ActionResult Insurance() {
            ViewBag.Errors = new List<string>();
            return View();
        }
        [HttpPost]
        public ActionResult Insurance(Models.Insurance request) {
            using (var db = new ARDbContext()) {
                ViewBag.Errors = IsUserExists(db, request as object);
                if (ViewBag.Errors.Count > 0) {
                    return View();
                }
                db.Insurances.Add(
                    new Insurance {
                        User = new User {
                            NIC = request.NIC,
                            FirstName = request.FirstName,
                            LastName = request.LastName,
                            Gender = request.Gender.ToString(),
                            DOB = request.DOB,
                            Address = request.Address,
                            PhoneNumber = request.PhoneNumber,
                            Account = new Account {
                                Email = request.Email,
                                Password = request.Password,
                                IsInsurance = true,
                            }
                        },
                        EmpId = request.EmployeeId,
                        Company = request.Company
                    }
                );
                db.SaveChanges();
            }
            return View();
        }
        #endregion

        #region IsExistsValidation
        private bool IsNICExists(ARDbContext db, long aNIC) {
            if (db.Users.Any(u => u.NIC.Equals(aNIC))) {
                return true;
            }
            return false;
        }
        private bool IsEmailExists(ARDbContext db, string aEmail) {
            if (db.Users.Any(u => u.AccountEmail.Equals(aEmail))) {
                return true;
            }
            return false;
        }
        private bool IsPhonenumberExists(ARDbContext db, int aPhonenumber) {
            if (db.Users.Any(u => u.PhoneNumber.Equals(aPhonenumber))) {
                return true;
            }
            return false;
        }
        private List<string> IsUserExists(ARDbContext db, object aRequest) {
            List<string> errors = new List<string>();
            if (aRequest is Models.Driver) {
                var request = (Models.Driver)aRequest;
                if(IsNICExists(db, request.NIC)) errors.Add("NIC Already Exists");
                if(IsEmailExists(db, request.Email)) errors.Add("Email Already Registered");
                if(IsPhonenumberExists(db, request.PhoneNumber)) errors.Add("Phonenumber Already Exists");
                if (db.Drivers.Any(a => a.LicenceId.Equals(request.LicenceNumber))) {
                    errors.Add("Licence Already Registered");
                }
            }
            if (aRequest is Models.Police) {
                var request = (Models.Police)aRequest;
                if (IsNICExists(db, request.NIC)) errors.Add("NIC Already Exists");
                if (IsEmailExists(db, request.Email)) errors.Add("Email Already Registered");
                if (IsPhonenumberExists(db, request.PhoneNumber)) errors.Add("Phonenumber Already Exists");
                if (db.Polices.Any(a => a.PoliceId.Equals(request.PoliceId))) {
                    errors.Add("Police Id Already Registered");
                }
            }
            if (aRequest is Models.RDA) {
                var request = (Models.RDA)aRequest;
                if (IsNICExists(db, request.NIC)) errors.Add("NIC Already Exists");
                if (IsEmailExists(db, request.Email)) errors.Add("Email Already Registered");
                if (IsPhonenumberExists(db, request.PhoneNumber)) errors.Add("Phonenumber Already Exists");
                if (db.RDAs.Any(a => a.EmpId.Equals(request.EmployeeId))) {
                    errors.Add("RDA Agent Id Already Registered");
                }
            }
            if (aRequest is Models.Insurance) {
                var request = (Models.Insurance)aRequest;
                if (IsNICExists(db, request.NIC)) errors.Add("NIC Already Exists");
                if (IsEmailExists(db, request.Email)) errors.Add("Email Already Registered");
                if (IsPhonenumberExists(db, request.PhoneNumber)) errors.Add("Phonenumber Already Exists");
                if (db.Insurances.Any(a => a.EmpId.Equals(request.EmployeeId))) {
                    errors.Add("RDA Agent Id Already Registered");
                }
            }
            return errors;
        }
        #endregion

    }


}