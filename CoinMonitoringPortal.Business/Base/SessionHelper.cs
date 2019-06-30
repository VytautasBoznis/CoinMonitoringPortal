using System.Web;
using CoinMonitoringPortal.Business.KeyHolders;

namespace CoinMonitoringPortal.Business.Base
{
	public static class SessionHelper
	{
		public static void SetToSession<T>(string key, T data)
		{
			HttpContext.Current.Session[key] = data;
		}

		public static T GetFromSession<T>(string key)
		{
			return (T) HttpContext.Current.Session[key];
		}

		public static void ClearSession()
		{
			HttpContext.Current.Session[SessionKeyHolder.UserAuthorizationDataKey] = null;
		}
	}
}
