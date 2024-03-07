using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HTTPCLIENT.models;
using HTTPCLIENT.models.api_promo;

namespace HTTPCLIENT.requests_model
{
    public class get_promo
    {
        public List<promos> promos { get; set; } = new List<promos>();
        public List<PromoItem> promo_items { get; set; } = new List<PromoItem>();
    }
}
