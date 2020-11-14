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
   public class Program
    {
        static void Main(string[] args)
        {
            LoggerManager.Writelog("info", "Orders Pull Request Initiated");
             ShopifyAPIServices.FetchAndPushShopifyOrders();
            LoggerManager.Writelog("info", "Orders Pull Request Completed");

            //fulFillmentItem.line_items = new Line_Items1[modelCollection.Count];
            //ShopifyOrdersEngine.Models.FullFillmentModel.Fulfillment item = FulfillOrder.FulfillOrderLineItem();
            //OrdersHelperService.CreateFulfillment(item);
            //var fulfill = new FulfillOrder();
            //fulfill.FulfillOrderLineItem();
            //  Console.ReadKey();
        }
    }
}
