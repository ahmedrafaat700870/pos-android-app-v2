using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTPCLIENT.models.branch
{

    public class stock
    {
        public int stock_Id { get; set;}
        public int id { get; set; }
        public string name { get; set; } = null;
        public int branch { get; set; }
        public DateTime? timestamp { get; set; } = null;

    }
}
