
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTPCLIENT.models.api_addon
{


    public class inventory_addontype
    {
     
        public int id { get; set; }
        public string name { get; set; } = null;
        public decimal price { get; set; }  
        public int addon { get; set; }
        public DateTime created { get; set; }
    }
}
