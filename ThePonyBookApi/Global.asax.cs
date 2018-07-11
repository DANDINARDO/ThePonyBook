using System.Web.Http;
using ThePonyBookLibraries.AutoMapper;

namespace ThePonyBookApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutoMapper.Mapper.Initialize(cfg => cfg.AddProfile<AutoMapperFactory>());
        }
    }
}
