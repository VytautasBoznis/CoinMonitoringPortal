using System.Collections.Generic;
using CoinMonitoringPortal.Data.Data.Account;

namespace CoinMonitoringPortal.Data.Messages.Action
{
	public class AuthKeysRequest
	{
		public int UserNr { get; set; }
	}

	public class AuthKeysResponse
	{
		public bool Success { get; set; }
		public string Error { get; set; }
		public List<AuthKey> AuthKeys { get; set; }
	}
}
