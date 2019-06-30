using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoinMonitoringPortal.Data.Data.AutoAction;
using CoinMonitoringPortal.Data.Data.Exchange;

namespace CoinMonitoringPortal.Data.Data.Trade
{
	public class ScheduledTrade
	{
		public int TradeNr { get; set; }
		public int UserNr { get; set; }
		public DateTime CreationDate { get; set; }
		public decimal Value { get; set; }
		public int TradeAction { get; set; }
		public int TradeStatus { get; set; }
		public DateTime? CompletionTime { get; set; }
		public int ExchangePairNr { get; set; }
		public ExchangePair ExchangePair { get; set; }
		public List<TradeCriteria> TradeCriteria { get; set; }
	}
}
