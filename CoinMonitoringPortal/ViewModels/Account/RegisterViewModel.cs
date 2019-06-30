using CoinMonitoringPortal.Portal.ViewModels.Base;

namespace CoinMonitoringPortal.Portal.ViewModels.Account
{
	public class RegisterViewModel: BaseViewModel
	{
		public string UserName { get; set; }
		public string Password { get; set; }
		public string PasswordRepeat { get; set; }
		public string Email { get; set; }
	}
}