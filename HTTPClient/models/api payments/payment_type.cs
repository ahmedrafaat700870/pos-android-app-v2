
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTPCLIENT.models
{

    public class payment_type
    {
        public int id { get; set; }
        public string name { get; set; } = null;
        public bool enabled { get; set; }
        public bool mark_paid { get; set; }
        public bool customer_required { get; set; }
        public int stock { get; set; }

    }
}
