using ConsoleApp1.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ShopifyOrdersEngine.LogService;
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

            WebRequest request = WebRequest.Create("https://verser-online-store.myshopify.com/admin/api/2020-07/orders.json?status=any");
            // Set the credentials.
            request.Credentials = new NetworkCredential("f2f0ba5cff55bdcddba3a63e33602b74", "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");
            // Get the response.
            HttpWebResponse response = null;
            try
            {
                // This is where the HTTP GET actually occurs.
                response = (HttpWebResponse)request.GetResponse();
                LoggerManager.Writelog("info", $"response:{response}");
            }
            catch (Exception ea)
            {
                LoggerManager.Writelog("error", $"Error Occured While Creating Order: {ea.Message}");
            }
            // Display the status. You want to see "OK" here.
            Console.WriteLine(response.StatusDescription);
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader
            StreamReader reader = new StreamReader(dataStream);
            // Read the content. T
            var responseFromServer = reader.ReadToEnd();

            var result = JObject.Parse(responseFromServer);   //parses entire stream into JObject, from which you can use to query the bits you need.
            var items = result.Children().ToList();   //Get the sections you need and save as enumerable (will be in the form of JTokens)

            List<orders> infoList = new List<orders>();  //init new list to store the objects.
            var parsedObject = JObject.Parse(responseFromServer);
            var popupJson = parsedObject["orders"].ToString();
            var popupObj = JsonConvert.DeserializeObject(responseFromServer);
            dynamic DynamicData = JsonConvert.DeserializeObject(responseFromServer);
            var modelCollection = new List<OrderViewModel>();
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
                theModel.SKU = "S9PL64PL";//order_lineItems[0]["sku"];
                theModel.State = add["province_code"];
                theModel.Postcode = add["zip"];
                theModel.ContactNumber = 0466877007;//add["phone"];
                theModel.OrderType = "PhoneOnly";
                theModel.OrderSource = "ShopifyPortal";
                theModel.Surname = add["first_name"];
                modelCollection.Add(theModel);
            }
            foreach (OrderViewModel theModel in modelCollection)
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
