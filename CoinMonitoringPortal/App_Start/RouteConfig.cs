using System.Web.Mvc;
using System.Web.Routing;

namespace CoinMonitoringPortal.Portal
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				name: "Login",
				url: "Login",
				defaults: new { controller = "Account", action = "Login" }
			);

	        routes.MapRoute(
		        name: "Register",
		        url: "Register",
		        defaults: new { controller = "Account", action = "Register" }
	        );

	        routes.MapRoute(
		        name: "RegisterSuccess",
		        url: "RegisterSuccess",
		        defaults: new { controller = "Account", action = "RegisterSuccess" }
	        );

	        routes.MapRoute(
		        name: "Logout",
		        url: "Logout",
		        defaults: new { controller = "Account", action = "Logout" }
	        );

	        routes.MapRoute(
		        name: "ScheduledTrades",
		        url: "ScheduledTrades",
		        defaults: new { controller = "AutoAction", action = "ScheduledTrades" }
	        );

	        routes.MapRoute(
		        name: "UserProfile",
		        url: "UserProfile",
		        defaults: new { controller = "Account", action = "UserProfile" }
	        );

	        routes.MapRoute(
		        name: "CreateNewTrade",
		        url: "CreateNewTrade",
		        defaults: new { controller = "AutoAction", action = "CreateNewTrade" }
	        );

	        routes.MapRoute(
		        name: "SynchronizeData",
		        url: "SynchronizeData",
		        defaults: new { controller = "AutoAction", action = "SynchronizeData" }
	        );

	        routes.MapRoute(
		        name: "Home",
		        url: "",
		        defaults: new { controller = "Home", action = "Dashboard" }
	        );

			routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
