using AccidentsReports.Controllers;
using AccidentsReports.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;

namespace UnitTesting {
    [TestClass]
    public class SignUpControllerTest {
        [TestMethod]
        public void NewDriver() {
            var driver = new Driver() {
                NIC =12345678,
                FirstName = "First",
                LastName ="Last",
                Gender = Gender.Male,
                DOB = DateTime.Now,
                Address = "Random",
                Email = "email@email.com",
                LicenceNumber = 1233434,
                Password = "4354534",
                RePassword = "4354534"
            };
            var controller = new SignUpController();
            var result = controller.Driver(driver) as ViewResult;
            Assert.IsNotNull(result);
        }
    }
}
