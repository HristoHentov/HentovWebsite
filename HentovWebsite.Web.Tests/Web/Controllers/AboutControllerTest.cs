
using System.Web.Mvc;
using HentovWebsite.Data.Contracts;
using HentovWebsite.Services.Services;
using HentovWebsite.Services.Services.Contracts;
using HentovWebsite.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.FluentMVCTesting;

namespace HentovWebsite.Web.Tests.Web.Controllers
{
    [TestClass]
    public class AboutControllerTest
    {
        private IAboutService service;
        private AboutController controller;

        public AboutControllerTest()
        {
            this.service = new AboutService();
            this.controller = new AboutController(service);
        }

        [TestMethod]
        public void IndexView_ShouldReturnDefaultView()
        {
            controller
                .WithCallTo(c => c.Index())
                .ShouldRenderDefaultView();
        }

        [TestMethod]
        public void IndexView_DoesNotReturnNull()
        {
            var result = (ViewResult)controller.Index();
            Assert.IsNotNull(result);
        }
    }
}
