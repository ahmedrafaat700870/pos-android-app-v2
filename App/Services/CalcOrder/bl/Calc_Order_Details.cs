using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.CalcOrder.bl
{
    public class Calc_Order_Details
    {
        private InventoryOrder Order { get; set; } = null!;
        private Order_Detalis Order_Detalis { get; set; } = null!;
        private Calc_Order_item_Detalis Order_Item_Details = new Calc_Order_item_Detalis();
        private bool is_discount_for_total = true;
        public void Set_Order_Item_Details(Calc_Order_item_Detalis order_Item_Details)
        {
            Order_Item_Details = order_Item_Details;
        }

        public void Set_Order(InventoryOrder order)
        {
            Order = order;
            Order_Detalis = new Order_Detalis();
        }


        public void Reseat(InventoryOrder order)
        {

            Order = null!;
            Order_Detalis = null!;
            Order = order;
            Order_Detalis = new Order_Detalis();

        }


        public void Calc_Order()
        {
            is_discount_for_total = Order.Is_Discount_For_Total;
            foreach (var order_prodcut in Order.InventoryOrderProducts)
            {
                Order_Item_Details.Reseat(order_prodcut.Orderitem);
                Order_Item_Details.Set_Order(Order);
                Order_Item_Details.Calc_Order_Item(is_discount_for_total);


                Order_Detalis.Order_Total += Order_Item_Details.Get_Order_Item_Total();
                Order_Detalis.Order_Sub_Total += Order_Item_Details.Get_Order_Item_SubTotal();
                Order_Detalis.Order_Tax += Order_Item_Details.Get_Order_Item_Tax();
                Order_Detalis.Order_Discount_Total_Item += Order_Item_Details.Get_Order_Item_Disocunt_Total();
                Order_Detalis.Order_Discount_Subtotal_Item += Order_Item_Details.Get_Order_Item_Discount_SubTotal();
                Order_Detalis.Order_Discount_Tax_Item += Order_Item_Details.Get_Order_Item_Discount_Tax();

            }
        }

        public List<TaxModel> Calc_Order_With_Taxces()
        {
            List<TaxModel> taxs = new List<TaxModel>();
            is_discount_for_total = Order.Is_Discount_For_Total;
            Order_Item_Details = new Calc_Order_item_Detalis();
            foreach (var order_prodcut in Order.InventoryOrderProducts)
            {
                Order_Item_Details.Set_Order(Order);
                Order_Item_Details.Reseat(order_prodcut.Orderitem);
                Order_Item_Details.Calc_Order_Item(is_discount_for_total);

                Order_Detalis.Order_Total += Order_Item_Details.Get_Order_Item_Total();
                Order_Detalis.Order_Sub_Total += Order_Item_Details.Get_Order_Item_SubTotal();
                Order_Detalis.Order_Tax += Order_Item_Details.Get_Order_Item_Tax();
                Order_Detalis.Order_Discount_Total_Item += Order_Item_Details.Get_Order_Item_Disocunt_Total();
                Order_Detalis.Order_Discount_Subtotal_Item += Order_Item_Details.Get_Order_Item_Discount_SubTotal();
                Order_Detalis.Order_Discount_Tax_Item += Order_Item_Details.Get_Order_Item_Discount_Tax();

                List<TaxModel> order_item_taxces = Order_Item_Details.Calc_Order_Item_With_Taxces();
                foreach (var tax_model in order_item_taxces)
                    Check_From_Tax(tax_model, taxs);
            }
            return taxs;
        }
        private void Check_From_Tax(TaxModel new_tax, List<TaxModel> old_taxes)
        {
            foreach (var item in old_taxes)
            {
                if (item.Tax_name == new_tax.Tax_name)
                {
                    item.Tax_amount += new_tax.Tax_amount;
                    item.Tax_discount += new_tax.Tax_discount;
                    item.Tax_amount_after_discount += new_tax.Tax_amount - new_tax.Tax_discount;
                    return;
                }
            }
            old_taxes.Add(new_tax);
        }

        private decimal Calc_Discount_Total()
        {
            decimal discount = 0;
            decimal total = Order_Detalis.Order_Total - Order_Detalis.Order_Discount_Total_Item;
            decimal subtotal = Order_Detalis.Order_Sub_Total;
            try
            {
                if (Order.discount_inpercentage_is_first)
                {
                    discount = total * Order.DiscountInPercentage;
                    if (is_discount_for_total)
                    {
                        discount += Order.Discount;
                    }
                    else
                    {
                        decimal percentage_discount = total / subtotal;
                        discount += Order.Discount * percentage_discount;
                    }
                }
                else
                {
                    decimal percentage_discount = 1;
                    if (is_discount_for_total)
                    {
                        total -= Order.Discount;
                    }
                    else
                    {
                        percentage_discount = total / subtotal;
                        total -= Order.Discount * percentage_discount;
                    }
                    if (Order.DiscountInPercentage > 0)
                        discount = total * Order.DiscountInPercentage;
                    discount += Order.Discount * percentage_discount;
                }
            }
            catch
            {
                discount = 0;
            }


            return discount;

        }
        private decimal Calc_Discount_SubTotal()
        {

            decimal discount = 0;
            decimal total = Order_Detalis.Order_Total - Order_Detalis.Order_Discount_Total_Item;
            decimal subtotal = Order_Detalis.Order_Sub_Total - Order_Detalis.Order_Discount_Subtotal_Item;
#pragma warning disable IDE0059 // Unnecessary assignment of a value
#pragma warning disable CS0168 // Variable is declared but never used
            try
            {
                if (Order.discount_inpercentage_is_first)
                {
                    discount = subtotal * Order.DiscountInPercentage;
                    if (is_discount_for_total)
                    {
                        decimal percentage_discount = subtotal / total;
                        discount += Order.Discount * percentage_discount;
                    }
                    else
                    {
                        discount += Order.Discount;
                    }
                }
                else
                {
                    decimal percentage_discount = 1;
                    if (is_discount_for_total)
                    {

                        percentage_discount = subtotal / total;
                        subtotal -= Order.Discount * percentage_discount;
                    }
                    else
                    {
                        subtotal -= Order.Discount;
                    }
                    if (Order.DiscountInPercentage > 0)
                        discount = subtotal * Order.DiscountInPercentage;
                    discount += Order.Discount * percentage_discount;
                }

            }
            catch (Exception ex)
            {
                discount = 0;
            }
#pragma warning restore CS0168 // Variable is declared but never used
#pragma warning restore IDE0059 // Unnecessary assignment of a value

            return discount;


        }
        private decimal Calc_Discount_Tax()
        {

            decimal discount = 0;
            decimal total = Order_Detalis.Order_Total - Order_Detalis.Order_Discount_Total_Item;
            decimal subtotal = Order_Detalis.Order_Sub_Total - Order_Detalis.Order_Discount_Subtotal_Item;
            decimal tax = Order_Detalis.Order_Tax - Order_Detalis.Order_Discount_Tax_Item;
            try
            {
                if (Order.discount_inpercentage_is_first)
                {
                    discount = tax * Order.DiscountInPercentage;
                    if (is_discount_for_total)
                    {
                        decimal percentage_discount = tax / total;
                        discount += Order.Discount * percentage_discount;
                    }
                    else
                    {
                        decimal percentage_discount = tax / subtotal;
                        discount += Order.Discount * percentage_discount;
                    }
                }
                else
                {
                    decimal percentage_discount = 1;
                    if (is_discount_for_total)
                    {
                        percentage_discount = tax / total;
                        tax -= Order.Discount * percentage_discount;
                    }
                    else
                    {
                        percentage_discount = tax / subtotal;
                        tax -= Order.Discount * percentage_discount;
                    }
                    if (Order.DiscountInPercentage > 0)
                        discount = tax * Order.DiscountInPercentage;
                    discount += Order.Discount * percentage_discount;
                }
            }
            catch
            {
                discount = 0;
            }


            return discount;

        }


        public decimal Get_Order_Total() => Order_Detalis.Order_Total;
        public decimal Get_Order_SubTotal() => Order_Detalis.Order_Sub_Total;
        public decimal Get_Order_Tax() => Order_Detalis.Order_Tax;
        public decimal Get_Order_Discount_Total_Item() => Order_Detalis.Order_Discount_Total_Item;
        public decimal Get_Order_Discount_Subtotal_Item() => Order_Detalis.Order_Discount_Subtotal_Item;
        public decimal Get_Order_Discount_Tax_Item() => Order_Detalis.Order_Discount_Tax_Item;

        public decimal Get_Order_Total_After_Discount() => Order_Detalis.Order_Total - Order_Detalis.Order_Discount_Total_Item;
        public decimal Get_Order_SubTotal_After_Discount() => Order_Detalis.Order_Sub_Total - Order_Detalis.Order_Discount_Subtotal_Item;
        public decimal Get_Order_Tax_After_Discount() => Order_Detalis.Order_Tax - Order_Detalis.Order_Discount_Tax_Item;

        public Order_Detalis GetOrder_Detalis() => Order_Detalis;

    }

    public class Order_Detalis
    {
        public decimal Order_Total { get; set; } = 0;
        public decimal Order_Sub_Total { get; set; } = 0;
        public decimal Order_Tax { get; set; } = 0;

        public decimal Order_Discount_Total_Item { get; set; } = 0;
        public decimal Order_Discount_Subtotal_Item { get; set; } = 0;
        public decimal Order_Discount_Tax_Item { get; set; } = 0;

    }
    public class TaxModel
    {
        public string Tax_name { get; set; } = null!;
        public decimal Tax_percentage { get; set; } = 0;
        public decimal Tax_amount { get; set; } = 0;
        public decimal Tax_discount { get; set; } = 0;
        public decimal Tax_amount_after_discount { get; set; } = 0;
        public decimal qty { get; set; } = 0;
    }

}
