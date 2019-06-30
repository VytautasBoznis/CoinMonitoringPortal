using System.Web.Mvc;
using System.Web.Routing;
using CoinMonitoringPortal.Portal.App_Start;

namespace CoinMonitoringPortal.Portal
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

	        AutoMapperConfig.Configure();
		}
    }
}
