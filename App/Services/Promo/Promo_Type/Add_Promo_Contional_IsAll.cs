using App;
using HTTPCLIENT.models.api_promo;

namespace Services.Promo.Promo_Type
{
    public class Add_Promo_Contional_IsAll 
    {
        private InventoryOrder _Order { get; set; }
        private InventoryOrderitem orderItem;
        private readonly promo_item Promo;
        public Add_Promo_Contional_IsAll(InventoryOrderitem orderitem, promo_item promo, InventoryOrder order) 
        {
            this._Order = order;
            this.orderItem = orderitem;
            Promo = promo;
        }
        private void RemoveAllOrderItemFromOrder()
        {
            _Order.InventoryOrderProducts.RemoveAll(x => x.Orderitem.ProductId == this.orderItem.ProductId);
        }
        public void Add_Promo(decimal qty, Action LoadData)
        {
            RemoveAllOrderItemFromOrder();
            if (qty <= this.Promo.apply_all)
            {
                orderItem.Quantity = qty;
                //this._Order.InventoryOrderProducts.Add(new InventoryOrderProduct() { Orderitem = orderItem, Added_Date = orderItem.Add_Date });
                return;
            }
            else
                orderItem.Quantity = 0;

            this._Order.InventoryOrderProducts.Add(new InventoryOrderProduct() { Orderitem = orderItem, Added_Date = orderItem.Add_Date });
            while (qty > 0)
            {
                Add_Promo_Contional(1);
                qty--;
            }
            LoadData.Invoke();
        }

        public void Add_Promo_Contional(decimal qty = 1)
        {
            if (this.Promo.fixed_price == 0 && this.Promo.discount_in_percentage == 0)
            {
                this.orderItem.Quantity += qty;
                return;
            }

            decimal totalQtyOrderProdcut = Get_Order_Item_Count(qty);

            var t = GetTypeOfPromo(totalQtyOrderProdcut);
            if(t == PromoType.Stope)
            {
                this.orderItem.Quantity += qty;
                return;
            }


            if(t == PromoType.AddNewPromo)
            {
                // add new promo
                // 

                
                InventoryOrderitem PromoItem = new InventoryOrderitem
                {
                    Add_Date = this.orderItem.Add_Date,
                    original_price = this.orderItem.original_price,
                    ProductId = this.orderItem.ProductId,
                    Product = this.orderItem.Product,
                    Quantity = qty,
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
                    DiscountInPercentage = this.Promo.discount_in_percentage
                };

                if (this.Promo.fixed_price != 0)
                {
                    // change price order item .
                    PromoItem.original_price = this.Promo.fixed_price;
                    HelperTaxIncluded.AddPriceToOrderItem(this.Promo.fixed_price , PromoItem);
                }
               // this._Order.InventoryOrderProducts.Add(new InventoryOrderProduct() { Orderitem = PromoItem  , Added_Date = this.orderItem.Add_Date});

                UpdateOrderHeloper.ChangeLastOrderItem(PromoItem);

            }
             UpdateOrderHeloper.ChangeeQuanityLastOrderItem(orderItem.ProductId , qty);


        }

        private decimal Get_Order_Item_Count(decimal qty)
        {
            decimal count = 0;
            foreach (var order_item in this._Order.InventoryOrderProducts)
            {
                if (order_item.Orderitem.ProductId == this.orderItem.ProductId)
                    count += order_item.Orderitem.Quantity;
            }
            return count;
        }

        private PromoType GetTypeOfPromo(decimal qty)
        {
            decimal all = this.Promo.apply_all;

            decimal counter = 0;


            if (all > qty)
                return PromoType.Stope;

            //if (qty == all)
                return PromoType.AddNewPromo;

            //return PromoType.LastPromo;
        }

    }


    internal enum PromoType
    {
        Stope , AddNewPromo , LastPromo
    }
}
