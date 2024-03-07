namespace App.Helpers
{
    public class HelperPromo
    {
        public bool CheckFromPromo(InventoryOrderitem product, decimal InteredQty)
        {
            PromoServices promoServices = new PromoServices(product, App.order, getPromos(product.ProductId));
            return promoServices.Check_From_Promo(InteredQty);
        }
        public IEnumerable<promo_item> getPromos(int productId)
        {
            var promosPriceTypes = App.appServices.promo_price_types.SelectMany(x => x.Promo_Item).Where(x => x.Cloud_product_id == productId).ToList();
            return promosPriceTypes;
        }
    }
}
