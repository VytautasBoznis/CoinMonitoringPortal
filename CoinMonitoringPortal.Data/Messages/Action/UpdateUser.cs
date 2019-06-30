namespace CoinMonitoringPortal.Data.Messages.Action
{
	public class UpdateUserRequest
	{
		public int UserNr { get; set; }
		public string Email { get; set; }
	}

	public class UpdateUserResponse
	{
		public bool Success { get; set; }
		public string Error { get; set; }
	}
}
