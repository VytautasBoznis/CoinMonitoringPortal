using System.Collections.Generic;

namespace CoinMonitoringPortal.Data.Data.Trade
{
	public class ChartData
	{
		public string Name { get; set; }
		public List<ChartPoint> ChartPointsMain { get; set; }
		public EcoIndexChart RSI { get; set; }
		public EcoIndexChart EMA { get; set; }
		public EcoIndexChart ForceIndex { get; set; }
	}
}
