namespace Services.Cart.Classes.OrderItem
{
    public class OrderItem_Discount 
    {
        private InventoryOrderitem orderItem;

        public void SetOrderItem(InventoryOrderitem orderItem)
        {
            this.orderItem = orderItem;
        }
        public void Add_Discount_Percentage(decimal discount)
        {
            orderItem.DiscountInPercentage = (discount / 100) ;
        }
    }
}
