namespace CoinMonitoringPortal.Portal.ViewModels.Base
{
	public class BaseViewModel
	{
		public BaseViewModel()
		{
			ErrorMessage = "";
		}

		public string ErrorMessage { get; set; }
	}
}