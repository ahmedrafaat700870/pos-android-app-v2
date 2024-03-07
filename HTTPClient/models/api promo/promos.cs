
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HTTPCLIENT.models
{

    public class promos
    {
        public int id { get; set; }
        public string name { get; set; } = null;
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public string days_of_week { get; set; } = null;
        public bool is_active { get; set; }
        public int branch { get; set; }
        public int? created_by { get; set; } = null;

        public DateTime created { get; set; }

       
    }
}
