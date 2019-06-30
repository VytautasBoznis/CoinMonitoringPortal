using System;
using System.Collections.Generic;
using CoinMonitoringPortal.Data.Data.Exchange;
using CoinMonitoringPortal.Data.Enums;

namespace CoinMonitoringPortal.Data.Data.AutoAction
{
	public class TradeData
	{
		public int TradeNr { get; set; }
		public DateTime CreationDate { get; set; }
		public TradeStatusEnum TradeStatus { get; set; }
		public TradeActionEnum TradeAction { get; set; }
		public DateTime? CompletionTime { get; set; }
		public decimal Value { get; set; }
		public List<TradeCriteria> Criteria { get; set; }
		public ExchangePair ExchangePair { get; set; }
	}
}
