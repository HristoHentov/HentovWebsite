using HentovWebsite.Models.Binding.About;
using HentovWebsite.Models.Binding.Blog;

namespace HentovWebsite.Services.Services.Contracts
{
    public interface IAboutService : IService
    {
        bool SendMail(SendMailBindingModel model, string host, int port, string mailCredential, string passwordCredential, string recepient);
    }
}
