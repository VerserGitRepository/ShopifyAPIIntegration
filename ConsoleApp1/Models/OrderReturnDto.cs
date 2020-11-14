using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopifyOrdersEngine.Models
{
   public class OrderReturnDto
    {
        public string VerserOrderID { get; set; }
        public string TIABOrderID { get; set; }
        public string OrderStatus { get; set; }
        public string ErrorMessage { get; set; }
    }
}
