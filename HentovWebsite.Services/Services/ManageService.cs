using HentovWebsite.Data.Contracts;
using HentovWebsite.Models.Entity.Users;
using HentovWebsite.Services.Services.Contracts;

namespace HentovWebsite.Services.Services
{
    public class ManageService : IManageService
    {
        private IUnitOfWork context;

        public ManageService(IUnitOfWork uow)
        {
            this.context = uow;
        }
        public WebsiteUser GetUserById(string userId)
        {
            var user = this.context.WebsiteUsers.FirstOrDefault(u => u.IdentityUser.Id == userId);
            return user;
        }
    }
}
