
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTPCLIENT.models
{


    public class user_model
    {
        public int user_model_Id { get; set; }

        public int user_id { get; set; }
        public string token { get; set; } = null;
        public string avatar { get; set; } = null;
        public string email { get; set; } = null;
        public string role { get; set; } = null;
        public string lange { get; set; } = null;
        public int company_id { get; set; }
        public int branch_id { get; set; }
        public string avatar_base64 { get; set; } = null;
        public DateTime created { get; set; } 
        
    }
}
