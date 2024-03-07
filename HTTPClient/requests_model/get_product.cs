using HTTPCLIENT.models.api_addon;
using HTTPCLIENT.models.api_prodcut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTPCLIENT.requests_model
{
    public class get_product
    {
        public List<inventory_prodcut> products { get; set; } = new List<inventory_prodcut>();
        public List<inventory_productgroups> product_groups { get; set; } = new List<inventory_productgroups>();
        public List<inventory_addon> addons { get; set; } = new List<inventory_addon>();
        public List<inventory_addontype> addon_types { get; set; } = new List<inventory_addontype>();
        public List<ItemBoxes> item_box { get; set; } = new List<ItemBoxes>();
    }
}
