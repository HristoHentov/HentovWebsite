using System;
using System.CodeDom;
using HentovWebsite.Data.Contracts;
using HentovWebsite.Models.Entity.Users;
using HentovWebsite.Models.Enums;
using HentovWebsite.Models.View.ManageLogin;
using HentovWebsite.Web.Services.Contracts;
using Microsoft.AspNet.Identity;

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
                var id = websiteUser.IdentityUser.Id;
                var identityUser = this.context.Users.Find(id);
                this.context.WebsiteUsers.Add(new WebsiteUser {Name = websiteUser.Name, IdentityUser = identityUser});
                this.context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public void SetUserRole(ApplicationUser user, ApplicationUserManager userManager)
        {
            if (this.context.Users.Any())
                userManager.AddToRole(user.Id, UserRoles.Admin.ToString());
            else
                userManager.AddToRole(user.Id, UserRoles.WebsiteUser.ToString());
        }
    }
}