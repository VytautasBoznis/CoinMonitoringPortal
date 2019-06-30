using CoinMonitoringPortal.Data.Data.Account;
using CoinMonitoringPortal.Data.Messages.Action;

namespace CoinMonitoringPortal.Interfaces
{
	public interface IAccountFacade
	{
		bool Login(LoginData loginData);
		RegisterResult Register(RegisterData registerData);
		bool IsAuthenticated();
		UserAuthenticationData GetUserAuthenticationData();
		void Logout();

		AuthKeysResponse GetAuthKeys();
		UpdateUserResponse UpdateUser(UpdateUserData data);
		ChangeUserPasswordResponse ChangeUserPassword(ChangeUserPasswordData data);
		CreateAuthKeyResponse CreateAuthKey(CreateAuthKeyData data);
		DeleteAuthKeyResponse DeleteAuthKey(DeleteAuthKeyRequest data);
	}
}
