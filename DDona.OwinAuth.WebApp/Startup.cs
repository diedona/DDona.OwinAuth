using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Mvc;
using System.Web.Routing;

[assembly: OwinStartup(typeof(DDona.OwinAuth.WebApp.Startup))]
namespace DDona.OwinAuth.WebApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMvc(app);
        }

        private void ConfigureMvc(IAppBuilder app)
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
