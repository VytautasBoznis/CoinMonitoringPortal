using AutoMapper;
using AutoMapper.Configuration;
using CoinMonitoringPortal.Portal.App_Start.Profiles;

namespace CoinMonitoringPortal.Portal.App_Start
{
	public static class AutoMapperConfig
	{
		public static void Configure()
		{
			MapperConfigurationExpression configuration = new MapperConfigurationExpression();

			AddProfiles(configuration);

			Mapper.Initialize(configuration);
		}

		public static void AddProfiles(MapperConfigurationExpression configuration)
		{
			configuration.AddProfile<AccountProfile>();
		}
	}
}