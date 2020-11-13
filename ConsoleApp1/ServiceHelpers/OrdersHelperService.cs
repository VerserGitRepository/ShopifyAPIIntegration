using ConsoleApp1.Models;
using Newtonsoft.Json;
using ShopifyOrdersEngine.LogService;
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
        public static string CreateOrder(OrderViewModel NewManualOrder)
        {
            List<OrderViewModel> ordermodel = new List<OrderViewModel>();
            string response = string.Empty;
            string CreateOrderURi = System.Configuration.ConfigurationManager.AppSettings["rooturi"] + System.Configuration.ConfigurationManager.AppSettings["CreateOrder"];
            string token = TokenInitiator.GetTokenDetails(); 
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var resp = client.PostAsJsonAsync(CreateOrderURi, NewManualOrder);
                    resp.Wait(TimeSpan.FromSeconds(10));
                    if (resp.IsCompleted)
                    {
                        if (resp.Result.StatusCode == HttpStatusCode.Unauthorized)
                        {
                            Console.WriteLine("Authorization failed. Token expired or invalid.");  
                        }
                        else
                        {
                            response = resp.Result.Content.ReadAsStringAsync().Result;
                            ordermodel = JsonConvert.DeserializeObject<List<OrderViewModel>>(response);
                            if (ordermodel.First().VerserOrderID != null)
                            {
                                response = ordermodel.First().VerserOrderID + " Order is been created and ready to Process. Go To Orders for Processing";
                                LoggerManager.Writelog("info", $"{response}");
                            }
                            else
                            {
                                response = "Error Occured Please Verify Your Order Request Information.";

                                LoggerManager.Writelog("error", $"Error Occured Please Verify Your Order Request Information. : {NewManualOrder}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Writelog("error", ex.Message);
            }
            return response;
        }


        public static List<OrderViewModel> OpenShopifyOrders()
        {
            var ordermodel = new List<OrderViewModel>();
            string response = string.Empty;
            string CreateOrderURi = System.Configuration.ConfigurationManager.AppSettings["rooturi"] + System.Configuration.ConfigurationManager.AppSettings["OnOrderList"];
            string token = TokenInitiator.GetTokenDetails();
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var resp = client.GetAsync(CreateOrderURi);
                    resp.Wait(TimeSpan.FromSeconds(10));
                    if (resp.IsCompleted)
                    {
                        if (resp.Result.StatusCode == HttpStatusCode.Unauthorized)
                        {
                            Console.WriteLine("Authorization failed. Token expired or invalid.");
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

        public static string CreateFulfillment(ShopifyOrdersEngine.Models.FullFillmentModel.Fulfillment fulfilmentItem)
        {
           // ReturnModel ReturnResult = new ReturnModel();
            string uriAdd = "https://9ca3419a9b10bed6c7fb8a0cdba7bd8e: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@numobile.myshopify.com/admin/api/2020-10/orders/2859903582317/fulfillments.json";
            var credentials = new NetworkCredential("9ca3419a9b10bed6c7fb8a0cdba7bd8e", "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");
            using (var handler = new HttpClientHandler {Credentials= credentials })
            {
                using (HttpClient client = new HttpClient(handler))
                {
                    client.BaseAddress = new Uri(uriAdd);
                    HttpResponseMessage response = client.PostAsJsonAsync(uriAdd, fulfilmentItem).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var ReturnResult = response.Content.ReadAsAsync<Fulfillment>();
                        // HttpContext.Current.Session["ResultMessage"] = ReturnResult.Message;
                    }
                    else
                    {
                        // HttpContext.Current.Session["ErrorMessage"] = ReturnResult.Message;
                    }
                }
            }
            return null;
        }
    }
}
