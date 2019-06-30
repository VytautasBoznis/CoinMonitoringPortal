using System;
using System.Configuration;
using System.Web.UI.WebControls;
using CoinMonitoringPortal.Data.Messages.Action;
using CoinMonitoringPortal.Data.Messages.Trade;
using CoinMonitoringPortal.Interfaces;
using RestSharp;

namespace CoinMonitoringPortal.Business.RestClient
{
	public class DataRestClient: IDataRestClient
	{
		#region Constants

		private readonly string _dataManagementServiceUrl = ConfigurationManager.AppSettings["CoinMonitoringService"];
		private readonly RestSharp.RestClient _client;

		#endregion

		#region Constructor

		public DataRestClient()
		{
			_client = new RestSharp.RestClient(_dataManagementServiceUrl);
		}

		#endregion

		public LoginResponse Login(LoginRequest request)
		{
			RestRequest restRequest = new RestRequest("Account/Login", Method.POST);
			restRequest.AddJsonBody(request);

			LoginResponse response = _client.Execute<LoginResponse>(restRequest).Data;
			return response;
		}

		public RegisterResponse Register(RegisterRequest request)
		{
			RestRequest restRequest = new RestRequest("Account/Register", Method.POST);
			restRequest.AddJsonBody(request);

			RegisterResponse response = _client.Execute<RegisterResponse>(restRequest).Data;
			return response;
		}

		public AuthKeysResponse GetAuthKeys(AuthKeysRequest request)
		{
			RestRequest restRequest = new RestRequest("Account/GetAuthKeys", Method.POST);
			restRequest.AddJsonBody(request);

			AuthKeysResponse response = _client.Execute<AuthKeysResponse>(restRequest).Data;
			return response;
		}

		public UpdateUserResponse UpdateUser(UpdateUserRequest request)
		{
			RestRequest restRequest = new RestRequest("Account/UpdateUser", Method.POST);
			restRequest.AddJsonBody(request);

			UpdateUserResponse response = _client.Execute<UpdateUserResponse>(restRequest).Data;
			return response;
		}

		public ChangeUserPasswordResponse ChangeUserPassword(ChangeUserPasswordRequest request)
		{
			RestRequest restRequest = new RestRequest("Account/ChangePassword", Method.POST);
			restRequest.AddJsonBody(request);

			ChangeUserPasswordResponse response = _client.Execute<ChangeUserPasswordResponse>(restRequest).Data;
			return response;
		}

		public CreateAuthKeyResponse CreateAuthKey(CreateAuthKeyRequest request)
		{
			RestRequest restRequest = new RestRequest("Account/CreateAuthKey", Method.POST);
			restRequest.AddJsonBody(request);

			CreateAuthKeyResponse response = _client.Execute<CreateAuthKeyResponse>(restRequest).Data;
			return response;
		}

		public DeleteAuthKeyResponse DeleteAuthKey(DeleteAuthKeyRequest request)
		{
			RestRequest restRequest = new RestRequest("Account/DeleteAuthKey", Method.POST);
			restRequest.AddJsonBody(request);

			DeleteAuthKeyResponse response = _client.Execute<DeleteAuthKeyResponse>(restRequest).Data;
			return response;
		}

		public GetScheduledTradesResponse GetScheduledTrades(GetScheduledTradesRequest request)
		{
			RestRequest restRequest = new RestRequest("Trade/GetScheduledTrades", Method.POST);
			restRequest.AddJsonBody(request);

			GetScheduledTradesResponse response = _client.Execute<GetScheduledTradesResponse>(restRequest).Data;
			return response;
		}

		public SynchronizePortfolioResponse SynchronizePortfolio(SynchronizePortfolioRequest request)
		{
			RestRequest restRequest = new RestRequest("Trade/SynchronizePortfolio", Method.POST);
			restRequest.AddJsonBody(request);

			SynchronizePortfolioResponse response = _client.Execute<SynchronizePortfolioResponse>(restRequest).Data;
			return response;
		}

		public CreateScheduledTradesResponse CreateScheduledTrades(CreateScheduledTradesRequest request)
		{
			RestRequest restRequest = new RestRequest("Trade/CreateScheduledTrade", Method.POST);
			restRequest.AddJsonBody(request);

			CreateScheduledTradesResponse response = _client.Execute<CreateScheduledTradesResponse>(restRequest).Data;
			return response;
		}

		public DeleteScheduledTradeResponse DeleteScheduledTrade(DeleteScheduledTradeRequest request)
		{
			RestRequest restRequest = new RestRequest("Trade/DeleteScheduledTrade", Method.POST);
			restRequest.AddJsonBody(request);

			DeleteScheduledTradeResponse response = _client.Execute<DeleteScheduledTradeResponse>(restRequest).Data;
			return response;
		}

		public ResetScheduledTradeResponse ResetScheduledTrade(ResetScheduledTradeRequest request)
		{
			RestRequest restRequest = new RestRequest("Trade/ResetScheduledTrade", Method.POST);
			restRequest.AddJsonBody(request);

			ResetScheduledTradeResponse response = _client.Execute<ResetScheduledTradeResponse>(restRequest).Data;
			return response;
		}

		public GetChartDataResponse GetChartData(GetChartDataRequest request)
		{
			RestRequest restRequest = new RestRequest("Trade/GetChartData", Method.POST);
			restRequest.AddJsonBody(request);

			IRestResponse<GetChartDataResponse> response = _client.Execute<GetChartDataResponse>(restRequest);
			return response.Data;
		}
	}
}
