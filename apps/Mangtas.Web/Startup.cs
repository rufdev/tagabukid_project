using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mangtas.Web.Startup))]
namespace Mangtas.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
