using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopifyOrdersEngine.LogService
{
   public class LoggerManager
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
     
        public static void Writelog(string LogType, string message)
        {
            if (LogType == "info")
                _logger.Info(message);
            if (LogType == "error")
                _logger.Error(message);
        }
    }
}
