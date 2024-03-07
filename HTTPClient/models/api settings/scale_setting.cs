
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTPCLIENT.models
{

    public class scale_setting
    {
        public int scale_setting_Id { get; set; }

        public int id { get; set; }
        public string name { get; set; } = null;
        public bool enabled { get; set; }
        public bool price { get; set; }
        public int? stock { get; set; } = null;
        public int? pattern { get; set; } = null;


    }
}
