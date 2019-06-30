using System.Collections.Generic;
using CoinMonitoringPortal.Data.Data.Trade;

namespace CoinMonitoringPortal.Data.Messages.Trade
{
	public class SynchronizePortfolioRequest
	{
		public int UserNr { get; set; }
	}

	public class SynchronizePortfolioResponse
	{
		public bool Success { get; set; }
		public string Error { get; set; }
		public List<PortfolioData> PortfolioData { get; set; }
	}
}
