using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HTTPCLIENT.models;
using HTTPCLIENT.models.api_tax;

namespace HTTPCLIENT.requests_model
{
    public class get_tax
    {
        public List<inventory_tax> taxes { get; set; } = new List<inventory_tax>();
        public List<inventory_product_tax> product_taxes { get; set; } = new List<inventory_product_tax>();
    }
}
