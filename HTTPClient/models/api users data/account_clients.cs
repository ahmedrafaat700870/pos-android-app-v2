using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTPCLIENT.models.api_users_data
{

    public class account_clients
    {
        public int account_clients_Id { get; set; }

        public int id { get; set; }
        public string avatar { get; set; }  = null;
        public string name { get; set; } = null;
        public string email { get; set; } = null;
        public string address { get; set; } = null;
        public string  phone_number { get; set; } = null;
        public DateTime date_created { get; set; } 
        public DateTime date_updated { get; set; } 
        public bool is_supplier { get; set; } 
        public string vat_number { get; set; } = null;
        public int company { get; set; }
        public string uuid;
    
    }
}
