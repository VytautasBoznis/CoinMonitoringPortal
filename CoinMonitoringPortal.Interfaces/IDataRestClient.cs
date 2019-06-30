using CoinMonitoringPortal.Data.Messages.Action;
using CoinMonitoringPortal.Data.Messages.Trade;

namespace CoinMonitoringPortal.Interfaces
{
	public interface IDataRestClient
	{
		LoginResponse Login(LoginRequest request);
		RegisterResponse Register(RegisterRequest request);
		AuthKeysResponse GetAuthKeys(AuthKeysRequest request);
		UpdateUserResponse UpdateUser(UpdateUserRequest request);
		ChangeUserPasswordResponse ChangeUserPassword(ChangeUserPasswordRequest request);
		CreateAuthKeyResponse CreateAuthKey(CreateAuthKeyRequest request);
		DeleteAuthKeyResponse DeleteAuthKey(DeleteAuthKeyRequest request);
		GetScheduledTradesResponse GetScheduledTrades(GetScheduledTradesRequest request);
		SynchronizePortfolioResponse SynchronizePortfolio(SynchronizePortfolioRequest request);
		CreateScheduledTradesResponse CreateScheduledTrades(CreateScheduledTradesRequest request);
		DeleteScheduledTradeResponse DeleteScheduledTrade(DeleteScheduledTradeRequest request);
		ResetScheduledTradeResponse ResetScheduledTrade(ResetScheduledTradeRequest request);
		GetChartDataResponse GetChartData(GetChartDataRequest request);
	}
}
