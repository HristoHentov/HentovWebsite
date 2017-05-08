using System;
using HentovWebsite.Data.Contracts;
using HentovWebsite.Models.Entity.Users;
using HentovWebsite.Services.Services;
using HentovWebsite.Services.Services.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HentovWebsite.Web.Tests.Services
{
    [TestClass]
    public class AccountServiceTest
    {
        private readonly IUnitOfWork uow;
        private readonly IAccountService service;
        private ApplicationUser user;

        public AccountServiceTest()
        {
            this.uow = new FakeUnitOfWork();
            this.service = new AccountService(uow);
        }
        [TestInitialize]
        public void Setup()
        {
            this.user = new ApplicationUser()
            {
                Id = "1",
                Email = "Gosho@abv.bg",
                UserName = "NikoiNeGoInteresuva",
                PasswordHash = "jfshnjksfHFSJKDHFihsd89bn"
            };
            this.uow.Users.Add(user);

        }
        [TestMethod]
        public void Service_ReturnsCorrectResult()
        {
            var serviceResult = this.service.CreateWebsiteUser(user);
            Assert.AreEqual(user.UserName, serviceResult.Name);
            Assert.AreEqual(user, serviceResult.IdentityUser);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Service_ShouldThrowErrorOnNullUser()
        {
            this.service.CreateWebsiteUser(null);
        }

        [TestMethod]
        public void Service_ShouldFailOnNullUser()
        {
            var result = service.RegisterWebsiteUser(null);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Service_ShouldFailOnNullUserName()
        {
            var result = service.RegisterWebsiteUser(new WebsiteUser() {Id = 1, Name = null});
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Service_RegistersUserCorrectly()
        {
            var websiteUser = new WebsiteUser() {Id = 1, Name = "Bahari Zaharov", IdentityUser = user};
            var result = service.RegisterWebsiteUser(websiteUser);
            var userFromDb = uow.WebsiteUsers.FirstOrDefault(p => p.Name == "Bahari Zaharov");

            Assert.IsNotNull(userFromDb);
        }
    }
}
