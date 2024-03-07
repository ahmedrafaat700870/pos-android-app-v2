namespace App.Services.Promo.Promo_Type
{
    public class ApplyPromoToNextV2
    {
        private InventoryOrder _Order { get; set; }
        private readonly promo_item Promo;
        private InventoryOrderitem orderItem;
        public ApplyPromoToNextV2(InventoryOrderitem orderitem, promo_item promo, InventoryOrder order)
        {
            this.orderItem = orderitem;
            Promo = promo;
            this._Order = order;

        }


        /*private void RemoveAllOrderItemFromOrder()
        {
            _Order.InventoryOrderProducts.RemoveAll(x =>x.Orderitem.ProductId == this.orderItem.ProductId);
        }
        public void AddPromo(decimal qty , Action LoadData)
        {

            RemoveAllOrderItemFromOrder();
            if (qty <= this.Promo.apply_all)
            {
                orderItem.Quantity = qty;
                App.order.InventoryOrderProducts.Add(new InventoryOrderProduct() { Orderitem = orderItem  , Added_Date = orderItem.Add_Date});
                return;
            }
            else
                orderItem.Quantity = 0;

            App.order.InventoryOrderProducts.Add(new InventoryOrderProduct() { Orderitem = orderItem , Added_Date = orderItem.Add_Date});
            while (qty > 0)
            {

                var promoItem = Add_Promo_Contional(1);
                if (promoItem != null)
                {
                    App.order.InventoryOrderProducts.Add(promoItem);
                }
                qty--;
            }
            LoadData.Invoke();
        }*/



        public void Add_Promo_Contional(decimal InteredQty = 1)
        {
            InventoryOrderProduct promoItem = null!;

            if (this.Promo.fixed_price == 0 && this.Promo.discount_in_percentage == 0)
            {
                this.orderItem.Quantity = InteredQty;
                return;
            }

            decimal totalQty = GetTotalQty();

            TypePromo t = GetTypeOfPromoV2(totalQty);

            if (t == TypePromo.Stop)
            {
                this.orderItem.Quantity = InteredQty;
                return;
            }

            if (t == TypePromo.LastPromo || t == TypePromo.NewPromo)
            {
                InventoryOrderitem promo_order_item = new InventoryOrderitem
                {
                    Add_Date = this.orderItem.Add_Date,
                    original_price = this.orderItem.original_price,
                    ProductId = this.orderItem.ProductId,
                    Product = this.orderItem.Product,
                    Quantity = InteredQty,
                    tax_included = this.orderItem.tax_included,
                    Total = this.orderItem.Total,
                    TaxTotal = this.orderItem.TaxTotal,
                    Percentage_Taxes = this.orderItem.Percentage_Taxes,
                    Subtotal = this.orderItem.Subtotal,
                    is_promo = true,
                    InventoryOrderProducts = this.orderItem.InventoryOrderProducts,
                    ItemBoxId = null,
                    Invoice = null,
                    _product_api = this.orderItem._product_api,
                };

                promo_order_item.is_promo = true;
                promo_order_item.DiscountInPercentage = Promo.discount_in_percentage;

                if (this.Promo.fixed_price != 0)
                {
                    // change price order item .
                    promo_order_item.original_price = this.Promo.fixed_price;
                    HelperTaxIncluded.AddPriceToOrderItem(promo_order_item.original_price, orderItem);
                }
                UpdateOrderHeloper.UpdateOrderItemByAddDate(promo_order_item);

            }
            else if (t == TypePromo.LastItem || t == TypePromo.NewItem)
            {
                this.orderItem.Quantity = InteredQty;

            }
        }



        private decimal GetTotalQty()
        {
            decimal total = 0;

            foreach (var item in App.order.InventoryOrderProducts)
                if (item.Orderitem.ProductId == orderItem.ProductId)
                    total += item.Orderitem.Quantity;
            return total;
        }

        private TypePromo GetTypeOfPromoV2(decimal totalQty)
        {
            TypePromo t = TypePromo.Stop;
            decimal all = Promo.apply_all;
            decimal next = Promo.apply_to_next;
            decimal counter = 0;


            if (totalQty == all)
                return TypePromo.NewPromo;



            totalQty += 1;
            while (totalQty > all)
            {

                if (counter + 1 == totalQty)
                {
                    t = TypePromo.NewItem;
                    break;
                }

                counter += all;
                if (counter >= totalQty)
                {
                    t = TypePromo.LastItem;
                    break;
                }

                if (counter + 1 == totalQty)
                {
                    t = TypePromo.NewPromo;
                    break;
                }

                counter += next;

                if (counter >= totalQty)
                {
                    t = TypePromo.LastPromo;
                    break;
                }
            }

            return t;
        }

        private TypePromo GetTypeOfPromo(decimal totalQty)
        {
            TypePromo t = TypePromo.Stop;
            decimal all = Promo.apply_all;
            decimal next = Promo.apply_to_next;
            decimal counter = 0;


            if (totalQty == all)
                return TypePromo.NewPromo;



            totalQty += 1;
            while (totalQty > all)
            {

                if (counter + 1 == totalQty)
                {
                    t = TypePromo.NewItem;
                    break;
                }

                counter += all;
                if (counter >= totalQty)
                {
                    t = TypePromo.LastItem;
                    break;
                }

                if (counter + 1 == totalQty)
                {
                    t = TypePromo.NewPromo;
                    break;
                }

                counter += next;

                if (counter >= totalQty)
                {
                    t = TypePromo.LastPromo;
                    break;
                }
            }

            return t;
        }
    }


    internal enum TypePromo { NewPromo, LastPromo, NewItem, LastItem, Stop }
}
