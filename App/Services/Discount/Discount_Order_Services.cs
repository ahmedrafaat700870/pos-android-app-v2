
namespace Services.Cart
{
    public class Discount_Order_Services
    {

        public void Add_Discount_Bercentage(decimal discount, InventoryOrder order , bool isDisocuntForTotal , string? errorMessage = "disocunt percentage => can't by more than 100")
        {
            if (discount > 100)
                throw new Exception(errorMessage);
            
            var oMain_Cart = new Discount_For_Order_Percentage(order);
            order.Discount = 0;
            
            if (order.Discount != 0 || order.DiscountInPercentage != 0)
            {

            }
            else if (order.Discount == 0 && order.DiscountInPercentage == 0)
                order.discount_inpercentage_is_first = true;
            else if(order.Discount == 0)
                order.discount_inpercentage_is_first = false;
            else if(order.DiscountInPercentage == 0)
                order.discount_inpercentage_is_first = true;
            if(isDisocuntForTotal)
                order.Is_Discount_For_Total = true;
            else
                order.Is_Discount_For_Total = false;


            (oMain_Cart as Discount_For_Order_Percentage)!.Add_Discount(discount);
            
        }
        public void Add_Discount_Salary(Calc_Order_Details Order_Details, decimal discount, InventoryOrder order , bool isDisocuntForTotal, string? errorMessage = "disocunt percentage => can't by more than 100")
        {
            var oMain_Cart = new Dicount_For_Order_Salary(order);
            order.DiscountInPercentage = 0;
            if (order.Discount != 0 || order.DiscountInPercentage != 0)
            {

            }
            else if (order.Discount == 0 && order.DiscountInPercentage == 0)
                order.discount_inpercentage_is_first = false;
            else if (order.Discount == 0)
                order.discount_inpercentage_is_first = true;
            else if (order.DiscountInPercentage == 0)
                order.discount_inpercentage_is_first = false;

            (oMain_Cart as Dicount_For_Order_Salary)!.Set_Order_Detalis(Order_Details);
            if (isDisocuntForTotal)
            {
                (oMain_Cart as Dicount_For_Order_Salary)!.Add_Discount(discount , errorMessage);
                order.Is_Discount_For_Total = true;
            }
            else
            {
                (oMain_Cart as Dicount_For_Order_Salary)!.Add_Discount_Orignal_Price(discount, errorMessage);
                order.Is_Discount_For_Total = false;
            }
        }
    }
}
