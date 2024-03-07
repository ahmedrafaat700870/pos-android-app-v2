
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTPCLIENT.models.api_users_data
{


    public class auth_token
    {
        public string key { get; set; } = null;
        public DateTime created { get; set; }
        public int user { get; set; }
    }
}
