using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(prms.web.Startup))]
namespace prms.web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
