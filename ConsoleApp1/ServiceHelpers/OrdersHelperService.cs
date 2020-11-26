using ConsoleApp1.Models;
using Newtonsoft.Json;
using ShopifyOrdersEngine.LogService;
using ShopifyOrdersEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ConsoleApp1.ServiceHelpers
{
    public class OrdersHelperService
    {
        public static void CreateOrder(OrderViewModel NewManualOrder, string token)
        {           
            string CreateOrderURi = System.Configuration.ConfigurationManager.AppSettings["rooturi"] + System.Configuration.ConfigurationManager.AppSettings["CreateOrder"];           
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var resp = client.PostAsJsonAsync(CreateOrderURi, NewManualOrder);
                    resp.Wait(TimeSpan.FromSeconds(100));
                    if (resp.IsCompleted)
                    {
                        if (resp.Result.StatusCode == HttpStatusCode.Unauthorized)
                        {
                            LoggerManager.Writelog("error", "Authorization failed. Token expired or invalid.");  
                        }
                        else if (resp.Result.StatusCode == HttpStatusCode.OK)
                        {
                           var response = resp.Result.Content.ReadAsStringAsync().Result;
                           var ResponseData = JsonConvert.DeserializeObject<List<OrderReturnDto>>(response);
                            if (ResponseData.First().VerserOrderID != null)
                            {
                                LoggerManager.Writelog("info", $"{ResponseData.First().VerserOrderID} Shopify - Verser Order is been Created");
                              Console.WriteLine("info", $"{ResponseData.First().VerserOrderID} Shopify - Verser Order is been Created");
                            }
                            else
                            {
                                LoggerManager.Writelog("error", $"Error Occured Please Verify Your Order Request Information. : {ResponseData.FirstOrDefault().ErrorMessage}");
                              Console.WriteLine("error", $"Error Occured Please Verify Your Order Request Information. : {ResponseData.FirstOrDefault().ErrorMessage}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Writelog("error", ex.Message);
            }           
        }

        public static List<OrderViewModel> OpenShopifyOrders(string token)
        {
            var ordermodel = new List<OrderViewModel>();
            string response = string.Empty;
            string CreateOrderURi = System.Configuration.ConfigurationManager.AppSettings["rooturi"] + System.Configuration.ConfigurationManager.AppSettings["OnOrderList"];
        
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var resp = client.GetAsync(CreateOrderURi);
                    resp.Wait(TimeSpan.FromSeconds(100));
                    if (resp.IsCompleted)
                    {
                        if (resp.Result.StatusCode == HttpStatusCode.Unauthorized)
                        {
                            LoggerManager.Writelog("error","Authorization failed. Token expired or invalid.");
                        }
                        if (resp.Result.StatusCode == HttpStatusCode.OK)
                        {
                            response = resp.Result.Content.ReadAsStringAsync().Result;
                            ordermodel = JsonConvert.DeserializeObject<List<OrderViewModel>>(response);
                        }
                        else
                        {
                            LoggerManager.Writelog("error", $"Error Occured while petching Orders Information.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Writelog("error", ex.Message);
            }
            return ordermodel;
        }

        //public static string CreateFulfillment(ShopifyOrdersEngine.Models.FullFillmentModel.Fulfillment fulfilmentItem)
        //{
        //   // ReturnModel ReturnResult = new ReturnModel();
        //    string uriAdd = "https://9ca3419a9b10bed6c7fb8a0cdba7bd8e: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@numobile.myshopify.com/admin/api/2020-10/orders/2859903582317/fulfillments.json";
        //    var credentials = new NetworkCredential("9ca3419a9b10bed6c7fb8a0cdba7bd8e", "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");
        //    using (var handler = new HttpClientHandler {Credentials= credentials })
        //    {
        //        using (HttpClient client = new HttpClient(handler))
        //        {
        //            client.BaseAddress = new Uri(uriAdd);
        //            HttpResponseMessage response = client.PostAsJsonAsync(uriAdd, fulfilmentItem).Result;
        //            if (response.IsSuccessStatusCode)
        //            {
        //                var ReturnResult = response.Content.ReadAsAsync<Fulfillment>();
        //                // HttpContext.Current.Session["ResultMessage"] = ReturnResult.Message;
        //            }
        //            else
        //            {
        //                // HttpContext.Current.Session["ErrorMessage"] = ReturnResult.Message;
        //            }
        //        }
        //    }
        //    return null;
        //}
    }
}
