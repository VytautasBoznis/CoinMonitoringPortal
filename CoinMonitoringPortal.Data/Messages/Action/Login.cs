using System.Collections.Generic;
using CoinMonitoringPortal.Data.Data.Account;
using CoinMonitoringPortal.Data.Data.Trade;

namespace CoinMonitoringPortal.Data.Messages.Action
{
	public class LoginRequest
	{
		public string UserName { get; set; }
		public string Password { get; set; }
	}

	public class LoginResponse
	{
		public bool Success { get; set; }
		public string Error { get; set; }
		public User User { get; set; }
		public List<PortfolioData> PortfolioDatas { get; set; }
	}
}
