using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncV2.HTTPCLIENT.models.v2
{
    public class DataModel
    {
        public int id { get; set; }
        public string table_name { get; set; } = null;
        public int object_id { get; set; } 
        public string action { get; set; } = null;
        public DateTime timestamp { get; set; }
        public int branch { get; set; }
        public int table { get; set; }
        public dynamic object_data { get; set; } = null;
    }
}
