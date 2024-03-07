

namespace App.Helpers
{
    public class ItemBoxHelper
    {
        public static void AddBoxToOrder(ItemBoxes box , inventory_prodcut prodcut , decimal Price)
        {
            var inventoryOrder = new InventoryOrderitem()
            {
                Quantity = 0,
                Subtotal = prodcut.subtotal,
                Total = prodcut.price_with_tax,
                ProductId = prodcut.id,
                tax_included = prodcut.tax_included,
                TaxTotal = prodcut.tax_total,
                Add_Date = DateTime.Now,
                original_price = Price,
                _product_api = prodcut
            };
            inventoryOrder.original_price = box.unit_of_price * box.count;
            inventoryOrder.Percentage_Taxes = HerlperInventroyOrderItem.GetPercentageTaxces(inventoryOrder.ProductId);
            HelperTaxIncluded.AddPriceToOrderItem(inventoryOrder.original_price, inventoryOrder);
            OrderHeloper.AddOrderItemToOrder(inventoryOrder);

        }
        public static void AddBoxToOrder(ItemBoxes box, inventory_prodcut prodcut)
        {
            decimal _price = box.unit_of_price * box.count;
            decimal percentageTaxces = HerlperInventroyOrderItem.GetPercentageTaxces(prodcut.id);
            decimal Price = HelperTaxIncluded.CalcTotalPriceTaxIncludedOrNot(prodcut.tax_included, _price, percentageTaxces);
            var inventoryOrder = new InventoryOrderitem()
            {
                Quantity = 0,
                Subtotal = prodcut.subtotal,
                Total = prodcut.price_with_tax,
                ProductId = prodcut.id,
                tax_included = prodcut.tax_included,
                TaxTotal = prodcut.tax_total,
                Add_Date = DateTime.Now,
                original_price = Price,
                _product_api = prodcut
            };
            inventoryOrder.original_price = box.unit_of_price * box.count;
            HelperTaxIncluded.AddPriceToOrderItem(inventoryOrder.original_price, inventoryOrder);
            OrderHeloper.AddOrderItemToOrder(inventoryOrder);
        }
    }
}
