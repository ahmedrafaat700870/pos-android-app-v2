

using App.Services.Promo.Promo_Type;

namespace Services.Promo
{
    public class PromoServices
    {
        private InventoryOrderitem _Order_item { get; set; }
        private InventoryOrder _Order { get; set; }
        private IEnumerable<promo_item> _Promos { get; set; }
        public PromoServices(InventoryOrderitem _order_item , InventoryOrder order, IEnumerable<promo_item> Promos)
        {
            this._Order_item = _order_item;
            this._Order = order;
            this._Promos = Promos;
        }

        public bool Check_From_Promo(decimal qty , Action ? LoadData = null)
        {
            bool AddPromo = false;
            foreach (var promos_prodcut in _Promos)
            {
                if (promos_prodcut is null)
                    continue;

                if (promos_prodcut.Promotions is null)
                    continue;

                // check from days 

                bool contains_day_now = Check_From_Days_of_week(promos_prodcut.Promotions.days_of_week);


                if (!contains_day_now)
                    continue;

                // add promo to this order item .....

                AddPromo = true;
                if (!promos_prodcut.is_conditional)
                {
                    // add contditional 
                    Add_Promo_Not_Condtional oAdd_Promo_Not_Condtional
                        = new Add_Promo_Not_Condtional(_Order_item, promos_prodcut);
                    oAdd_Promo_Not_Condtional.Add_Promo();
             
                }
                else
                {
                    if (promos_prodcut.is_all)
                    {

                        // add all
                        Add_Promo_Contional_IsAll oAdd_Promo_Contional_IsAll
                            = new Add_Promo_Contional_IsAll(_Order_item, promos_prodcut, _Order);

                        if(qty == 1)
                            oAdd_Promo_Contional_IsAll.Add_Promo_Contional(qty);
                        /* else
                            oAdd_Promo_Contional_IsAll.Add_Promo(qty , LoadData);*/

                    }
                    else
                    {
                        // add all and to next 
                        ApplyPromoToNextV2 oAdd_Promo_Contional_AppToNext
                           = new ApplyPromoToNextV2(_Order_item, promos_prodcut, _Order);
                        if (qty == 1)
                            oAdd_Promo_Contional_AppToNext.Add_Promo_Contional(qty);
                        /* else
                            oAdd_Promo_Contional_AppToNext.AddPromo(qty , LoadData);*/
                    }
                }

                break;
            }
            return AddPromo;
        }

       


        private bool Check_From_Days_of_week(string days)
        {
            bool is_active = false;

            try
            {
                is_active = days.ToString().ToArray().Contains(number_of_day_now());
                
            } catch { return false; }

            return is_active;
        }

        private char number_of_day_now()
        {
            string datenow = DateTime.Now.DayOfWeek.ToString().ToLower();
            if (datenow == "Saturday".ToLower())
            {
                return '0';
            } else if(datenow == "Sunday".ToLower())
            {
                return '1';
            } else if (datenow == "Monday".ToLower())
            {
                return '2';
            } else if (datenow == "Tuesday".ToLower())
            {
                return '3';
            } else if (datenow == "Wednesday".ToLower())
            {
                return '4';
            } else if (datenow == "Thursday".ToLower())
            {
                return '5';
            } else
            {
                // Friday
                return '6';
            }

           
        }
    }
}
