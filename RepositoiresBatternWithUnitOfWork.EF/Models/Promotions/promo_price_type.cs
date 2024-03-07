using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoiresBatternWithUnitOfWork.EF.Models.Promotions
{
    public class promo_price_type
    {
        public promo_price_type()
        {
            Promo_Item = new HashSet<promo_item>();
        }

        public int Id { get; set; }

        public string name { get; set; } = null!;
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public string days_of_week { get; set; } = null!;
        public bool is_active { get; set; }



        public DateTime created { get; set; }
        public int Cloud_Id { get; set; }

        public virtual ICollection<promo_item> Promo_Item { get; set; } = null!;
    }
}
