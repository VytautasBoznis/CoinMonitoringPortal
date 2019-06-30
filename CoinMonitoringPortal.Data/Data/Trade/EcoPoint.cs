using System;

namespace CoinMonitoringPortal.Data.Data.Trade
{
	public class EcoPoint
	{
		public int Id { get; set; }
		public DateTime Time { get; set; }
		public decimal Value { get; set; }
		public string TimeFormatted => Time.AddHours(3).ToString("yyyy-MM-dd hh:mm:ss");
	}
}
