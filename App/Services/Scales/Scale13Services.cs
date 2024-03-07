namespace App.Services.Scales
{
    public class Scale13Services : IScalesServices
    {
        private Scale13Type scale = new Scale13Type();

        private Scale s;
        public bool GetByCode(long ScaleCode)
        {
            setScale(ScaleCode);
            if (s.start == 0)
                return false;

            var prodcut = App.appServices.products.products.FirstOrDefault(x => x.code == scale.code.ToString());
            if (prodcut is null)
                return false;


            decimal priceOrQty = scale.priceOrWeight;
            var inventoryOrder = new InventoryOrderitem()
            {
                Quantity = 0,
                Subtotal = prodcut.subtotal,
                Total = prodcut.price_with_tax,
                ProductId = prodcut.id,
                tax_included = prodcut.tax_included,
                TaxTotal = prodcut.tax_total,
                Add_Date = DateTime.Now,
                _product_api = prodcut
            };
            if (s.isPrice)
            {
                HelperTaxIncluded.AddPriceToOrderItem(priceOrQty, inventoryOrder);
                OrderHeloper.AddOrderItemToOrder(inventoryOrder);
                inventoryOrder.original_price = priceOrQty;
            }
            else
            {
                inventoryOrder.Quantity = priceOrQty;
                inventoryOrder.original_price = prodcut.price;
                OrderHeloper.AddOrderItemToOrder(inventoryOrder, priceOrQty);
            }
            return true;
        }

        private  void setScale(long ScaleCode)
        {
            s = App.scalesHelper.GetScaleSettings();
            long ten = 1;
            ten = GetPower(s.end);
            long end = ScaleCode % ten;
            ScaleCode /= ten;

            int NumberOfPoint = App.scalesHelper.GetDecimalPoint();

            decimal _priceOrWeigth =  CalcPice(ScaleCode , s.price , NumberOfPoint);

            if (s.isPrice)
                ten = GetPower(s.price);
            else
                ten = GetPower(s.weigth);

            ScaleCode /= ten;

            ten = GetPower(s.code);
            long code = ScaleCode % ten;
            ScaleCode /= ten;


            ten = GetPower(s.start);
            long start = ScaleCode % ten;

            scale.start = start;
            scale.code = code;
            scale.priceOrWeight = _priceOrWeigth;
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

        private  decimal CalcPice(long code , int price , int n)
        {
            long g = GetPower(price);
            long P = GetPower(n);
            code %= g;
            decimal dCode = 0;
            decimal.TryParse(code.ToString() , out dCode);
            decimal c = 0;
            decimal.TryParse((dCode / P).ToString(), out c);
            return c;
        }

    }

    internal class Scale13Type 
    {
        internal long start;
        internal long code;
        internal decimal priceOrWeight;
        internal long end;
    }

}
