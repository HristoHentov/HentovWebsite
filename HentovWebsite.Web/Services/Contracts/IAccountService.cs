using HentovWebsite.Models.Entity.Users;
using HentovWebsite.Models.View.ManageLogin;

namespace HentovWebsite.Web.Services.Contracts
{
    public interface IAccountService : IService
    {
        WebsiteUser CreateWebsiteUser(ApplicationUser model);
        bool RegisterWebsiteUser(WebsiteUser websiteUser);
        void SetUserRole(ApplicationUser user, ApplicationUserManager userManager);
    }
}
