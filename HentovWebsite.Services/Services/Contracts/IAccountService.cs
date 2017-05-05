using HentovWebsite.Models.Entity.Users;

namespace HentovWebsite.Services.Services.Contracts
{
    public interface IAccountService : IService
    {
        WebsiteUser CreateWebsiteUser(ApplicationUser model);
        bool RegisterWebsiteUser(WebsiteUser websiteUser);
    }
}
