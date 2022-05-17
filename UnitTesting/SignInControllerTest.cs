using AccidentsReports.Controllers;
using AccidentsReports.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;

namespace UnitTesting {
    [TestClass]
    public class SignInControllerTest {
        [TestMethod]
        public void SignInTest() {
            var signIn = new SignIn() {
                Email ="email@email.com",
                Password = "3434544"
            };
            string returnUrl = "Report/Index";
            var controller = new SignInController();
            var result = controller.Index(signIn, returnUrl) as ViewResult;
        }
    }
}
