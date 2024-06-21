namespace App.Helpers
{
    public class OrderHeloper
    {

        private static Action<int> ActionCountProductInSale;

        public static void AddDataProductToCart(inventory_prodcut prodcut, DateTime addDate )
        {
            var _prodcut = App.order.InventoryOrderProducts.FirstOrDefault(x => x.Orderitem.ProductId == prodcut.id);
            AddToOrder(prodcut, DateTime.Now);
        }

        /// <summary>
        /// udpate product in cart 
        /// </summary>
        /// <param name="orderItem"></param>
        private static void UpdateToCart(InventoryOrderitem orderProduct )
        {
            var promo = App.helperPromo.CheckFromPromo(orderProduct, 1);

            if (promo is false)
            {
                orderProduct.Quantity += 1;
                for (int i = 0; i < App.order.InventoryOrderProducts.Count; i++)
                {
                    if (App.order.InventoryOrderProducts[i].Orderitem.ProductId == orderProduct.ProductId)
                    {
                        App.order.InventoryOrderProducts[i].Orderitem = orderProduct;
                        break;
                    }
                }
            }
            CalcOrderItemCountInOrder();
        }

        
        public static void AddOrderItemToOrderWhitePromo(InventoryOrderitem orderItem)
        {
            App.order.InventoryOrderProducts.Add(new InventoryOrderProduct() { Orderitem = orderItem , Added_Date = orderItem.Add_Date});
            CalcOrderItemCountInOrder();
        }
        
        /// <summary>
        /// add prodcut to order 
        /// </summary>
        public static void AddToOrder(inventory_prodcut prodcut , DateTime addDate)
        {
            var inventoryOrder = new InventoryOrderitem()
            {
                Quantity = 0,
                Subtotal = prodcut.subtotal,
                Total = prodcut.price_with_tax,
                ProductId = prodcut.id,
                tax_included = prodcut.tax_included,
                TaxTotal = prodcut.tax_total,
                Add_Date = addDate,
                original_price = prodcut.price,
                _product_api = prodcut,
                name = prodcut.name,
            };
            var orderProdcut = new InventoryOrderProduct() { Added_Date = addDate, Orderitem = inventoryOrder };
            inventoryOrder.Percentage_Taxes = HerlperInventroyOrderItem.GetPercentageTaxces(inventoryOrder.ProductId);

            App.order.InventoryOrderProducts.Add(orderProdcut);
            var promo = App.helperPromo.CheckFromPromo(orderProdcut.Orderitem, 1);

            if (promo is false)
                inventoryOrder.Quantity += 1;

            CalcOrderItemCountInOrder();
        }


       

        public static void AddOrderItemToOrder(InventoryOrderitem orderitem)
        {
            var orderProdcut = new InventoryOrderProduct() { Added_Date = orderitem.Add_Date, Orderitem = orderitem };
            orderitem.Percentage_Taxes = HerlperInventroyOrderItem.GetPercentageTaxces(orderitem.ProductId);
            App.order.InventoryOrderProducts.Add(orderProdcut);
            var promo = App.helperPromo.CheckFromPromo(orderProdcut.Orderitem, 1);
            if (promo is false)
                orderitem.Quantity = 1;


            CalcOrderItemCountInOrder();
        }
        public static void AddOrderItemToOrder(InventoryOrderitem orderitem , decimal qty)
        {
            var orderProdcut = new InventoryOrderProduct() { Added_Date = orderitem.Add_Date, Orderitem = orderitem };
            orderitem.Percentage_Taxes = HerlperInventroyOrderItem.GetPercentageTaxces(orderitem.ProductId);
            App.order.InventoryOrderProducts.Add(orderProdcut);
            var promo = App.helperPromo.CheckFromPromo(orderProdcut.Orderitem, qty);
            if (promo is false)
                orderitem.Quantity = qty;

            CalcOrderItemCountInOrder();
        }

        private bool CanAddOrUpdateInOrder(inventory_prodcut product , decimal qty)
        {
            if (product.quantity > qty)
                return true;
            return false;
        }



        public static void SetActionCountProductInSale(Action<int> actionCountProductInSale)
        {
            ActionCountProductInSale = actionCountProductInSale;
        }

        public static void CalcOrderItemCountInOrder()
        {
            if (ActionCountProductInSale is null) return;
            int count = App.order.InventoryOrderProducts.Count;
            ActionCountProductInSale.Invoke(count);
        }
        public static int GetCount() => App.order.InventoryOrderProducts.Count;
        


    }
}
