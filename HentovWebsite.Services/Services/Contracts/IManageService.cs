using HentovWebsite.Models.Entity.Users;

namespace HentovWebsite.Services.Services.Contracts
{
    public interface IManageService
    {
        WebsiteUser GetUserById(string userId);
    }
}
