using AutoMapper;
using CoinMonitoringPortal.Data.Data.Account;
using CoinMonitoringPortal.Portal.ViewModels.Account;

namespace CoinMonitoringPortal.Portal.App_Start.Profiles
{
	public class AccountProfile : Profile
	{
		public AccountProfile()
		{
			CreateMap<UserAuthenticationData, User>().ReverseMap();
			CreateMap<LoginViewModel, LoginData>().ReverseMap();
			CreateMap<RegisterViewModel, RegisterData>().ReverseMap();
		}
	}
}