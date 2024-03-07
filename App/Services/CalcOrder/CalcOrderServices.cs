using App.Services.CalcOrder.bl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.CalcOrder
{
    public class CalcOrderServices : ICalacOrderServices
    {

        private Calc_Order_Details order_Details;

        public CalcOrderServices()
        {
            this.order_Details = new Calc_Order_Details();
        }



        public Order_Detalis Calc(InventoryOrder order)
        {
            this.order_Details.Reseat(order);
            this.order_Details.Calc_Order();
            return this.order_Details.GetOrder_Detalis();
        }
    }
}
