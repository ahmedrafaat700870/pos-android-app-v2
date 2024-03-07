
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTPCLIENT.models
{


    public class inventory_tax
    {
        public int inventory_tax_Id { get; set; }

        public int id { get; set; }
        public string name { get; set; } = null;
        public decimal percentage_value { get; set; } 
        public int stock { get; set; }
        public DateTime timestamp { get; set; }


       
    }
}
