
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTPCLIENT.models
{

    public class order_setting
    {
        public int order_setting_Id { get; set; }
        public int id { get; set; }
        public bool prevent_negative { get; set; }
        public bool reset_invoice { get; set; }
        public bool allow_price_changing { get; set; }
        public int stock { get; set; }

    }
}
