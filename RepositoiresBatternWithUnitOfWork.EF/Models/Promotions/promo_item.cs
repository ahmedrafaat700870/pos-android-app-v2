using Microsoft.EntityFrameworkCore;
using RepositoiresBatternWithUnitOfWork.EF.Models.ProductModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoiresBatternWithUnitOfWork.EF.Models.Promotions
{
    public class promo_item
    {
        public promo_item()
        {
        }

        public int id { get; set; }
        public bool is_conditional { get; set; }
        public bool is_all { get; set; }
        public decimal apply_all { get; set; }
        public decimal apply_to_next { get; set; }


        public decimal discount_in_percentage { get; set; }
        public decimal fixed_price { get; set; }

        public int? promo_price_type_Id { get; set; }


        public int Cloud_Id { get; set; }
        public int? Cloud_promo_price_type_Id { get; set; } = null!;
        public int? Cloud_product_id { get; set; } = null!;
        public int? ProductsId { get; set; } = null!;
        public DateTime created { get; set; }

        public virtual promo_price_type Promotions { get; set; } = null!;
        public virtual InventoryProduct Products { get; set; } = null!;

    }
}
