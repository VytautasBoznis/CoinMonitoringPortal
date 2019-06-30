using CoinMonitoringPortal.Portal.ViewModels.Base;

namespace CoinMonitoringPortal.Portal.ViewModels.Account
{
	public class LoginViewModel: BaseViewModel
	{
		public string UserName { get; set; }
		public string Password { get; set; }
	}
}