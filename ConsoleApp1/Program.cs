using ConsoleApp1.ServiceHelpers;
using ShopifyOrdersEngine.LogService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            LoggerManager.Writelog("info", "Orders Pull Request Initiated");
            ShopifyAPIServices.FetchAndPushShopifyOrders();
        }
    }
}
