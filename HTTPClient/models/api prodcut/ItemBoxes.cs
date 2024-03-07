
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTPCLIENT.models.api_prodcut
{

    public class ItemBoxes
    {
        public int ItemBoxes_Id { get; set;}
        public int id { get; set; }
        public string name { get; set; } = null;
        public decimal count { get; set; }
        public decimal unit_of_price { get; set; }
        public string image { get; set; } = null;
        public int product { get; set; }
        public int stock { get; set; }
        public string barcode { get; set; } = null;
        public DateTime created { get; set; }

        
    }
}
