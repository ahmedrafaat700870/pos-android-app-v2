﻿namespace App.Services.Scales
{
    public class Scale18Services : IScalesServices
    {
        private Scale18Type scale = new Scale18Type();

        private Scale s;
        public bool GetByCode(long ScaleCode)
        {
            setScale(ScaleCode);
            if (s.start == 0)
                return false;
            var prodcut = App.appServices.products.products.FirstOrDefault(x => x.code == scale.code.ToString());
            if (prodcut is null)
                return false;

            decimal price = scale.price;
            decimal qty = scale.wight;
            var inventoryOrder = new InventoryOrderitem()
            {
                name = prodcut.name,
                Quantity = qty,
                Subtotal = prodcut.subtotal,
                Total = prodcut.price_with_tax,
                ProductId = prodcut.id,
                tax_included = prodcut.tax_included,
                TaxTotal = prodcut.tax_total,
                Add_Date = DateTime.Now,
                original_price = price,
                _product_api = prodcut
            };
            inventoryOrder.Percentage_Taxes = HerlperInventroyOrderItem.GetPercentageTaxces(prodcut.id);
            inventoryOrder.Subtotal = price / (inventoryOrder.Percentage_Taxes + 100) * 100;
            inventoryOrder.Total = price;
            inventoryOrder.TaxTotal = inventoryOrder.Total - inventoryOrder.Subtotal;
            inventoryOrder.original_price = price;
            OrderHeloper.AddOrderItemToOrder(inventoryOrder, qty);
            return true;
        }

        /*
         
         2 5 5 5 1
         22 11111 20000 100000 1
         */

        private void setScale(long ScaleCode)
        {
            s = App.scalesHelper.GetScaleSettings();
            long ten = 1;
            ten = GetPower(s.end);
            long end = ScaleCode % ten;
            ScaleCode /= ten;

            int NumberOfPointWeigth = App.scalesHelper.GetDecimalPointWeight();

            string _s = ScaleCode.ToString();
            decimal wight = GetPriceOrWightV2(_s, s.weigth, NumberOfPointWeigth);

            ten = GetPower(s.weigth);
            ScaleCode /= ten;

            _s = ScaleCode.ToString();
            int NumberOfPointPrice = App.scalesHelper.GetDecimalPoint();
            decimal price = GetPriceOrWightV2(_s, s.price, NumberOfPointPrice);

            ten = GetPower(s.price);
            ScaleCode /= ten;

            ten = GetPower(s.code);
            long code = ScaleCode % ten;
            ScaleCode /= ten;

            ten = GetPower(s.start);
            long start = ScaleCode % ten;

            scale.start = start;
            scale.code = code;
            scale.wight = wight;
            scale.price = price / wight;
            scale.end = end;
        }


        private long GetPower(int p)
        {
            long num = 1;
            for (int i = 0; i < p; i++)
            {
                num *= 10;
            }
            return num;
        }

        private decimal GetPriceOrWight(long code, int priceOrWigth, int n)
        {
            long g = GetPower(priceOrWigth);
            long P = GetPower(n);
            code %= g;
            decimal dCode = 0;
            decimal.TryParse(code.ToString(), out dCode);
            decimal c = 0;
            decimal.TryParse((dCode / P).ToString(), out c);    
            return c;




        }

        private decimal GetPriceOrWightV2(string code, int priceOrWigth, int n)
        {
            // save code 21111110000002000 , priceOrWight = 5 , n = 2 

            string codePriveOrWight = code.Substring(code.Length - priceOrWigth); // => 02000
            string decimalBlaces = codePriveOrWight.Substring(codePriveOrWight.Length - (priceOrWigth - n));
            string pw = codePriveOrWight.Substring(0 , n);
            decimal _pw;
            decimal.TryParse($"{pw}.{decimalBlaces}" , out _pw);
            return _pw;
        }


    }

    internal class Scale18Type
    {
        internal long start;
        internal long code;
        internal decimal price;
        internal decimal wight;
        internal long end;
    }
}
