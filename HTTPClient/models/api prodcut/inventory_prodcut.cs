
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HTTPCLIENT.models.api_prodcut
{

    public class inventory_prodcut
    {
        public int id { get; set; }
        public string name { get; set; } = null;
        public decimal tax_total {get;set;}
        public decimal cost { get; set; }
        public decimal price { get; set; }
        public decimal last_cost { get; set; }
        public decimal subtotal { get; set; }
        public decimal cost_after_tax { get; set; }
        public decimal reorder_point { get; set; }
        public bool low_stock_bool { get; set; }
        public bool tax_included { get; set; }
        public decimal price_with_tax { get; set; }
        public bool active { get; set; }
        public decimal quantity { get; set; }
        public string barcode { get; set; } = null;
        public string code { get; set; } = null; 
        public string image { get; set; } = null;
        public string color { get; set; } = null;
        public DateTime date_created { get; set; } 
        public DateTime date_updated { get; set; }
        public int stock { get; set; }
        public int? created_by { get; set; }
        public int? last_modified_by { get; set; }
        public int? group { get; set; }
        //public int supplier { get; set; }

        
    }
}
