using ConsoleApp1.Models;
using ConsoleApp1.ServiceHelpers;
using Newtonsoft.Json;
using ShopifyOrdersEngine.LogService;
using ShopifyOrdersEngine.Models.FullFillmentModel;
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
            var fulfill = new FulfillOrder();
            fulfill.FulfillOrderLineItem();
            Console.ReadKey();
        }
    }
}
