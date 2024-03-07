namespace Services.Cart.Classes
{
    public class Dicount_For_Order_Salary 
    {
        private InventoryOrder Order;
        public Dicount_For_Order_Salary(InventoryOrder order)
        {
            Order = order;
        }
        
        private Calc_Order_Details Order_Details { get; set; } = null!;
        public void Set_Order_Detalis(Calc_Order_Details Order_Details)
        {
            this.Order_Details = Order_Details;
            this.Order_Details.Set_Order(this.Order);
            
        }
        public void Add_Discount(decimal discount , string? errorMessage  = "if you add this discount the price will by less than 0 .")
        {
            this.Order.Discount = discount;
            decimal Price_After_Discount = Clac_Order_Total_Total_After_Discount();
            if (Price_After_Discount < 0)
            {
                this.Order.Discount = 0;
                this.Order.discount_inpercentage_is_first = true;
                throw new Exception(errorMessage);
            }
            
        }
        public void Add_Discount_Orignal_Price(decimal discount, string? errorMessage = "if you add this discount the price will by less than 0 .")
        {
            this.Order.Discount = discount;
            decimal Price_After_Discount = Calc_Order_SubTotal_After_Discount();
            if(Price_After_Discount < 0)
            {
                this.Order.Discount = 0;
                this.Order.discount_inpercentage_is_first = true;
                throw new Exception(errorMessage);
            }
        }

        private decimal Clac_Order_Total_Total_After_Discount()
        {
            this.Order_Details.Calc_Order();
            return this.Order_Details.Get_Order_Total()
                - this.Order_Details.Get_Order_Discount_Total_Item();
                
        }
        private decimal Calc_Order_SubTotal_After_Discount()
        {
            this.Order_Details.Calc_Order();
            return this.Order_Details.Get_Order_Total()
                - this.Order_Details.Get_Order_Discount_Total_Item();
                
        }
    }
}
