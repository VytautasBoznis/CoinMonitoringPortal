using System.Collections.Generic;
using CoinMonitoringPortal.Data.Data.Trade;

namespace CoinMonitoringPortal.Data.Messages.Trade
{
	public class GetScheduledTradesRequest
	{
		public int UserNr { get; set; }
	}

	public class GetScheduledTradesResponse
	{
		public bool Success { get; set; }
		public string Error { get; set; }
		public List<ScheduledTrade> Trades { get; set; }
	}
}
