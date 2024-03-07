namespace Services.Cart.Classes.OrderItem
{
    public class OrderItem_Discunt_Salary 
    {

        private Calc_Order_item_Detalis order_item_detalis = null!;

        private bool is_disocunt_for_total = true;

        private InventoryOrderitem orderItem;

        public void Set_order_item_detalis(Calc_Order_item_Detalis order_item_detalis , InventoryOrder order)
        {
            order_item_detalis.Set_Order(order);
            this.order_item_detalis = order_item_detalis;
            this.is_disocunt_for_total = order.Is_Discount_For_Total;
        }

        public void SetOrderItem(InventoryOrderitem orderItem)
        {
            this.orderItem = orderItem;
        }

        public void Add_Discount_Salary(decimal discount, string? errorMessage = "if you add this discount the price will by less than 0 .")
        {
            orderItem.Discount = discount;
            
            decimal item_discount = Calc_item_salary_total_after_discount();

            if (item_discount  < 0)
            {
                orderItem.Discount = 0;
                orderItem.discount_inpercentage_is_first = true;
                throw new Exception(errorMessage);
            }

            orderItem.Is_Discount_For_Total = true;

        }

        public void Add_Discount_Salary_Orignal_Price(decimal discount ,  string? errorMessage = "if you add this discount the price will by less than 0 .")
        {
            orderItem.Discount = discount ;

            decimal item_discount = Calc_item_salary_subtotal_after_discount();

            if (item_discount  < 0)
            {
                orderItem.Discount = 0;
                orderItem.discount_inpercentage_is_first = true;
                throw new Exception(errorMessage);
            }

            orderItem.Is_Discount_For_Total = false;
        }

        private decimal Calc_item_salary_total_after_discount()
        {

            this.order_item_detalis.Reseat(orderItem);
            this.order_item_detalis.Calc_Order_Item(is_disocunt_for_total);

            return this.order_item_detalis.Get_Order_Item_Total() 
                - this.order_item_detalis.Get_Order_Item_Disocunt_Total();
        }

        private decimal Calc_item_salary_subtotal_after_discount()
        {
            this.order_item_detalis.Reseat(orderItem);
            this.order_item_detalis.Calc_Order_Item(is_disocunt_for_total);

            return this.order_item_detalis.Get_Order_Item_Total()
                - this.order_item_detalis.Get_Order_Item_Disocunt_Total();
        }

    }
}
