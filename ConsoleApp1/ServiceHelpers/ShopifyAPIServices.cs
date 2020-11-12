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

            //  WebRequest request = WebRequest.Create("https://verser-online-store.myshopify.com/admin/api/2020-07/orders.json?status=any");
            // Set the credentials.
            //request.Credentials = new NetworkCredential("f2f0ba5cff55bdcddba3a63e33602b74", "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");
            WebRequest request = WebRequest.Create("https://9ca3419a9b10bed6c7fb8a0cdba7bd8e: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@numobile.myshopify.com/admin/api/2020-10/orders.json");
            request.Credentials = new NetworkCredential("9ca3419a9b10bed6c7fb8a0cdba7bd8e", "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");
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
            var fulFillmentItem = new Fulfillment();

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
                string ContactNo = add["phone"];
                if (!string.IsNullOrEmpty(ContactNo))
                {
                    theModel.ContactNumber = Convert.ToInt32(ContactNo.Replace(" ", string.Empty).Replace("+61",string.Empty).Trim());
                }                
                theModel.OrderType = "PhoneOnly";
                theModel.OrderSource = "ShopifyPortal";
                theModel.Surname = add["first_name"];
                modelCollection.Add(theModel);

                
            }
            fulFillmentItem.line_items = new Line_Items1[modelCollection.Count];
            int lineItemcount = 0;
            foreach (OrderViewModel theModel in modelCollection)
            {
                fulFillmentItem.line_items[lineItemcount] = new Line_Items1 {  id=theModel.ID, product_id = theModel.ID};
                //var ReturnResponse = OrdersHelperService.CreateOrder(theModel);
                lineItemcount++;
                //LoggerManager.Writelog("info", $"response:{ReturnResponse}");
            }
            reader.Close();
            dataStream.Close();
            response.Close();
        }
    }
}
