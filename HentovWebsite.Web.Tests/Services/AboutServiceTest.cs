using System;
using HentovWebsite.Data.Contracts;
using HentovWebsite.Models.Entity.Users;
using HentovWebsite.Services.Services;
using HentovWebsite.Services.Services.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HentovWebsite.Web.Tests.Services
{
    [TestClass]
    public class AboutServiceTest
    {
        private readonly IAboutService service;
        public AboutServiceTest()
        {
            this.service = new AboutService();
        }

        [TestMethod]
        public void SendMail_ShouldFailOnEmptyParams()
        {
            var result = this.service.SendMail(null, null, 0, null, null, null);

            Assert.IsFalse(result);
        }
    }
}
