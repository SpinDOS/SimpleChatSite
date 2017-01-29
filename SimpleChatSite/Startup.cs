using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SimpleChatSite.Startup))]
namespace SimpleChatSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
