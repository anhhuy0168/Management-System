using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(APPDEV.Startup))]
namespace APPDEV
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
