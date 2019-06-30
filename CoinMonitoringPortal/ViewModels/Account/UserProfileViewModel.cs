using System.Collections.Generic;
using CoinMonitoringPortal.Data.Data.Account;
using CoinMonitoringPortal.Data.Messages.Action;
using CoinMonitoringPortal.Portal.ViewModels.Base;

namespace CoinMonitoringPortal.Portal.ViewModels.Account
{
	public class UserProfileViewModel: BaseViewModel
	{
		public UpdateUserData UpdateUser { get; set; }
		public string UpdateUserError { get; set; }

		public ChangeUserPasswordData ChangeUserPassword { get; set; }
		public string ChangeUserPasswordError { get; set; }

		public AuthKeysResponse AuthKeys { get; set; }
	}
}