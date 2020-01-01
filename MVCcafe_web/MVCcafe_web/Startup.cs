using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCcafe_web.Startup))]
namespace MVCcafe_web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
