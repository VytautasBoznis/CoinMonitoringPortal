using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoinMonitoringPortal.Data.Enums;

namespace CoinMonitoringPortal.Data.Data.Exchange
{
	public class ExchangePair
	{
		public int PairNr { get; set; }
		public ExchangeTypeEnum ExchangeType { get; set; }
		public string Symbol1 { get; set; }
		public string Symbol2 { get; set; }
	}
}
