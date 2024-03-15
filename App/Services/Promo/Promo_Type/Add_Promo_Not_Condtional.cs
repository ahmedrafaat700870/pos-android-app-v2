namespace Services.Promo.Promo_Type
{
    public class Add_Promo_Not_Condtional : Add_Promo_To_Order_item
    {

        public Add_Promo_Not_Condtional(InventoryOrderitem orderitem, promo_item promo) : base(orderitem, promo) {}

        public override  void Add_Promo()
        {
            this._Order_item.Quantity += 1;

            if (this.Promo.fixed_price == 0 && this.Promo.discount_in_percentage == 0)
                return;
           
                
            this._Order_item.is_promo = true;

            if (this.Promo.fixed_price != 0)
            {
                // change price order item .
                this._Order_item.original_price = this.Promo.fixed_price;
                if (this._Order_item.tax_included)
                {
                    this._Order_item.Subtotal = this.Promo.fixed_price / (this._Order_item.Percentage_Taxes + 100) * 100;
                    this._Order_item.TaxTotal = this.Promo.fixed_price - this._Order_item.Subtotal;
                    this._Order_item.Total = this.Promo.fixed_price;
                }
                else
                {
                    // calc order detalis .
                    this._Order_item.Subtotal = this.Promo.fixed_price;
                    this._Order_item.TaxTotal = this.Promo.fixed_price * (this._Order_item.Percentage_Taxes / 100);
                    this._Order_item.Total = this.Promo.fixed_price + this._Order_item.TaxTotal;
                }

            }
            else if  (this.Promo.discount_in_percentage != 0)
            {
                this._Order_item.DiscountInPercentage = this.Promo.discount_in_percentage;
            }

        }
    }
}
