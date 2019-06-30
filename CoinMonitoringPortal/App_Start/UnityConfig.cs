using System;
using CoinMonitoringPortal.Business;
using CoinMonitoringPortal.Business.RestClient;
using CoinMonitoringPortal.Interfaces;
using Unity;

namespace CoinMonitoringPortal.Portal
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion
		
        public static void RegisterTypes(IUnityContainer container)
        {
	        container.RegisterType<IAccountFacade, AccountFacade>();
	        container.RegisterType<IScheduleFacade, ScheduleFacade>();
	        container.RegisterType<IExchangeFacade, ExchangeFacade>();
        }
    }
}