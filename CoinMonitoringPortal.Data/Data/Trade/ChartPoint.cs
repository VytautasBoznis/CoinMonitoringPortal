using System;

namespace CoinMonitoringPortal.Data.Data.Trade
{
	public class ChartPoint
	{
		public DateTime Time { get; set; }
		public decimal High { get; set; }
		public decimal Low { get; set; }
		public decimal Last { get; set; }
		public decimal Volume { get; set; }
		public string TimeFormatted => Time.AddHours(3).ToString("yyyy-MM-dd hh:mm:ss");
	}
}
