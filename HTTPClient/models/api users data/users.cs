
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTPCLIENT.models
{


    public class users
    {
        public int id { get; set; }
        public string password { get; set; } = null;
        public DateTime? last_login { get; set; }
        public bool is_superuser { get; set; }
        public string first_name { get; set; } = null;
        public string last_name { get; set; } = null;
        public bool is_staff { get; set; }
        public bool is_active { get; set; }
        public DateTime date_joined { get; set; }
        public string username { get; set; } = null;
        public string email { get; set; } = null;
        public string role { get; set; } = null;
        public string avatar { get; set; } = null;
        public DateTime? birth { get; set; }
        public string country { get; set; } = null;
        public string phone_number { get; set; } = null;
        public int? starting_cash { get; set; }
        public string timezone { get; set; } = null;
        public string lang { get; set; } = null;
        public int? company { get; set; }
        public int? branch { get; set; }
        public string image_based_64 { get; set; } = null;
        public DateTime created { get; set; } 
        
    }
}
