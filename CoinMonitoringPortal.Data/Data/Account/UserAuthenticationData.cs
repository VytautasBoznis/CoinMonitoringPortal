using System.Collections.Generic;
using CoinMonitoringPortal.Data.Data.Trade;

namespace CoinMonitoringPortal.Data.Data.Account
{
	public class UserAuthenticationData
	{
		public int UserNr { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
		public List<PortfolioData> PortfolioData { get; set; }
	}
}
