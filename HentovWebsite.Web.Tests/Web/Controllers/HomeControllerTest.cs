using System.Web.Mvc;
using HentovWebsite.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HentovWebsite.Web.Tests.Web.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
