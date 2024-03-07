using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synchronization_Services
{
    public class URLS
    {
        // first time urls
        public static string main_url = "https://onepos.cloud/";

        public static string login_url = main_url + "accounts/login";
        public static string server_status =  main_url + "sync/status/";
        public static string test_token = main_url + "sync/test_token/";
        public static string get_init_company = main_url + "sync/get_company/";
        public static string lgoin = string.Empty;
        public static string get_users = main_url + "sync/get_users/";
        public static string get_accounts_customers = string.Empty;
        public static string get_auth_token = string.Empty;
        public static string get_inventory_prodcut = string.Empty;
        public static string get_inventory_productgroups = string.Empty;
        public static string get_ItemBoxes = string.Empty;
        public static string get_taxces = main_url + "sync/get_taxes/";
        public static string get_inventory_product_tax = string.Empty;
        public static string get_promos = main_url + "sync/get_promos/";
        public static string get_promo_price_type = main_url + "sync/get_promos/";
        public static string get_PromoProduct = main_url + "sync/get_promos/";
        public static string get_inventory_addon = string.Empty;
        public static string get_inventory_addontype = string.Empty;
        public static string get_payments = main_url + "sync/get_payments/";
        public static string get_settings = main_url + "sync/get_settings/";
        public static string get_sync_records = main_url + "sync/sync/?last_sync";
        public static string get_products = main_url + "sync/get_products/";
        public static string Post_Refund = main_url + "sync/new_refund";
        public static string get_async_deleted_records = main_url + "sync/get_deleted_records/";
        // anytime urls

        public static string post_account_customers = main_url + "sync/create_client_and_suppliers"; // main_url + "";

		public static string post_inventory_orders = main_url + "sync/new_order";

        public static string post_invenory_orders_products = main_url + "";

        public static string post_inventory_order_items = main_url + "";

        public static string post_inventory_addon_item = main_url + "";

        public static string post_payents_amount = main_url + "";

        public static string post_refund_item = main_url + "";

        public static string post_payment_amount = main_url + "";

        public static string post_work_shift = main_url + "";

        public static string post_user_work_shift = main_url + "";
    }
}
