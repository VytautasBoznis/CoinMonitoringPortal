using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinMonitoringPortal.Data.Enums
{
	public enum TradeStatusEnum: short
	{
		Unknown = 0,
		Pending = 1,
		Valid = 2,
		Failed = 3,
		Completed = 4
	}
}
