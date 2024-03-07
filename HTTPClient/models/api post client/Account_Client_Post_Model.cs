using System;
namespace HTTPClient.models.api_post_client
{
    public class Account_Client_Post_Model
    {

        public DateTime desktop_timestamp { get; set; }

        public int? cloud_id = null;
        public string name { get; set; } = null;
        public string phone_number { get; set; } = null;
        public string email { get; set; } = null;
        public string address { get; set; } = null;
        public bool is_supplier { get; set; }
        public string vat_number { get; set; } = null;
        public string customer_uuid { get; set; } = null;
        public string avatar { get; set; } = string.Empty;
    }
}
