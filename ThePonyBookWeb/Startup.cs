using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ThePonyBookWeb.Startup))]
namespace ThePonyBookWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
