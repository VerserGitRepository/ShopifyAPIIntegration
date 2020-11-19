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
               // LoggerManager.Writelog("info", $"response:{response}");
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
            //int Order_quantity = 1;
            string strOrder_quantity = string.Empty;
            string _Shopify_OrderNumber = string.Empty;
            JArray array = new JArray();
            JObject joResponse = JObject.Parse(responseFromServer);
            array = (JArray)joResponse["orders"];

            var parsedObject = JObject.Parse(responseFromServer);
            var popupJson = parsedObject["orders"].ToString();
            var popupObj = JsonConvert.DeserializeObject(responseFromServer);
            dynamic DynamicData = JsonConvert.DeserializeObject(responseFromServer);
            var modelCollection = new List<OrderViewModel>();
            string token = TokenInitiator.GetTokenDetails();
            if (token ==null)
            {
                return;
            }
         var _ListOfOpenOrders = OrdersHelperService.OpenShopifyOrders(token);

            foreach (dynamic order in DynamicData["orders"])
            {
                //var theModel = new OrderViewModel();                
                //string s = order["id"];
                //theModel.TIABOrderID = s;
                //var add = order["shipping_address"];
                //var order_lineItems = order["line_items"][0];  
                //theModel.FirstName = add["first_name"];
                //theModel.Surname = add["last_name"];
                //theModel.AddressLine1 = add["address1"];
                //theModel.Locality = add["city"];
                //theModel.SKU = order_lineItems["sku"];
                //theModel.State = add["province_code"];
                //theModel.Postcode = add["zip"];
                //theModel.Shopify_OrderNumber = order["order_number"];
                //_Shopify_OrderNumber= order["order_number"];
                //string ContactNo = add["phone"];
                //strOrder_quantity =  order_lineItems["quantity"];
                //if (!string.IsNullOrEmpty(strOrder_quantity))
                //{                  
                //    if (Convert.ToInt32(strOrder_quantity) >1)
                //    {
                //        Order_quantity = Convert.ToInt32(strOrder_quantity);
                //    } 
                //}
                //if (!string.IsNullOrEmpty(ContactNo))
                //{
                //    theModel.ContactNumber = Convert.ToInt32(ContactNo.Replace(" ", string.Empty).Replace("+61", string.Empty).Trim());
                //}
                //theModel.OrderType = "PhoneOnly";
                //theModel.OrderSource = "ShopifyPortal";              
                //theModel.OrderNumber = order["order_number"];
                if (order["line_items"].Count > 0)
                {
                    foreach (var item in order["line_items"])
                    {
                        if (item["quantity"] >= 1)
                        {
                            int quantity = item["quantity"];
                            for (int i = 1; i <= quantity; i++)
                            {
                                
                              modelCollection.Add(FillModel(order));
                            }
                        }
                    }
                }
            }          
                foreach (OrderViewModel theModel in modelCollection)
                {
                    if (_ListOfOpenOrders.Count > 0)
                    {
                        if (_ListOfOpenOrders.Where(o => o.TIABOrderID == theModel.TIABOrderID && o.Shopify_OrderNumber == theModel.Shopify_OrderNumber && o.OrderSource.Contains("ShopifyPortal")).FirstOrDefault() == null)
                        {
                        if (theModel.Shopify_OrderNumber == "1600")
                        {
                            LoggerManager.Writelog("info", $"Request: Shopify Order Sent {theModel.Shopify_OrderNumber}");                           
                        OrdersHelperService.CreateOrder(theModel, token);
                        }
                    }
                    }
                    else
                    {
                    if (theModel.Shopify_OrderNumber == "1600")
                    {
                        LoggerManager.Writelog("info", $"Request: Shopify Order Sent {theModel.Shopify_OrderNumber}");
                        OrdersHelperService.CreateOrder(theModel, token);
                    }                       
                    }
                    reader.Close();
                    dataStream.Close();
                    response.Close();
                }
            }

        private static OrderViewModel FillModel(dynamic order)
        {
            var theModel = new OrderViewModel();
            string s = order["id"];
            theModel.TIABOrderID = s;
            var add = order["shipping_address"];
            var order_lineItems = order["line_items"][0];
            theModel.FirstName = add["first_name"];
            theModel.Surname = add["last_name"];
            theModel.AddressLine1 = add["address1"];
            theModel.Locality = add["city"];
            theModel.SKU = order_lineItems["sku"];
            theModel.State = add["province_code"];
            theModel.Postcode = add["zip"];
            theModel.Shopify_OrderNumber = order["order_number"];
            //_Shopify_OrderNumber = order["order_number"];
            string ContactNo = add["phone"];
           // strOrder_quantity = order_lineItems["quantity"];
            //if (!string.IsNullOrEmpty(strOrder_quantity))
            //{
            //    if (Convert.ToInt32(strOrder_quantity) > 1)
            //    {
            //        Order_quantity = Convert.ToInt32(strOrder_quantity);
            //    }
            //}
            if (!string.IsNullOrEmpty(ContactNo))
            {
                theModel.ContactNumber = Convert.ToInt32(ContactNo.Replace(" ", string.Empty).Replace("+61", string.Empty).Trim());
            }
            theModel.OrderType = "PhoneOnly";
            theModel.OrderSource = "ShopifyPortal";
            theModel.OrderNumber = order["order_number"];
            return theModel;

        }
    }
}
