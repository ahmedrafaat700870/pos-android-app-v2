

namespace App.Helpers
{
    public class UpdateOrderHeloper
    {
        public static void ChangePriceOrderItem()
        {

        }

        public static void ChangeeQuanityLastOrderItem(int productId , decimal qty)
        {
            App.order.InventoryOrderProducts.Where(x =>x.Orderitem.ProductId == productId).LastOrDefault().Orderitem.Quantity = qty;
        }
        public static void ChangeeQuanityFirstOrderItem(int productId, decimal qty)
        {
            App.order.InventoryOrderProducts.Where(x => x.Orderitem.ProductId == productId).FirstOrDefault().Orderitem.Quantity = qty;
        }

        public static void ChangeLastOrderItem(InventoryOrderitem orderitem)
        {
            App.order.InventoryOrderProducts.Where(x => x.Orderitem.ProductId == orderitem.ProductId).LastOrDefault().Orderitem = orderitem;
        }
        public static void ChangeFirstOrderItem(InventoryOrderitem orderitem) 
        {
            App.order.InventoryOrderProducts.Where(x => x.Orderitem.ProductId == orderitem.ProductId).FirstOrDefault().Orderitem = orderitem;
        }
        public static void UpdateOrderItemByAddDate(InventoryOrderitem orderItem)
        {
            App.order.InventoryOrderProducts.Where(x => x.Orderitem.Add_Date == orderItem.Add_Date).FirstOrDefault().Orderitem = orderItem;
        }
    }
}
