using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HentovWebsite.Web.Startup))]
namespace HentovWebsite.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
