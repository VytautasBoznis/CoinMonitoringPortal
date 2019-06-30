using System.Collections.Generic;

namespace CoinMonitoringPortal.Data.Data.Trade
{
	public class PortfolioData
	{
		public int ExchangeType { get; set; }
		public List<CurrencyData> CurrencyDatas { get; set; }
	}
}
