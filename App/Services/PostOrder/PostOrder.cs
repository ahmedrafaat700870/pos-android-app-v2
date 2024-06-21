namespace App.Services.PostOrder
{
    public class PostOrder : IPostOrder
    {
        public async Task<int> Send()
        {
            string url = URLS.post_inventory_orders;
            string token = App.appServices.currentUser.token ?? string.Empty;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Token " + token);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                
                Order_Post_Model order = convertOrder();
                var objectData = JsonConvert.SerializeObject(new List<Order_Post_Model>() { order });
                var content = new StringContent(objectData, encoding: Encoding.UTF8, "application/json");

                HttpResponseMessage responseMessage = null!;
                try
                {
                    responseMessage = await client.PostAsync(url, content);
                    string _content = await responseMessage.Content.ReadAsStringAsync();
                }
                catch
                {
                    return 3;
                }

                if (responseMessage.IsSuccessStatusCode)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }

        }

        private void CalcOrderTotal()
        {
            App.order.Subtotal = App.order.InventoryOrderProducts.Sum(x => x.Orderitem.Subtotal);
            App.order.TaxTotal = App.order.InventoryOrderProducts.Sum(x => x.Orderitem.TaxTotal);
            App.order.Price = App.order.InventoryOrderProducts.Sum(x => x.Orderitem.Total);
        }
        private Order_Post_Model convertOrder()
        {

            CalcOrderTotal();
            App.order.Subtotal = Convert.ToDecimal(string.Format("{0:N2}", App.order.Subtotal));
            App.order.TaxTotal = Convert.ToDecimal(string.Format("{0:N2}", App.order.TaxTotal));
            App.order.Price = Convert.ToDecimal(string.Format("{0:N2}", App.order.Price));
            App.order.Discount = Convert.ToDecimal(string.Format("{0:N2}", App.order.Discount));
            App.order.DiscountInPercentage = Convert.ToDecimal(string.Format("{0:N2}", App.order.DiscountInPercentage));
         
            Order_Post_Model oOrder_Post_Model = new Order_Post_Model()
            {
                subtotal = App.order.Subtotal,
                total_tax = App.order.TaxTotal,
                price_with_tax = App.order.Price,
                discount = App.order.Discount,
                discount_in_percentage = App.order.DiscountInPercentage,
                is_discount_for_total = App.order.Is_Discount_For_Total,
            };

            string format = "yyyy-MM-dd HH:mm:ss.ffffff";
            if (App.order.OrderDate is not null)
            {
                var d = ((DateTime)App.order.OrderDate).ToString(format);
                oOrder_Post_Model.add_date = d;
                oOrder_Post_Model.order_timestamp_const_stock = ((DateTime)App.order.OrderDate).ToString(format); ;
            }

            // customers


            if (App.order.ClientId is not null)
            {
                var user = App.appServices.user.customers.FirstOrDefault(x => x.id == App.order.ClientId);
                oOrder_Post_Model.customer = new Account_Client_Post_Model()
                {
                    name = user.name ,
                    phone_number = user.phone_number ,
                    email = user.email ,
                    is_supplier = user.is_supplier ,
                    address = user.address ,
                    vat_number = user.vat_number ,
                    customer_uuid = user.uuid , 
                    avatar = user.avatar ,
                    cloud_id = App.order.ClientId,
                };
            }
            else
            {
                oOrder_Post_Model.customer = null!;
            }

            // order item
            foreach (var order_item in App.order.InventoryOrderProducts)
            {
                order_item.Orderitem.Discount = Convert.ToDecimal(string.Format("{0:N2}", order_item.Orderitem.Discount));
                order_item.Orderitem.DiscountInPercentage = Convert.ToDecimal(string.Format("{0:N2}", order_item.Orderitem.DiscountInPercentage));
                order_item.Orderitem.Subtotal = Convert.ToDecimal(string.Format("{0:N2}", order_item.Orderitem.Subtotal));
                order_item.Orderitem.TaxTotal = Convert.ToDecimal(string.Format("{0:N2}", order_item.Orderitem.TaxTotal));
                order_item.Orderitem.Total = Convert.ToDecimal(string.Format("{0:N2}", order_item.Orderitem.Total));
                order_item oorder_item = new order_item()
                {
                    cloud_product_id = order_item.Orderitem.ProductId,
                    quantity = order_item.Orderitem.Quantity,
                    subtotal = order_item.Orderitem.Subtotal,
                    tax_total = order_item.Orderitem.TaxTotal,
                    price_with_tax = order_item.Orderitem.Total,
                    discount = order_item.Orderitem.Discount,
                    discount_in_percentage = order_item.Orderitem.DiscountInPercentage,
                    is_box = order_item.Orderitem.is_box,
                    is_promo = order_item.Orderitem.is_promo,
                    is_discount_for_total = order_item.Orderitem.Is_Discount_For_Total,
                    cloud_box_id = order_item.Orderitem.cloud_box_id
                };
                // addons
                foreach (var _addon in order_item.Orderitem.InventoryAddonitems)
                {
                    add_on addon = new add_on()
                    {
                        cloud_addon_type_id = _addon.AddonType.Cloud_Id,
                        quantity = _addon.Qty,
                        subtotal = _addon.Price_Befor_Tax,
                        tax_total = _addon.Tax_Total,
                        price_with_tax = _addon.Total,
                    };
                    oorder_item.addons.Add(addon);
                }

                oOrder_Post_Model.orders_item.Add(oorder_item);
            }

            // payments
            foreach (var payment in App.order.PaymentsPaymentamounts)
            {
                payments_amount opayments_amount = new payments_amount()
                {
                    amount = payment.Amount,
                    created_date = App.order.OrderDate
                };

                if (payment.GlobalTypeId is not null)
                    opayments_amount.cloud_global_type_id = payment.GlobalTypeId;

                if (payment.PaymentTypeId is not null)
                    opayments_amount.cloud_payment_type_id = payment.PaymentTypeId;

                oOrder_Post_Model.payments.Add(opayments_amount);
            }
            return oOrder_Post_Model;
        }

      


    }
    public class Order_Post_Model
    {
        public Order_Post_Model()
        {
            this.orders_item = new List<order_item>();
            this.payments = new List<payments_amount>();
        }

        public string order_timestamp_const_stock { get; set; } = null!;

        public decimal subtotal { get; set; }
        public decimal total_tax { get; set; }
        public decimal price_with_tax { get; set; }
        public decimal discount { get; set; }
        public decimal discount_in_percentage { get; set; }
        public bool is_discount_for_total { get; set; }
        public string add_date { get; set; } = null!;

        public Account_Client_Post_Model? customer { get; set; } = new Account_Client_Post_Model();
        public List<order_item> orders_item { get; set; }
        public List<payments_amount> payments { get; set; }
    }
    public class payments_amount
    {
        public decimal amount { get; set; }
        public int? cloud_global_type_id { get; set; } = null!;
        public int? cloud_payment_type_id { get; set; } = null!;
        public DateTime? created_date { get; set; } = null!;
    }
    public class order_item
    {
        public order_item()
        {
            this.addons = new List<add_on>();
        }

        public int? cloud_product_id = null!;
        public decimal quantity { get; set; }
        public decimal subtotal { get; set; }
        public decimal tax_total { get; set; }
        public decimal price_with_tax { get; set; }
        public decimal discount { get; set; }
        public decimal discount_in_percentage { get; set; }
        public bool is_promo { get; set; }
        public bool is_discount_for_total { get; set; }
        // check if box
        public bool is_box { get; set; }
        public int? cloud_box_id { get; set; } = null!;
        public List<add_on> addons { get; set; }

    }
    public class add_on
    {
        public int? cloud_addon_type_id { get; set; } = null!;
        public decimal quantity { get; set; }
        public decimal subtotal { get; set; }
        public decimal tax_total { get; set; }
        public decimal price_with_tax { get; set; }

    }

}
