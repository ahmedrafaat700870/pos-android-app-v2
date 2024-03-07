namespace Services.Promo
{
    public abstract class Add_Promo_To_Order_item
    {
        protected InventoryOrderitem _Order_item { get; set; }
        protected promo_item Promo { get; set; }
        public Add_Promo_To_Order_item(InventoryOrderitem orderitem , promo_item promo)
        {
            this._Order_item = orderitem;
            this.Promo = promo;
        }

        public abstract void Add_Promo();

    }
}
