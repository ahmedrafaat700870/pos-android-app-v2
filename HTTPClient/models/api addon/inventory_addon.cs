using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTPCLIENT.models.api_addon
{
    public class inventory_addon
    {
        public int id { get; set; }
        public string name { get; set; } = null;
        public int stock { get; set; }
        public DateTime created { get; set; }
        
       
    }
}
