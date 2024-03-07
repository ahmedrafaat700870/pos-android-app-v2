using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Helpers
{
    public class HelperTaxIncluded
    {
        public static void AddPriceToOrderItem(decimal price , InventoryOrderitem orderItem)
        {
            if(orderItem.tax_included)
                TaxInclude(price , orderItem);
             else
                TaxNotInvluded(price , orderItem);
                
        }

        private static void TaxInclude(decimal price, InventoryOrderitem orderItem)
        {
            orderItem.Subtotal = price / (orderItem.Percentage_Taxes + 100) * 100;
            orderItem.TaxTotal = price - orderItem.Subtotal;
            orderItem.Total = price;
        }

        private static void TaxNotInvluded(decimal price, InventoryOrderitem orderItem)
        {
            orderItem.Subtotal = price;
            orderItem.TaxTotal = price * (orderItem.Percentage_Taxes / 100);
            orderItem.Total = price + orderItem.TaxTotal;
        }

        public static decimal CalcTotalPriceTaxIncludedOrNot(bool TaxIncluded , decimal price , decimal percentageTaxces)
        {
            decimal total = 0;

            if (TaxIncluded)
                total = price;
            else
            {
                decimal tax = price * (percentageTaxces / 100);
                total = price + tax;
            }

            return total;
        }

    }
}
