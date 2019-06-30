using System;
using AutoMapper;
using CoinMonitoringPortal.Business.Base;
using CoinMonitoringPortal.Business.KeyHolders;
using CoinMonitoringPortal.Business.RestClient;
using CoinMonitoringPortal.Data.Data.Account;
using CoinMonitoringPortal.Data.Messages.Action;
using CoinMonitoringPortal.Interfaces;

namespace CoinMonitoringPortal.Business
{
	public class AccountFacade: IAccountFacade
	{
		private readonly IDataRestClient _client;

		public AccountFacade()
		{
			_client = new DataRestClient();
		}

		public bool Login(LoginData loginData)
		{
			LoginRequest request = new LoginRequest
			{
				UserName = loginData.UserName,
				Password = loginData.Password
			};

			LoginResponse response = _client.Login(request);

			if (response.Success)
			{
				UserAuthenticationData userAuthentication = Mapper.Map<UserAuthenticationData>(response.User);

				if (response.PortfolioDatas != null)
				{
					userAuthentication.PortfolioData = response.PortfolioDatas;
				}

				SessionHelper.SetToSession(SessionKeyHolder.UserAuthorizationDataKey, userAuthentication);
				return true;
			}

			return false;
		}

		public RegisterResult Register(RegisterData registerData)
		{
			RegisterResult result = new RegisterResult();
			
			if (registerData.Password.Length < 6 || registerData.Password != registerData.PasswordRepeat)
			{
				result.Success = false;
				result.ErrorMessage = "Password does not meet criteria";
			}
			else
			{
				RegisterRequest request = new RegisterRequest
				{
					UserName = registerData.UserName,
					Email = registerData.Email,
					Password = registerData.Password,
				};

				RegisterResponse response = _client.Register(request);

				if (!response.Success)
				{
					result.Success = false;
					result.ErrorMessage = response.Error;
				}

				result.Success = true;
			}

			return result;
		}

		public bool IsAuthenticated()
		{
			return GetUserAuthenticationData() != null;
		}

		public UserAuthenticationData GetUserAuthenticationData()
		{
			return SessionHelper.GetFromSession<UserAuthenticationData>(SessionKeyHolder.UserAuthorizationDataKey);
		}

		public void Logout()
		{
			SessionHelper.ClearSession();
		}

		public AuthKeysResponse GetAuthKeys()
		{
			AuthKeysRequest request = new AuthKeysRequest
			{
				UserNr = GetUserAuthenticationData().UserNr
			};

			AuthKeysResponse response = _client.GetAuthKeys(request);
			return response;
		}

		public UpdateUserResponse UpdateUser(UpdateUserData data)
		{
			UpdateUserRequest request = new UpdateUserRequest
			{
				UserNr = GetUserAuthenticationData().UserNr,
				Email = data.Email
			};

			UpdateUserResponse response = _client.UpdateUser(request);

			return response;
		}

		public ChangeUserPasswordResponse ChangeUserPassword(ChangeUserPasswordData data)
		{
			if (data.NewPassword.Length < 6 || data.NewPassword != data.NewPasswordRepeat)
			{
				return new ChangeUserPasswordResponse
				{
					Success = false,
					Error = "Password does not meet criteria"
				};
			}

			ChangeUserPasswordRequest request = new ChangeUserPasswordRequest
			{
				UserNr = GetUserAuthenticationData().UserNr,
				NewPassword = data.NewPassword
			};

			ChangeUserPasswordResponse response = _client.ChangeUserPassword(request);

			return response;
		}

		public CreateAuthKeyResponse CreateAuthKey(CreateAuthKeyData data)
		{
			CreateAuthKeyRequest request = new CreateAuthKeyRequest
			{
				AuthKey = new AuthKey
				{
					UserNr = GetUserAuthenticationData().UserNr,
					ExchangeType = data.ExchangeType,
					KeyValue = data.KeyValue,
					SecretValue = data.SecretValue

				}
			};

			CreateAuthKeyResponse response = _client.CreateAuthKey(request);

			return response;
		}

		public DeleteAuthKeyResponse DeleteAuthKey(DeleteAuthKeyRequest data)
		{
			data.UserNr = GetUserAuthenticationData().UserNr;
			DeleteAuthKeyResponse response = _client.DeleteAuthKey(data);

			return response;
		}
	}
}
