using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcSitemap2.Startup))]
namespace MvcSitemap2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
