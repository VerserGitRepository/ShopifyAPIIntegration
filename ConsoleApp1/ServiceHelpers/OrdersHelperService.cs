using ConsoleApp1.Models;
using Newtonsoft.Json;
using ShopifyOrdersEngine.LogService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.ServiceHelpers
{
    public class OrdersHelperService
    {
        public static string CreateOrder(OrderViewModel NewManualOrder)
        {
            List<OrderViewModel> ordermodel = new List<OrderViewModel>();
            string response = string.Empty;
            string CreateOrderURi = System.Configuration.ConfigurationManager.AppSettings["rooturi"] + System.Configuration.ConfigurationManager.AppSettings["CreateOrder"];
            string token = TokenInitiator.GetTokenDetails(); //System.Web.HttpContext.Current.Session["BearerToken"].ToString();
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
                response = ex.Message;
            }
            return response;
        }
    }
}
