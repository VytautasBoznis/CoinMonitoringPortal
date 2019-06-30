using CoinMonitoringPortal.Data.Data.Account;

namespace CoinMonitoringPortal.Data.Messages.Action
{
	public class CreateAuthKeyRequest
	{
		public AuthKey AuthKey { get; set; }
	}

	public class CreateAuthKeyResponse
	{
		public bool Success { get; set; }
		public string Error { get; set; }
	}
}
