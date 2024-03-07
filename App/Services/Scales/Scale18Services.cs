namespace App.Services.Scales
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
            HelperTaxIncluded.AddPriceToOrderItem(price, inventoryOrder);
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

            decimal wight = GetPriceOrWight(ScaleCode, s.weigth, NumberOfPointWeigth);

            ten = GetPower(s.weigth);
            ScaleCode /= ten;

            int NumberOfPointPrice = App.scalesHelper.GetDecimalPoint();
            decimal price = GetPriceOrWight(ScaleCode, s.price, NumberOfPointPrice);

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
