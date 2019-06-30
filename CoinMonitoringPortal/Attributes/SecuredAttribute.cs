using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using CoinMonitoringPortal.Business.Base;
using CoinMonitoringPortal.Business.KeyHolders;
using CoinMonitoringPortal.Interfaces;
using log4net;

namespace CoinMonitoringPortal.Portal.Attributes
{
	public class SecuredAttribute : ActionFilterAttribute
	{
		#region Logging

		private static ILog _logger;

		protected ILog Logger => _logger ?? (_logger = LogManager.GetLogger(GetType().Name));
		
		#endregion

		#region Properties

		private static IAccountFacade AccountFacade => DependencyResolver.Current.GetService<IAccountFacade>();

		#endregion

		#region Filtering

		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			if (AccountFacade.IsAuthenticated())
			{
				base.OnActionExecuting(filterContext);
			}
			else
			{
				filterContext.Result = new RedirectToRouteResult("Login", null);
			}
		}

		#endregion
	}
}