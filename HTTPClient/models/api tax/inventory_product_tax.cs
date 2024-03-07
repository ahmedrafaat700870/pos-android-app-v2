using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTPCLIENT.models.api_tax
{


    public class inventory_product_tax
    {
        public int inventory_product_tax_Id { get; set; }

        public int id { get; set; }
        public int product { get; set; }
        public DateTime timestamp { get; set; }
        public int tax { get; set; }
        public void print() { }
    }
}
