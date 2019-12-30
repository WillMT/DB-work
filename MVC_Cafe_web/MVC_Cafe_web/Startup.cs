using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_Cafe_web.Startup))]
namespace MVC_Cafe_web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
