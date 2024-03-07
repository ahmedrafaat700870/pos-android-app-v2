
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTPCLIENT.models.api_promo
{

    public class PromoItem
    {
        public int PromoItem_Id { get; set; }
        public int id { get; set; }
        public bool is_conditional { get;set; }
        public bool is_all { get; set; }
        public decimal apply_to_all { get; set; }
        public decimal apply_to_next { get; set; }
        public decimal discount_in_percentage { get; set; }
        public decimal discount_in_fixed_price { get; set; }
        public int promo { get; set; }
        public int prodcut_promo { get;set; }
        public DateTime created { get; set; }
        public int? product { get; set; } = null;




    }
}
