using CoinMonitoringPortal.Data.Enums;

namespace CoinMonitoringPortal.Data.Data.AutoAction
{
	public class TradeCriteria
	{
		public int TradeNr { get; set; }
		public int CriteriaNr { get; set; }
		public EcoIndexTypeEnum EcoIndexType { get; set; }
		public CriteriaValueTypeEnum CriteriaValueType { get; set; }
		public decimal Value { get; set; }
		public decimal Weight { get; set; }
	}
}
