using Microsoft.Owin;
using Owin;
using ThePonyBookApi;

[assembly: OwinStartup(typeof(Startup))]
namespace ThePonyBookApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
