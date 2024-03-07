
namespace Services.Cart.Classes
{
    public class Discount_For_Order_Percentage 
    {
        private InventoryOrder Order;
        public Discount_For_Order_Percentage(InventoryOrder order)
        {
            Order = order;
        }

        public void SetOrder(InventoryOrder order)
        {
            Order = order;
        }
        public void Add_Discount(decimal discount)
        {
            this.Order.DiscountInPercentage = (discount / 100);
        }
    }
}
