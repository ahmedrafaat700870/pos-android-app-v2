namespace App.Model
{
    public partial class CartItemModel : ObservableObject
    {

        public InventoryOrderitem orderItem;

        private Calc_Order_item_Detalis CalcOrderItem = null!;
        public CartItemModel(InventoryOrderitem orderItem, DateTime AddDate)
        {
            this.orderItem = orderItem;
            CaclOrderItem();
            Id = orderItem.ProductId;
            itemName = orderItem.name;
            qty = orderItem.Quantity;
            price = orderItem.Total;
            disoucnt = this.CalcOrderItem.Get_Order_Item_Disocunt_Total();
            this.AddDate = AddDate;
            totalPrice = orderItem.Total * orderItem.Quantity;
            discount_percentage = (this.orderItem.DiscountInPercentage * 100).ToString("0.00");
            this.disocunt = disoucnt.ToString("0.00");

            if (disoucnt > 0)
                showDiscount = true;
            IsPromo = orderItem.is_promo;
        }

        private void CaclOrderItem()
        {
            CalcOrderItem = App.GetCaclOrderItem();
            CalcOrderItem.Reseat(orderItem);
            CalcOrderItem.Calc_Order_Item(HerlperSettings.IsDiscountForTotal());
            CalcOrderItem.Get_Order_Item_Disocunt_Total();
        }

        public void ChangeQty(decimal qty, Action LoadDataCart)
        {
            /*bool isAddedPromo = CheckFromPromo(orderItem, qty , LoadDataCart);
            if (!isAddedPromo)*/
            orderItem.Quantity = qty;
            Qty = orderItem.Quantity;
            Price = orderItem.Total;
            TotalPrice = orderItem.Total * orderItem.Quantity;
        }

        [ObservableProperty]
        private bool isPromo;


        [ObservableProperty]
        private int id;


        [ObservableProperty]
        private DateTime addDate;

        [ObservableProperty]

        private string itemName;
        [ObservableProperty]

        private decimal qty;

        [ObservableProperty]

        private decimal price;
        [ObservableProperty]

        private decimal disoucnt;
        [ObservableProperty]

        private decimal totalPrice;

        [ObservableProperty]
        private string disocunt = "0.00$";

        [ObservableProperty]
        private string discount_percentage = "0.00$";
        [ObservableProperty]
        private bool showDiscount = false;


        private bool CheckFromPromo(InventoryOrderitem product, decimal InteredQty, Action LoadData)
        {
            PromoServices promoServices = new PromoServices(product, App.order, getPromos());
            return promoServices.Check_From_Promo(InteredQty, LoadData);
        }

        private IEnumerable<promo_item> getPromos()
        {
            var promosPriceTypes = App.appServices.promo_price_types.SelectMany(x => x.Promo_Item).Where(x => x.Cloud_product_id == Id).ToList();
            return promosPriceTypes;
        }

    }
}
