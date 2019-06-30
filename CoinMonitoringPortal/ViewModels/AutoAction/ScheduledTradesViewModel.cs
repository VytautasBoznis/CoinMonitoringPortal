using System.Collections.Generic;
using CoinMonitoringPortal.Data.Data.AutoAction;
using CoinMonitoringPortal.Data.Data.Trade;
using CoinMonitoringPortal.Portal.ViewModels.Base;

namespace CoinMonitoringPortal.Portal.ViewModels.AutoAction
{
	public class ScheduledTradesViewModel: BaseViewModel
	{
		public ScheduledTradesViewModel()
		{
			ScheduledTrades = new List<ScheduledTrade>();
		}

		public List<ScheduledTrade> ScheduledTrades { get; set; }
	}
}