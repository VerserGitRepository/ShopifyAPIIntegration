using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.ServiceHelpers
{
   
    public class TokenInitiator
    {
        public static string tokenkey;
        public static string GetTokenDetails()
        {
            string TokenBaseUri = ConfigurationManager.AppSettings["TokenApiBaseUri"];

            Dictionary<string, string> tokenDetails = null;
            try
            {
                using (var client = new HttpClient())
                {
                    var login = new Dictionary<string, string>
                   {
                       {"grant_type", "password"},
                       {"username", "VerserMintAdmin@verser.com.au"},
                       {"password", "Verser@2018"},
                   };

                    var resp = client.PostAsync(TokenBaseUri, new FormUrlEncodedContent(login));
                    resp.Wait(TimeSpan.FromSeconds(10));

                    if (resp.IsCompleted)
                    {
                        if (resp.Result.Content.ReadAsStringAsync().Result.Contains("access_token"))
                        {
                            tokenDetails = JsonConvert.DeserializeObject<Dictionary<string, string>>(resp.Result.Content.ReadAsStringAsync().Result);
                            tokenkey = tokenDetails.FirstOrDefault().Value.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return tokenkey;
        }
    }
}
