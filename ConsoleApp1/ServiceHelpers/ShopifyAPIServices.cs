using ConsoleApp1.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ShopifyOrdersEngine.LogService;
using ShopifyOrdersEngine.Models.FullFillmentModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;

namespace ConsoleApp1.ServiceHelpers
{
    public class ShopifyAPIServices
    {
        private static readonly string TimeSheetAPIURl = ConfigurationManager.AppSettings["TimeSheetBaseURL"] + ConfigurationManager.AppSettings["TimeSheetRootDirectory"];
        public static void FetchAndPushShopifyOrders()
        {

            //  WebRequest request = WebRequest.Create("https://verser-online-store.myshopify.com/admin/api/2020-07/orders.json?status=any");
            // Set the credentials.
            //request.Credentials = new NetworkCredential("f2f0ba5cff55bdcddba3a63e33602b74", "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");

            WebRequest request = WebRequest.Create("https://9ca3419a9b10bed6c7fb8a0cdba7bd8e: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@numobile.myshopify.com/admin/api/2020-10/orders.json");
            request.Credentials = new NetworkCredential("9ca3419a9b10bed6c7fb8a0cdba7bd8e", "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");
            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
                LoggerManager.Writelog("info", $"response:{response}");
            }
            catch (Exception ea)
            {
                LoggerManager.Writelog("error", $"Error Occured While Creating Order: {ea.Message}");
            }
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader
            StreamReader reader = new StreamReader(dataStream);
            // Read the content. T
            var responseFromServer = reader.ReadToEnd();
            var result = JObject.Parse(responseFromServer);   //parses entire stream into JObject, from which you can use to query the bits you need.

            var items = result.Children().ToList();   //Get the sections you need and save as enumerable (will be in the form of JTokens)

            JArray array = new JArray();
            JObject joResponse = JObject.Parse(responseFromServer);
            array = (JArray)joResponse["orders"];

            var parsedObject = JObject.Parse(responseFromServer);
            var popupJson = parsedObject["orders"].ToString();
            var popupObj = JsonConvert.DeserializeObject(responseFromServer);
            dynamic DynamicData = JsonConvert.DeserializeObject(responseFromServer);
            var modelCollection = new List<OrderViewModel>();
            var _ListOfOpenOrders = OrdersHelperService.OpenShopifyOrders();

            foreach (dynamic order in DynamicData["orders"])
            {
                string s = order["id"];
                var add = order["shipping_address"];
                var order_lineItems = order["line_items"];
                OrderViewModel theModel = new OrderViewModel();
                theModel.TIABOrderID = s;
                theModel.Surname = add["last_name"];
                theModel.FirstName = add["first_name"];
                theModel.AddressLine1 = add["address1"];
                theModel.Locality = add["city"];
                theModel.SKU = order_lineItems[0]["sku"];
                theModel.State = add["province_code"];
                theModel.Postcode = add["zip"];
                theModel.Shopify_OrderNumber = order["order_number"];
                string ContactNo = add["phone"];
                if (!string.IsNullOrEmpty(ContactNo))
                {
                    theModel.ContactNumber = Convert.ToInt32(ContactNo.Replace(" ", string.Empty).Replace("+61", string.Empty).Trim());
                }
                theModel.OrderType = "PhoneOnly";
                theModel.OrderSource = "ShopifyPortal";
                theModel.Surname = add["first_name"];
                theModel.OrderNumber = order["order_number"];
                modelCollection.Add(theModel);


            }
            //fulFillmentItem.line_items = new Line_Items1[modelCollection.Count];
            //ShopifyOrdersEngine.Models.FullFillmentModel.Fulfillment item = FulfillOrder.FulfillOrderLineItem();
            //OrdersHelperService.CreateFulfillment(item);

            foreach (OrderViewModel theModel in modelCollection)
            {
                if (_ListOfOpenOrders.Count>0)
                {               
                    if (_ListOfOpenOrders.Where(o => o.TIABOrderID == theModel.TIABOrderID && o.Shopify_OrderNumber == theModel.Shopify_OrderNumber && o.OrderSource.Contains("ShopifyPortal")).FirstOrDefault() == null )
                    {
                      var ReturnResponse = OrdersHelperService.CreateOrder(theModel);
                      LoggerManager.Writelog("info", $"response:{ReturnResponse}");
                     }
                }
                else
                {
                    var ReturnResponse = OrdersHelperService.CreateOrder(theModel);
                    LoggerManager.Writelog("info", $"response:{ReturnResponse}");
                }
                reader.Close();
                dataStream.Close();
                response.Close();
            }
        }
    }
}
