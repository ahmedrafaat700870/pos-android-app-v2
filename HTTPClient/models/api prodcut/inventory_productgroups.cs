
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTPCLIENT.models.api_prodcut
{

    public class inventory_productgroups
    {
        public int id { get; set; }
        public string name { get; set; } = null;
        public int? parent { get; set; }
        public int stock { get; set; }
        public int created_by { get; set; }
        public int? last_modified_by {get;set;}
        public DateTime created { get; set; }
        

    }
}
