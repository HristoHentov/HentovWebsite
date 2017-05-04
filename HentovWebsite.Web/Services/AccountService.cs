using System;
using System.CodeDom;
using HentovWebsite.Data.Contracts;
using HentovWebsite.Models.Entity.Users;
using HentovWebsite.Models.View.ManageLogin;
using HentovWebsite.Web.Services.Contracts;

namespace HentovWebsite.Web.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork context;

        public AccountService(IUnitOfWork context)
        {
            this.context = context;
        }
        public WebsiteUser CreateWebsiteUser(ApplicationUser appuser)
        {
            var user = new WebsiteUser
            {
                Name = appuser.UserName,
                IdentityUser = appuser
            };

            return user;
        }

        public bool RegisterWebsiteUser(WebsiteUser websiteUser)
        {
            try
            {
                this.context.WebsiteUsers.Add(new WebsiteUser {Name = websiteUser.Name, IdentityUser = websiteUser.IdentityUser});
                //this.context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
    }
}