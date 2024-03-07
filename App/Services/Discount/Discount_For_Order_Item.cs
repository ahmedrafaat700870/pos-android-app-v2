using System.Numerics;

namespace Services.Cart
{
    public class Discount_For_Order_Item
    {
        public OrderItem_Discount oOrderItem_Discount { get; set; }
        public OrderItem_Discunt_Salary oRderItem_Discount_Salary { get; set; }
        private InventoryOrderitem orderItem;
        public Discount_For_Order_Item()
        {
            this.oOrderItem_Discount = new OrderItem_Discount();
            this.oRderItem_Discount_Salary = new OrderItem_Discunt_Salary();
        }

        public void SetOrderItem(InventoryOrderitem orderItem)
        {
            this.orderItem = orderItem;
        }

        public decimal Add_Discount_Bercentage(decimal discount, InventoryOrder order, bool isDisocuntForTotal, string? error_discount = "disocunt percentage => can't by more than 100")
        {

            decimal Calcolated_Discount = 0;
            if (discount > 100)
                throw new Exception(error_discount);
            if (orderItem.Discount != 0 || orderItem.DiscountInPercentage != 0)
            {

            }
            else if (orderItem.Discount == 0 && orderItem.DiscountInPercentage == 0)
                orderItem.discount_inpercentage_is_first = true;
            else if (orderItem.Discount == 0)
                orderItem.discount_inpercentage_is_first = false;
            else if (orderItem.DiscountInPercentage == 0)
                orderItem.discount_inpercentage_is_first = true;


            order.Is_Discount_For_Total = isDisocuntForTotal;


            oOrderItem_Discount.SetOrderItem(orderItem);
            orderItem.Discount = 0;
            oOrderItem_Discount.Add_Discount_Percentage(discount);
            Calcolated_Discount = orderItem.Discount;



            return Calcolated_Discount;
        }
        public decimal Add_Discount_Salary(Calc_Order_item_Detalis order_item_delies, decimal discount, InventoryOrder order, bool isDiscountForTotal, string? error_discount = "disocunt percentage => can't by more than 100")
        {
            decimal Calcolated_Discount = 0;
            if (orderItem.Discount != 0 || orderItem.DiscountInPercentage != 0)
            {

            }
            else if (orderItem.Discount == 0 && orderItem.DiscountInPercentage == 0)
                orderItem.discount_inpercentage_is_first = false;
            else if (orderItem.Discount == 0)
                orderItem.discount_inpercentage_is_first = true;
            else if (orderItem.DiscountInPercentage == 0)
                orderItem.discount_inpercentage_is_first = false;


            order.Is_Discount_For_Total = isDiscountForTotal;


            oRderItem_Discount_Salary.SetOrderItem(orderItem);
            orderItem.DiscountInPercentage = 0;

            oRderItem_Discount_Salary.Set_order_item_detalis(order_item_delies, order);
            if (isDiscountForTotal)
                oRderItem_Discount_Salary.Add_Discount_Salary(discount, error_discount);
            else
                oRderItem_Discount_Salary.Add_Discount_Salary_Orignal_Price(discount, error_discount);
            Calcolated_Discount = orderItem.Discount;
            return Calcolated_Discount;
        }
    }
}
