using System.Collections.Generic;
using System.Web.Mvc;
using CoinMonitoringPortal.Data.Data.Trade;
using CoinMonitoringPortal.Interfaces;
using CoinMonitoringPortal.Portal.Attributes;
using CoinMonitoringPortal.Portal.ViewModels.Home;

namespace CoinMonitoringPortal.Portal.Controllers
{
    public class HomeController : Controller
    {
	    private readonly IAccountFacade _accountFacade;
	    private readonly IScheduleFacade _scheduleFacade;

	    public HomeController(IAccountFacade accountFacade, IScheduleFacade scheduleFacade)
	    {
		    _scheduleFacade = scheduleFacade;
		    _accountFacade = accountFacade;
	    }

		[Secured]
        public ActionResult Dashboard()
		{
			var model = new DashboardViewModel()
			{
				PortfolioDatas = new List<PortfolioData>()
			};

			if (_accountFacade.GetUserAuthenticationData().PortfolioData != null)
			{
				model.PortfolioDatas = _accountFacade.GetUserAuthenticationData().PortfolioData;
			}

			return View(model);
        }
    }
}