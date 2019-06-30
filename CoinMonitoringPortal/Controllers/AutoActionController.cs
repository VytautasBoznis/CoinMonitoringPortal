using System.Web.Mvc;
using CoinMonitoringPortal.Data.Data.Trade;
using CoinMonitoringPortal.Data.Messages.Trade;
using CoinMonitoringPortal.Interfaces;
using CoinMonitoringPortal.Portal.Attributes;
using CoinMonitoringPortal.Portal.ViewModels.AutoAction;

namespace CoinMonitoringPortal.Portal.Controllers
{
    public class AutoActionController : Controller
    {
	    private readonly IAccountFacade _accountFacade;
	    private readonly IScheduleFacade _scheduleFacade;

	    public AutoActionController(IAccountFacade accountFacade, IScheduleFacade scheduleFacade)
	    {
		    _accountFacade = accountFacade;
		    _scheduleFacade = scheduleFacade;
	    }

		[Secured]
        public ActionResult ScheduledTrades()
		{
			ScheduledTradesViewModel model = new ScheduledTradesViewModel
			{
				ScheduledTrades = _scheduleFacade.GetScheduledTrades()
			};

            return View(model);
        }

		[Secured]
	    public ActionResult CreateNewTrade()
	    {
		    return View();
	    }

		[Secured]
	    public ActionResult SynchronizeData()
	    {
		    _scheduleFacade.SynchronizePortfolio();
		    return RedirectToRoute("Home");
	    }

		[Secured]
		[HttpPost]
	    public JsonResult CreateScheduledTrade(CreateScheduledTradesRequest request)
		{
			_scheduleFacade.CreateScheduledTrades(request);
		    return Json("ok");
	    }

	    [Secured]
	    [HttpPost]
	    public JsonResult DeleteScheduledTrade(DeleteScheduledTradeRequest request)
	    {
		    _scheduleFacade.DeleteScheduledTrade(request);
		    return Json("ok");
	    }

	    [Secured]
	    [HttpPost]
	    public JsonResult ResetScheduledTrade(ResetScheduledTradeRequest request)
	    {
		    _scheduleFacade.ResetScheduledTrade(request);
		    return Json("ok");
	    }

		[Secured]
	    [HttpPost]
	    public JsonResult GetChartData(GetChartDataRequest request)
	    {
		    GetChartDataResponse response = _scheduleFacade.GetChartData(request);

			ChartData chartResponse = new ChartData
			{
				ChartPointsMain = response.ChartPoints,
				Name = request.Symbol1 + "/" + request.Symbol2
			};

		    if (response.EcoPoints.ContainsKey(1) && request.ShowRSI)
		    {
				chartResponse.RSI = new EcoIndexChart
				{
					Name = "RSI",
					Points = response.EcoPoints[1]
				};
			}

		    if (response.EcoPoints.ContainsKey(2) && request.ShowEMA)
		    {
			    chartResponse.EMA = new EcoIndexChart
			    {
				    Name = "EMA",
				    Points = response.EcoPoints[2]
			    };
		    }

		    if (response.EcoPoints.ContainsKey(3) && request.ShowFI)
		    {
			    chartResponse.ForceIndex = new EcoIndexChart
			    {
				    Name = "ForceIndex",
				    Points = response.EcoPoints[3]
			    };
		    }

			return Json(chartResponse, JsonRequestBehavior.AllowGet);
	    }
	}
}