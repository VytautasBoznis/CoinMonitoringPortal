using CoinMonitoringPortal.Data.Data.Trade;

namespace CoinMonitoringPortal.Data.Messages.Trade
{
	public class CreateScheduledTradesRequest
	{
		public int UserNr { get; set; }
		public ScheduledTrade Trade { get; set; }
	}

	public class CreateScheduledTradesResponse
	{
		public bool Success { get; set; }
		public string Error { get; set; }
	}
}
