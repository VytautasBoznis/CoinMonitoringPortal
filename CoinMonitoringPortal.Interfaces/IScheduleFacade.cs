using System.Collections.Generic;
using CoinMonitoringPortal.Data.Data.Trade;
using CoinMonitoringPortal.Data.Messages.Trade;

namespace CoinMonitoringPortal.Interfaces
{
	public interface IScheduleFacade
	{
		List<ScheduledTrade> GetScheduledTrades();
		SynchronizePortfolioResponse SynchronizePortfolio();
		CreateScheduledTradesResponse CreateScheduledTrades(CreateScheduledTradesRequest request);
		GetChartDataResponse GetChartData(GetChartDataRequest request);
		DeleteScheduledTradeResponse DeleteScheduledTrade(DeleteScheduledTradeRequest request);
		ResetScheduledTradeResponse ResetScheduledTrade(ResetScheduledTradeRequest request);
	}
}
