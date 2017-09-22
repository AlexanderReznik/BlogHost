using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlogHost.WebUI.Startup))]
namespace BlogHost.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
