using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ShopifyOrdersEngine.Models.FullFillmentModel
{
    public class Rootobject
    {
        public Fulfillment fulfillment { get; set; }
    }
    public class Fulfillment
    {
        public string tracking_number { get; set; }
      //  public Line_Items[] line_items { get; set; }
        public long location_id { get; set; }      
        public object tracking_url { get; set; }
        public object[] tracking_urls { get; set; }
        public bool notify_customer { get; set; }
    }

    //public class Line_Items
    //{
    //    public string id { get; set; }
    //    public int quantity { get; set; }
    //}

    public class FulfillOrder
    {
        public void FulfillOrderLineItem()
        {
            //POST /admin/api/2020-07/orders/450789469/fulfillments.json  //URL
            string ConsignmentID = "C7SZ50005296";
            var root = new Rootobject();
            root.fulfillment = new Fulfillment();
            root.fulfillment.notify_customer = true;
            root.fulfillment.tracking_number = ConsignmentID;
          //  root.fulfillment.line_items = new List<Line_Items>() { new Line_Items() { id = "1234566645", quantity = 1 } }.ToArray();
            root.fulfillment.tracking_urls = new List<string>() { $"https://startrack.com.au/track/search/{ConsignmentID}" }.ToArray();
            var json = JsonConvert.SerializeObject(root);
            Console.WriteLine(json);
        }
    }
}
