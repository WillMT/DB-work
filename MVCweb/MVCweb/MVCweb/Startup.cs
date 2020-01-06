using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCweb.Startup))]
namespace MVCweb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
