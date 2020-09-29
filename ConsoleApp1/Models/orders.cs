using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public class orders
    {
        public long id { get; set; }
        public string email { get; set; }
        public object closed_at { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public int number { get; set; }
        public object note { get; set; }
        public string token { get; set; }
        public string gateway { get; set; }
        public bool test { get; set; }
        public string total_price { get; set; }
        public string subtotal_price { get; set; }
        public int total_weight { get; set; }
        public string total_tax { get; set; }
        public bool taxes_included { get; set; }
        public string currency { get; set; }
        public string financial_status { get; set; }
        public bool confirmed { get; set; }
        public string total_discounts { get; set; }
        public string total_line_items_price { get; set; }
        public string cart_token { get; set; }
        public bool buyer_accepts_marketing { get; set; }
        public string name { get; set; }
        public string referring_site { get; set; }
        public string landing_site { get; set; }
        public object cancelled_at { get; set; }
        public object cancel_reason { get; set; }
        public string total_price_usd { get; set; }
        public string checkout_token { get; set; }
        public object reference { get; set; }
        public object user_id { get; set; }
        public object location_id { get; set; }
        public object source_identifier { get; set; }
        public object source_url { get; set; }
        public DateTime processed_at { get; set; }
        public object device_id { get; set; }
        public string phone { get; set; }
        public string customer_locale { get; set; }
        public int app_id { get; set; }
        public string browser_ip { get; set; }
        public object landing_site_ref { get; set; }
        public int order_number { get; set; }
        public object[] discount_applications { get; set; }
        public object[] discount_codes { get; set; }
        public object[] note_attributes { get; set; }
        public string[] payment_gateway_names { get; set; }
        public string processing_method { get; set; }
        public long checkout_id { get; set; }
        public string source_name { get; set; }
        public object fulfillment_status { get; set; }
        public object[] tax_lines { get; set; }
        public string tags { get; set; }
        public object contact_email { get; set; }
        public string order_status_url { get; set; }
        public string presentment_currency { get; set; }
        public Total_Line_Items_Price_Set total_line_items_price_set { get; set; }
        public Total_Discounts_Set total_discounts_set { get; set; }
        public Total_Shipping_Price_Set total_shipping_price_set { get; set; }
        public Subtotal_Price_Set subtotal_price_set { get; set; }
        public Total_Price_Set total_price_set { get; set; }
        public Total_Tax_Set total_tax_set { get; set; }
        public Line_Items[] line_items { get; set; }
        public Fulfillment[] fulfillments { get; set; }
        public Refund[] refunds { get; set; }
        public string total_tip_received { get; set; }
        public object original_total_duties_set { get; set; }
        public object current_total_duties_set { get; set; }
        public string admin_graphql_api_id { get; set; }
        public Shipping_Lines[] shipping_lines { get; set; }
        public Billing_Address billing_address { get; set; }
        public shipping_address shipping_address { get; set; }
        public Client_Details client_details { get; set; }
        public Customer customer { get; set; }
    }

    public class Total_Line_Items_Price_Set
    {
        public Shop_Money shop_money { get; set; }
        public Presentment_Money presentment_money { get; set; }
    }

    public class Shop_Money
    {
        public string amount { get; set; }
        public string currency_code { get; set; }
    }

    public class Presentment_Money
    {
        public string amount { get; set; }
        public string currency_code { get; set; }
    }

    public class Total_Discounts_Set
    {
        public Shop_Money1 shop_money { get; set; }
        public Presentment_Money1 presentment_money { get; set; }
    }

    public class Shop_Money1
    {
        public string amount { get; set; }
        public string currency_code { get; set; }
    }

    public class Presentment_Money1
    {
        public string amount { get; set; }
        public string currency_code { get; set; }
    }

    public class Total_Shipping_Price_Set
    {
        public Shop_Money2 shop_money { get; set; }
        public Presentment_Money2 presentment_money { get; set; }
    }

    public class Shop_Money2
    {
        public string amount { get; set; }
        public string currency_code { get; set; }
    }

    public class Presentment_Money2
    {
        public string amount { get; set; }
        public string currency_code { get; set; }
    }

    public class Subtotal_Price_Set
    {
        public Shop_Money3 shop_money { get; set; }
        public Presentment_Money3 presentment_money { get; set; }
    }

    public class Shop_Money3
    {
        public string amount { get; set; }
        public string currency_code { get; set; }
    }

    public class Presentment_Money3
    {
        public string amount { get; set; }
        public string currency_code { get; set; }
    }

    public class Total_Price_Set
    {
        public Shop_Money4 shop_money { get; set; }
        public Presentment_Money4 presentment_money { get; set; }
    }

    public class Shop_Money4
    {
        public string amount { get; set; }
        public string currency_code { get; set; }
    }

    public class Presentment_Money4
    {
        public string amount { get; set; }
        public string currency_code { get; set; }
    }

    public class Total_Tax_Set
    {
        public Shop_Money5 shop_money { get; set; }
        public Presentment_Money5 presentment_money { get; set; }
    }

    public class Shop_Money5
    {
        public string amount { get; set; }
        public string currency_code { get; set; }
    }

    public class Presentment_Money5
    {
        public string amount { get; set; }
        public string currency_code { get; set; }
    }

    public class Billing_Address
    {
        public string first_name { get; set; }
        public string address1 { get; set; }
        public object phone { get; set; }
        public string city { get; set; }
        public string zip { get; set; }
        public string province { get; set; }
        public string country { get; set; }
        public string last_name { get; set; }
        public string address2 { get; set; }
        public object company { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
        public string name { get; set; }
        public string country_code { get; set; }
        public string province_code { get; set; }
    }

    public class shipping_address
    {
        public string first_name { get; set; }
        public string address1 { get; set; }
        public object phone { get; set; }
        public string city { get; set; }
        public string zip { get; set; }
        public string province { get; set; }
        public string country { get; set; }
        public string last_name { get; set; }
        public string address2 { get; set; }
        public object company { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
        public string name { get; set; }
        public string country_code { get; set; }
        public string province_code { get; set; }
    }

    public class Client_Details
    {
        public string browser_ip { get; set; }
        public string accept_language { get; set; }
        public string user_agent { get; set; }
        public object session_hash { get; set; }
        public int browser_width { get; set; }
        public int browser_height { get; set; }
    }

    public class Customer
    {
        public long id { get; set; }
        public object email { get; set; }
        public bool accepts_marketing { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public int orders_count { get; set; }
        public string state { get; set; }
        public string total_spent { get; set; }
        public long last_order_id { get; set; }
        public object note { get; set; }
        public bool verified_email { get; set; }
        public object multipass_identifier { get; set; }
        public bool tax_exempt { get; set; }
        public string phone { get; set; }
        public string tags { get; set; }
        public string last_order_name { get; set; }
        public string currency { get; set; }
        public DateTime accepts_marketing_updated_at { get; set; }
        public object marketing_opt_in_level { get; set; }
        public object[] tax_exemptions { get; set; }
        public string admin_graphql_api_id { get; set; }
        public Default_Address default_address { get; set; }
    }

    public class Default_Address
    {
        public long id { get; set; }
        public long customer_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public object company { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string province { get; set; }
        public string country { get; set; }
        public string zip { get; set; }
        public object phone { get; set; }
        public string name { get; set; }
        public string province_code { get; set; }
        public string country_code { get; set; }
        public string country_name { get; set; }
        public bool _default { get; set; }
    }

    public class Line_Items
    {
        public long id { get; set; }
        public long variant_id { get; set; }
        public string title { get; set; }
        public int quantity { get; set; }
        public string sku { get; set; }
        public string variant_title { get; set; }
        public string vendor { get; set; }
        public string fulfillment_service { get; set; }
        public long product_id { get; set; }
        public bool requires_shipping { get; set; }
        public bool taxable { get; set; }
        public bool gift_card { get; set; }
        public string name { get; set; }
        public string variant_inventory_management { get; set; }
        public object[] properties { get; set; }
        public bool product_exists { get; set; }
        public int fulfillable_quantity { get; set; }
        public int grams { get; set; }
        public string price { get; set; }
        public string total_discount { get; set; }
        public object fulfillment_status { get; set; }
        public Price_Set price_set { get; set; }
        public Total_Discount_Set total_discount_set { get; set; }
        public object[] discount_allocations { get; set; }
        public object[] duties { get; set; }
        public string admin_graphql_api_id { get; set; }
        public Tax_Lines[] tax_lines { get; set; }
        public Origin_Location origin_location { get; set; }
    }

    public class Price_Set
    {
        public Shop_Money6 shop_money { get; set; }
        public Presentment_Money6 presentment_money { get; set; }
    }

    public class Shop_Money6
    {
        public string amount { get; set; }
        public string currency_code { get; set; }
    }

    public class Presentment_Money6
    {
        public string amount { get; set; }
        public string currency_code { get; set; }
    }

    public class Total_Discount_Set
    {
        public Shop_Money7 shop_money { get; set; }
        public Presentment_Money7 presentment_money { get; set; }
    }

    public class Shop_Money7
    {
        public string amount { get; set; }
        public string currency_code { get; set; }
    }

    public class Presentment_Money7
    {
        public string amount { get; set; }
        public string currency_code { get; set; }
    }

    public class Origin_Location
    {
        public long id { get; set; }
        public string country_code { get; set; }
        public string province_code { get; set; }
        public string name { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string zip { get; set; }
    }

    public class Tax_Lines
    {
        public string title { get; set; }
        public string price { get; set; }
        public float rate { get; set; }
        public Price_Set1 price_set { get; set; }
    }

    public class Price_Set1
    {
        public Shop_Money8 shop_money { get; set; }
        public Presentment_Money8 presentment_money { get; set; }
    }

    public class Shop_Money8
    {
        public string amount { get; set; }
        public string currency_code { get; set; }
    }

    public class Presentment_Money8
    {
        public string amount { get; set; }
        public string currency_code { get; set; }
    }

    public class Fulfillment
    {
        public long id { get; set; }
        public long order_id { get; set; }
        public string status { get; set; }
        public DateTime created_at { get; set; }
        public string service { get; set; }
        public DateTime updated_at { get; set; }
        public string tracking_company { get; set; }
        public object shipment_status { get; set; }
        public long location_id { get; set; }
        public Line_Items1[] line_items { get; set; }
        public object tracking_number { get; set; }
        public object[] tracking_numbers { get; set; }
        public object tracking_url { get; set; }
        public object[] tracking_urls { get; set; }
        public Receipt receipt { get; set; }
        public string name { get; set; }
        public string admin_graphql_api_id { get; set; }
    }

    public class Receipt
    {
    }

    public class Line_Items1
    {
        public long id { get; set; }
        public long variant_id { get; set; }
        public string title { get; set; }
        public int quantity { get; set; }
        public string sku { get; set; }
        public string variant_title { get; set; }
        public string vendor { get; set; }
        public string fulfillment_service { get; set; }
        public long product_id { get; set; }
        public bool requires_shipping { get; set; }
        public bool taxable { get; set; }
        public bool gift_card { get; set; }
        public string name { get; set; }
        public string variant_inventory_management { get; set; }
        public object[] properties { get; set; }
        public bool product_exists { get; set; }
        public int fulfillable_quantity { get; set; }
        public int grams { get; set; }
        public string price { get; set; }
        public string total_discount { get; set; }
        public object fulfillment_status { get; set; }
        public Price_Set2 price_set { get; set; }
        public Total_Discount_Set1 total_discount_set { get; set; }
        public object[] discount_allocations { get; set; }
        public object[] duties { get; set; }
        public string admin_graphql_api_id { get; set; }
        public Tax_Lines1[] tax_lines { get; set; }
        public Origin_Location1 origin_location { get; set; }
    }

    public class Price_Set2
    {
        public Shop_Money9 shop_money { get; set; }
        public Presentment_Money9 presentment_money { get; set; }
    }

    public class Shop_Money9
    {
        public string amount { get; set; }
        public string currency_code { get; set; }
    }

    public class Presentment_Money9
    {
        public string amount { get; set; }
        public string currency_code { get; set; }
    }

    public class Total_Discount_Set1
    {
        public Shop_Money10 shop_money { get; set; }
        public Presentment_Money10 presentment_money { get; set; }
    }

    public class Shop_Money10
    {
        public string amount { get; set; }
        public string currency_code { get; set; }
    }

    public class Presentment_Money10
    {
        public string amount { get; set; }
        public string currency_code { get; set; }
    }

    public class Origin_Location1
    {
        public long id { get; set; }
        public string country_code { get; set; }
        public string province_code { get; set; }
        public string name { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string zip { get; set; }
    }

    public class Tax_Lines1
    {
        public string title { get; set; }
        public string price { get; set; }
        public float rate { get; set; }
        public Price_Set3 price_set { get; set; }
    }

    public class Price_Set3
    {
        public Shop_Money11 shop_money { get; set; }
        public Presentment_Money11 presentment_money { get; set; }
    }

    public class Shop_Money11
    {
        public string amount { get; set; }
        public string currency_code { get; set; }
    }

    public class Presentment_Money11
    {
        public string amount { get; set; }
        public string currency_code { get; set; }
    }

    public class Refund
    {
        public long id { get; set; }
        public long order_id { get; set; }
        public DateTime created_at { get; set; }
        public object note { get; set; }
        public object user_id { get; set; }
        public DateTime processed_at { get; set; }
        public bool restock { get; set; }
        public object[] duties { get; set; }
        public string admin_graphql_api_id { get; set; }
        public object[] refund_line_items { get; set; }
        public Transaction[] transactions { get; set; }
        public Order_Adjustments[] order_adjustments { get; set; }
    }

    public class Transaction
    {
        public long id { get; set; }
        public long order_id { get; set; }
        public string kind { get; set; }
        public string gateway { get; set; }
        public string status { get; set; }
        public string message { get; set; }
        public DateTime created_at { get; set; }
        public bool test { get; set; }
        public string authorization { get; set; }
        public object location_id { get; set; }
        public object user_id { get; set; }
        public long parent_id { get; set; }
        public DateTime processed_at { get; set; }
        public object device_id { get; set; }
        public Receipt1 receipt { get; set; }
        public object error_code { get; set; }
        public string source_name { get; set; }
        public string amount { get; set; }
        public string currency { get; set; }
        public string admin_graphql_api_id { get; set; }
    }

    public class Receipt1
    {
        public string mc_gross { get; set; }
        public string invoice { get; set; }
        public string protection_eligibility { get; set; }
        public string address_status { get; set; }
        public string payer_id { get; set; }
        public string tax { get; set; }
        public string address_street { get; set; }
        public string payment_date { get; set; }
        public string payment_status { get; set; }
        public string charset { get; set; }
        public string address_zip { get; set; }
        public string first_name { get; set; }
        public string address_country_code { get; set; }
        public string address_name { get; set; }
        public string notify_version { get; set; }
        public string custom { get; set; }
        public string payer_status { get; set; }
        public string address_country { get; set; }
        public string address_city { get; set; }
        public string quantity { get; set; }
        public string verify_sign { get; set; }
        public string payer_email { get; set; }
        public string txn_id { get; set; }
        public string payment_type { get; set; }
        public string last_name { get; set; }
        public string address_state { get; set; }
        public string receiver_email { get; set; }
        public string shipping_discount { get; set; }
        public string insurance_amount { get; set; }
        public string txn_type { get; set; }
        public string item_name { get; set; }
        public string discount { get; set; }
        public string mc_currency { get; set; }
        public string item_number { get; set; }
        public string residence_country { get; set; }
        public string shipping_method { get; set; }
        public string handling_amount { get; set; }
        public string transaction_subject { get; set; }
        public string payment_gross { get; set; }
        public string shipping { get; set; }
        public string ipn_track_id { get; set; }
    }

    public class Order_Adjustments
    {
        public long id { get; set; }
        public long order_id { get; set; }
        public long refund_id { get; set; }
        public string amount { get; set; }
        public string tax_amount { get; set; }
        public string kind { get; set; }
        public string reason { get; set; }
        public Amount_Set amount_set { get; set; }
        public Tax_Amount_Set tax_amount_set { get; set; }
    }

    public class Amount_Set
    {
        public Shop_Money12 shop_money { get; set; }
        public Presentment_Money12 presentment_money { get; set; }
    }

    public class Shop_Money12
    {
        public string amount { get; set; }
        public string currency_code { get; set; }
    }

    public class Presentment_Money12
    {
        public string amount { get; set; }
        public string currency_code { get; set; }
    }

    public class Tax_Amount_Set
    {
        public Shop_Money13 shop_money { get; set; }
        public Presentment_Money13 presentment_money { get; set; }
    }

    public class Shop_Money13
    {
        public string amount { get; set; }
        public string currency_code { get; set; }
    }

    public class Presentment_Money13
    {
        public string amount { get; set; }
        public string currency_code { get; set; }
    }

    public class Shipping_Lines
    {
        public long id { get; set; }
        public string title { get; set; }
        public string price { get; set; }
        public string code { get; set; }
        public string source { get; set; }
        public object phone { get; set; }
        public object requested_fulfillment_service_id { get; set; }
        public object delivery_category { get; set; }
        public object carrier_identifier { get; set; }
        public string discounted_price { get; set; }
        public Price_Set4 price_set { get; set; }
        public Discounted_Price_Set discounted_price_set { get; set; }
        public object[] discount_allocations { get; set; }
        public object[] tax_lines { get; set; }
    }

    public class Price_Set4
    {
        public Shop_Money14 shop_money { get; set; }
        public Presentment_Money14 presentment_money { get; set; }
    }

    public class Shop_Money14
    {
        public string amount { get; set; }
        public string currency_code { get; set; }
    }

    public class Presentment_Money14
    {
        public string amount { get; set; }
        public string currency_code { get; set; }
    }

    public class Discounted_Price_Set
    {
        public Shop_Money15 shop_money { get; set; }
        public Presentment_Money15 presentment_money { get; set; }
    }

    public class Shop_Money15
    {
        public string amount { get; set; }
        public string currency_code { get; set; }
    }

    public class Presentment_Money15
    {
        public string amount { get; set; }
        public string currency_code { get; set; }
    }
    public class Rootobject
    {
        public Fulfillment fulfillment { get; set; }
    }
}
