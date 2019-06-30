using System.Collections.Generic;
using CoinMonitoringPortal.Business.Base;
using CoinMonitoringPortal.Business.KeyHolders;
using CoinMonitoringPortal.Business.RestClient;
using CoinMonitoringPortal.Data.Data.Account;
using CoinMonitoringPortal.Data.Data.Trade;
using CoinMonitoringPortal.Data.Messages.Trade;
using CoinMonitoringPortal.Interfaces;

namespace CoinMonitoringPortal.Business
{
	public class ScheduleFacade: IScheduleFacade
	{
		private readonly IDataRestClient _client;
		private readonly IAccountFacade _accountFacade;

		public ScheduleFacade(IAccountFacade accountFacade)
		{
			_accountFacade = accountFacade;
			_client = new DataRestClient();
		}

		public List<ScheduledTrade> GetScheduledTrades()
		{
			GetScheduledTradesRequest request = new GetScheduledTradesRequest
			{
				UserNr = _accountFacade.GetUserAuthenticationData().UserNr,
			};

			GetScheduledTradesResponse response = _client.GetScheduledTrades(request);

			return response.Trades ?? new List<ScheduledTrade>();
		}

		public SynchronizePortfolioResponse SynchronizePortfolio()
		{
			SynchronizePortfolioRequest request = new SynchronizePortfolioRequest
			{
				UserNr =  _accountFacade.GetUserAuthenticationData().UserNr
			};

			SynchronizePortfolioResponse response = _client.SynchronizePortfolio(request);

			UserAuthenticationData userData = _accountFacade.GetUserAuthenticationData();
			userData.PortfolioData = response.PortfolioData;

			SessionHelper.SetToSession(SessionKeyHolder.UserAuthorizationDataKey, userData);
			return response;
		}

		public CreateScheduledTradesResponse CreateScheduledTrades(CreateScheduledTradesRequest request)
		{
			request.UserNr = _accountFacade.GetUserAuthenticationData().UserNr;

			CreateScheduledTradesResponse response = _client.CreateScheduledTrades(request);
			return response;
		}

		public GetChartDataResponse GetChartData(GetChartDataRequest request)
		{
			GetChartDataResponse response = _client.GetChartData(request);
			return response;
		}

		public DeleteScheduledTradeResponse DeleteScheduledTrade(DeleteScheduledTradeRequest request)
		{
			request.UserNr = _accountFacade.GetUserAuthenticationData().UserNr;

			DeleteScheduledTradeResponse response = _client.DeleteScheduledTrade(request);
			return response;
		}

		public ResetScheduledTradeResponse ResetScheduledTrade(ResetScheduledTradeRequest request)
		{
			request.UserNr = _accountFacade.GetUserAuthenticationData().UserNr;

			ResetScheduledTradeResponse response = _client.ResetScheduledTrade(request);
			return response;
		}
	}
}
