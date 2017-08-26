using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Mvc;
using System.Web.Routing;
using DDona.OwinAuth.WebApp.App_Start;
using DDona.OwinAuth.WebApp.Auth;

[assembly: OwinStartup(typeof(DDona.OwinAuth.WebApp.Startup))]
namespace DDona.OwinAuth.WebApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            StartupAuth.ConfigureAuth(app);
            ConfigureMvc(app);
        }

        private void ConfigureMvc(IAppBuilder app)
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }
    }
}
