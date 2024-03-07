using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncV2.HTTPCLIENT.models.v2.Model
{
    public class UserModel
    {
        public int id { get; set; }
        public string password { get; set; }
        public DateTime last_login { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public bool is_active { get; set; }
        public DateTime date_joined { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string role { get; set; }
        public DateTime birth { get; set; } // Change the type to the actual type if available
        public string country { get; set; }
        public string phone_number { get; set; }
        public int? starting_cash { get; set; } // Change the type to the actual type if available
        public string timezone { get; set; }
        public string lang { get; set; }
        public int company { get; set; }
        public int branch { get; set; }
    }
}
