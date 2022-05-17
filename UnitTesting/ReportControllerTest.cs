using AccidentsReports.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;
using Xunit;

namespace UnitTesting {
    [TestClass]
    public class ReportControllerTest {
        [TestMethod]
        public void Details() {
            //arrange
            int ReportId = 13;
            var controller = new ReportController();
            //act
            var result = controller.Details(ReportId) as ViewResult;
            //assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ApproveReport() {
            int ReportId= 13;
            var controller = new ReportController();
            var result=controller.Approve(ReportId);
            Assert.IsNotNull(result);

        }
    }
}
