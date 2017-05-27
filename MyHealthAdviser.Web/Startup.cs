using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyHealthAdviser.Web.Startup))]
namespace MyHealthAdviser.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
