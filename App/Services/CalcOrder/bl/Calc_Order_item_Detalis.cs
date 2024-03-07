using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.CalcOrder.bl
{
    public class Calc_Order_item_Detalis
    {
        private InventoryOrderitem Order_Item = new InventoryOrderitem();
        private Order_Item_Detalis Order_Item_Detalis = new Order_Item_Detalis();
        private InventoryOrder Order = null!;
        private decimal _order_total = 0;
        private decimal _order_subtotal = 0;
        private decimal _order_tax = 0;
        private bool is_discount_for_total = true;

        public void Set_Order_Item(InventoryOrderitem order_item)
        {
            Order_Item = order_item;
        }

        public void Set_Order(InventoryOrder order)
        {
            Order = order;
            _order_total = Order.InventoryOrderProducts.Sum(x => x.Orderitem.Total * x.Orderitem.Quantity);
            _order_total += Order.InventoryOrderProducts.Sum(x => x.Orderitem.InventoryAddonitems.Sum(x => x.Total * x.Qty));

            _order_subtotal = Order.InventoryOrderProducts.Sum(x => x.Orderitem.Subtotal * x.Orderitem.Quantity);
            _order_subtotal += Order.InventoryOrderProducts.Sum(x => x.Orderitem.InventoryAddonitems.Sum(x => x.Price_Befor_Tax * x.Qty));

            _order_tax = Order.InventoryOrderProducts.Sum(x => x.Orderitem.TaxTotal * x.Orderitem.Quantity);
            _order_tax += Order.InventoryOrderProducts.Sum(x => x.Orderitem.InventoryAddonitems.Sum(x => x.Tax_Total * x.Qty));
        }

        public void Reseat(InventoryOrderitem order_item)
        {
            Order_Item = null!;
            Order_Item_Detalis = null!;
            Order_Item = order_item;
            Order_Item_Detalis = new Order_Item_Detalis();
        }

        public void Calc_Order_Item(bool is_discunt_for_total)
        {
            is_discount_for_total = is_discunt_for_total;
            decimal add_on_total = 0;
            decimal add_on_subtotal = 0;
            decimal add_on_tax = 0;

            /*foreach (var add_on in Order_Item.InventoryAddonitems)
            {
                add_on_total += add_on.Total * add_on.Qty;
                add_on_subtotal += add_on.Price_Befor_Tax * add_on.Qty;
                add_on_tax += add_on.Tax_Total * add_on.Qty;
            }*/


            decimal order_item_total = Order_Item.Quantity * Order_Item.Total;
            decimal order_item_subtotal = Order_Item.Quantity * Order_Item.Subtotal;
            decimal order_item_tax = Order_Item.Quantity * Order_Item.TaxTotal;


            order_item_total += add_on_total;
            order_item_subtotal += add_on_subtotal;
            order_item_tax += add_on_tax;


            Order_Item_Detalis.Order_Item_Total = order_item_total;
            Order_Item_Detalis.Order_Item_SubTotal = order_item_subtotal;
            Order_Item_Detalis.Order_Item_Tax = order_item_tax;

            if (Order.Discount != 0 || Order.DiscountInPercentage != 0)
            {
                Order_Item_Detalis.Discount_For_Order_Total = calc_discount_total_for_item_from_order(Order_Item_Detalis.Order_Item_Total);
                Order_Item_Detalis.Discount_For_Order_Subtotal = calc_discount_subtotal_for_item_from_order(Order_Item_Detalis.Order_Item_SubTotal);
                Order_Item_Detalis.Discount_For_Order_Tax = calc_discount_tax_for_item_from_order(Order_Item_Detalis.Order_Item_Tax);
            }


            Order_Item_Detalis.Order_Item_Disocunt_Total = calc_disocunt_total();
            Order_Item_Detalis.Order_Item_Discount_SubTotal = calc_disocunt_subtotal();
            Order_Item_Detalis.Order_Item_Discount_Tax = calc_disocunt_tax();

        }

        public List<TaxModel> Calc_Order_Item_With_Taxces()
        {
            List<TaxModel> tax_model = new List<TaxModel>();
            decimal total_without_tax = Get_Order_Item_Total() * 100
                / (Order_Item.Percentage_Taxes + 100);
            decimal total_disocunt_without_tax = Get_Order_Item_Disocunt_Total() * 100
                / (Order_Item.Percentage_Taxes + 100);
            foreach (var tax in Order_Item.Product.InventoryProductTaxes)
            {
                TaxModel user_tax = new TaxModel();
                user_tax.Tax_name = tax.Tax.Name;
                user_tax.Tax_percentage = tax.Tax.PercentageValue;
                user_tax.Tax_amount = user_tax.Tax_percentage / 100 * total_without_tax;
                user_tax.Tax_discount = user_tax.Tax_percentage / 100 * total_disocunt_without_tax;
                user_tax.Tax_amount_after_discount = user_tax.Tax_amount - user_tax.Tax_discount;

                Check_From_Tax(user_tax, tax_model);
            }
            return tax_model;

        }
        private void Check_From_Tax(TaxModel new_tax, List<TaxModel> old_taxes)
        {
            foreach (var item in old_taxes)
            {
                if (item.Tax_name == new_tax.Tax_name)
                {
                    item.Tax_amount += new_tax.Tax_amount;
                    item.Tax_discount += new_tax.Tax_discount;
                    item.Tax_amount_after_discount += new_tax.Tax_amount_after_discount;
                    return;
                }
            }
            old_taxes.Add(new_tax);
        }
        private decimal calc_disocunt_total()
        {
            decimal discount = Order_Item_Detalis.Discount_For_Order_Total;
            decimal total = Order_Item_Detalis.Order_Item_Total - Order_Item_Detalis.Discount_For_Order_Total;
            decimal subtotal = Order_Item_Detalis.Order_Item_SubTotal - Order_Item_Detalis.Discount_For_Order_Subtotal;
            decimal total_after_discount = total;

            decimal percentage_item_from_order = 0;
            try
            {
                if (is_discount_for_total)
                    percentage_item_from_order = total_after_discount / total;
                else
                    percentage_item_from_order = total_after_discount / subtotal;

                if (Order_Item.discount_inpercentage_is_first)
                {
                    total_after_discount -= Order_Item.DiscountInPercentage * total_after_discount;
                    if (Order_Item.Discount != 0)
                        total_after_discount -= Order_Item.Discount * percentage_item_from_order;
                }
                else
                {
                    total_after_discount -= percentage_item_from_order * Order_Item.Discount;
                    if (Order_Item.DiscountInPercentage != 0)
                        total_after_discount -= total_after_discount * Order_Item.DiscountInPercentage;
                }
            }
            catch
            {
                discount = 0;
            }
            discount = total - total_after_discount;
            check_from_negative_value(discount);
            return discount;

        }
        private decimal calc_discount_total_for_item_from_order(decimal total)
        {
            decimal discount_order_for_item = 0;

            decimal total_after_discount = total;

            decimal percentage_item_from_order = 0;

            if (is_discount_for_total)
                percentage_item_from_order = total_after_discount / _order_total;
            else
                percentage_item_from_order = total_after_discount / _order_subtotal;


            if (Order.discount_inpercentage_is_first)
            {
                total_after_discount -= total_after_discount * Order.DiscountInPercentage;

                if (Order.Discount != 0)
                    total_after_discount -= percentage_item_from_order * Order.Discount;
            }
            else
            {

                total_after_discount -= percentage_item_from_order * Order.Discount;

                if (Order.DiscountInPercentage > 0)
                    total_after_discount -= total_after_discount * Order.DiscountInPercentage;

            }
            discount_order_for_item = total - total_after_discount;
            check_from_negative_value(discount_order_for_item);
            return discount_order_for_item;
        }
        private decimal calc_disocunt_subtotal()
        {
            decimal discount = 0;
            decimal total = Order_Item_Detalis.Order_Item_Total - Order_Item_Detalis.Discount_For_Order_Total;
            decimal subtotal = Order_Item_Detalis.Order_Item_SubTotal - Order_Item_Detalis.Discount_For_Order_Subtotal;

            decimal subtotal_after_discount = subtotal;

            decimal percentage_item_from_order = 0;

            try
            {
                if (is_discount_for_total)
                    percentage_item_from_order = subtotal_after_discount / total;
                else
                    percentage_item_from_order = subtotal_after_discount / subtotal;

                if (Order_Item.discount_inpercentage_is_first)
                {
                    subtotal_after_discount -= Order_Item.DiscountInPercentage * subtotal_after_discount;
                    if (Order_Item.Discount != 0)
                        subtotal_after_discount -= percentage_item_from_order * Order_Item.Discount;
                }
                else
                {
                    subtotal_after_discount -= Order_Item.Discount * percentage_item_from_order;
                    if (Order_Item.DiscountInPercentage != 0)
                        subtotal_after_discount -= Order_Item.DiscountInPercentage * subtotal_after_discount;
                }
            }
            catch
            {
                discount = 0;
            }
            discount = subtotal - subtotal_after_discount;

            check_from_negative_value(discount);

            return discount;
        }
        private decimal calc_discount_subtotal_for_item_from_order(decimal subtotal)
        {
            decimal discount_order_for_item = 0;

            decimal subtotal_after_discount = subtotal;

            decimal percentage_item_from_order = 0;

            if (is_discount_for_total)
                percentage_item_from_order = subtotal_after_discount / _order_total;
            else
                percentage_item_from_order = subtotal_after_discount / _order_subtotal;

            if (Order.discount_inpercentage_is_first)
            {
                subtotal_after_discount -= subtotal_after_discount * Order.DiscountInPercentage;
                if (Order.Discount != 0)
                    subtotal_after_discount -= percentage_item_from_order * Order.Discount;
            }
            else
            {
                subtotal_after_discount -= percentage_item_from_order * Order.Discount;
                if (Order.DiscountInPercentage > 0)
                    subtotal_after_discount -= subtotal_after_discount * Order.DiscountInPercentage;

            }
            discount_order_for_item = subtotal - subtotal_after_discount;
            check_from_negative_value(discount_order_for_item);
            return discount_order_for_item;
        }
        private decimal calc_disocunt_tax()
        {
            decimal discount = 0;
            decimal tax = Order_Item_Detalis.Order_Item_Tax - Order_Item_Detalis.Discount_For_Order_Tax;
            decimal total = Order_Item_Detalis.Order_Item_Total - Order_Item_Detalis.Discount_For_Order_Total;
            decimal subtotal = Order_Item_Detalis.Order_Item_SubTotal - Order_Item_Detalis.Discount_For_Order_Subtotal;

            decimal tax_after_discount = tax;

            decimal percentage_item_from_order = 0;

            try
            {

                if (is_discount_for_total)
                    percentage_item_from_order = tax_after_discount / total;
                else
                    percentage_item_from_order = tax_after_discount / subtotal;

                if (Order_Item.discount_inpercentage_is_first)
                {
                    tax_after_discount -= Order_Item.DiscountInPercentage * tax_after_discount;
                    if (Order_Item.Discount != 0)
                        tax_after_discount -= percentage_item_from_order * Order_Item.Discount;
                }
                else
                {
                    tax_after_discount -= Order_Item.Discount * percentage_item_from_order;
                    if (Order_Item.DiscountInPercentage != 0)
                        tax_after_discount -= Order_Item.DiscountInPercentage * tax_after_discount;
                }
            }
            catch
            {
                discount = 0;
            }

            discount = tax - tax_after_discount;
            check_from_negative_value(discount);
            return discount;
        }
        private decimal calc_discount_tax_for_item_from_order(decimal tax)
        {
            decimal discount_order_for_item = 0;

            decimal tax_after_discount = tax;

            decimal percentage_item_from_order;

            if (is_discount_for_total)
                percentage_item_from_order = tax / _order_total;
            else
                percentage_item_from_order = tax / _order_subtotal;

            if (Order.discount_inpercentage_is_first)
            {
                tax_after_discount -= tax_after_discount * Order.DiscountInPercentage;
                if (Order.Discount != 0)
                    tax_after_discount -= percentage_item_from_order * Order.Discount;

            }
            else
            {
                tax_after_discount -= percentage_item_from_order * Order.Discount;
                if (Order.DiscountInPercentage > 0)
                    tax_after_discount -= tax_after_discount * Order.DiscountInPercentage;
            }

            discount_order_for_item = tax - tax_after_discount;
            check_from_negative_value(discount_order_for_item);
            return discount_order_for_item;
        }

        private void check_from_negative_value(decimal value)
        {
            if (value < 0)
                throw new ArgumentException("");
        }

        public decimal Get_Order_Item_Total() => Order_Item_Detalis.Order_Item_Total;
        public decimal Get_Order_Item_SubTotal() => Order_Item_Detalis.Order_Item_SubTotal;
        public decimal Get_Order_Item_Tax() => Order_Item_Detalis.Order_Item_Tax;
        public decimal Get_Order_Item_Disocunt_Total() => Order_Item_Detalis.Order_Item_Disocunt_Total + Order_Item_Detalis.Discount_For_Order_Total;
        public decimal Get_Order_Item_Discount_SubTotal() => Order_Item_Detalis.Order_Item_Discount_SubTotal + Order_Item_Detalis.Discount_For_Order_Subtotal;
        public decimal Get_Order_Item_Discount_Tax() => Order_Item_Detalis.Order_Item_Discount_Tax + Order_Item_Detalis.Discount_For_Order_Tax;

        

    }

    public class Order_Item_Detalis
    {
        public decimal Order_Item_Total { get; set; } = 0;
        public decimal Order_Item_SubTotal { get; set; } = 0;
        public decimal Order_Item_Tax { get; set; } = 0;
        public decimal Order_Item_Disocunt_Total { get; set; } = 0;
        public decimal Order_Item_Discount_SubTotal { get; set; } = 0;
        public decimal Order_Item_Discount_Tax { get; set; } = 0;
        public decimal Discount_For_Order_Total { get; set; } = 0;
        public decimal Discount_For_Order_Subtotal { get; set; } = 0;
        public decimal Discount_For_Order_Tax { get; set; } = 0;
    }

}
