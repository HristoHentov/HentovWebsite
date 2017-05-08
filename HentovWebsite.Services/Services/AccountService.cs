using System;
using HentovWebsite.Data.Contracts;
using HentovWebsite.Models.Entity.Users;
using HentovWebsite.Models.Enums;
using HentovWebsite.Services.Services.Contracts;
using HentovWebsite.Utility;
using Microsoft.AspNet.Identity;

namespace HentovWebsite.Services.Services
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
            if (appuser != null)
            {
                var user = new WebsiteUser
                {
                    Name = appuser.UserName,
                    IdentityUser = appuser
                };

                return user;
            }

            throw new ArgumentNullException(Consts.NullApplicationUserError);
        }

        public bool RegisterWebsiteUser(WebsiteUser websiteUser)
        {
            if(websiteUser != null && websiteUser.Name != null)
            {
                var id = websiteUser.IdentityUser.Id;
                var identityUser = this.context.Users.FirstOrDefault(p => p.Id == id);
                this.context.WebsiteUsers.Add(new WebsiteUser { Name = websiteUser.Name, IdentityUser = identityUser });

                if (this.context.SaveChanges() > 0)
                    return true;
            }

            return false;
        }
    }
}