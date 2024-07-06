
namespace App.Services.OrderPrint
{
    public class OrderPrinter : IOrderPrinter
    {
        private readonly IPrinter _printer;
        private Calc_Order_Details calc_Order_Details;
        private Calc_Order_item_Detalis calc_Order_item_Detalis;

        public OrderPrinter(IPrinter printer)
        {
            calc_Order_Details = new Calc_Order_Details();
            calc_Order_item_Detalis = new Calc_Order_item_Detalis();
            _printer = printer;

        }


        private Discount GetOrderDiscount(InventoryOrder order)
        {
            Discount discount = new Discount();
            this.calc_Order_Details.Set_Order(order);
            this.calc_Order_Details.Set_Order_Item_Details(this.calc_Order_item_Detalis);
            this.calc_Order_Details.Calc_Order();
            if (order.Discount > 0)
            {
                discount.DiscountType = "$";
                discount.DiscountAmount = order.Discount;
            }
            if (order.DiscountInPercentage > 0)
            {
                discount.DiscountType = "%" + " " + order.DiscountInPercentage;
               
                discount.DiscountAmount = this.calc_Order_Details.Get_Order_Discount_Total_Item();
            }
            return discount;
        }

        private string GetCasherName()
        {
            var user = App.appServices.user.users.Where(x => x.id == App.appServices.currentUser.user_id).FirstOrDefault();
            string casherName = user?.first_name + " " + user?.last_name; // order?.CreatedBy?.FirstName ?? string.Empty + " " + order?.CreatedBy?.LastName ?? string.Empty;
            return casherName;
        }
        private void AddItemsToModel(InventoryOrder order, PrinterModel model)
        {
            bool isContaindedDiscount = false;
            this.calc_Order_item_Detalis.Set_Order(order);
            foreach (var orderProduct in order.InventoryOrderProducts)
            {
                isContaindedDiscount = false;
                OrderItems orderItems = new OrderItems();
                orderItems.ItemName = orderProduct?.Orderitem?._product_api?.name ?? string.Empty;
                orderItems.ItemPrice = orderProduct.Orderitem.Total;
                orderItems.qty = orderProduct.Orderitem.Quantity;
                Discount order_item_discount = new Discount()!;
                this.calc_Order_item_Detalis.Set_Order_Item(orderProduct.Orderitem);
                this.calc_Order_item_Detalis.Calc_Order_Item(order.Is_Discount_For_Total);
                if (orderProduct.Orderitem.Discount > 0)
                {
                    isContaindedDiscount = true;
                    order_item_discount.DiscountType = "$";
                    order_item_discount.DiscountAmount = orderProduct.Orderitem.Discount;
                }
                if (orderProduct.Orderitem.DiscountInPercentage > 0)
                {
                    isContaindedDiscount = true;
                    order_item_discount.DiscountType = "%" + " " + orderProduct.Orderitem.DiscountInPercentage;
                    order_item_discount.DiscountAmount = this.calc_Order_item_Detalis.Get_Order_Item_Disocunt_Total();
                }
                orderItems.discount = order_item_discount;
                model.Items.Add(orderItems);

                // add taxs
                AddTaxsToOrder(orderProduct.Orderitem.ProductId, model, orderProduct.Orderitem, order, isContaindedDiscount);
            }
        }


        private void AddTaxsToOrder(int productId, PrinterModel model, InventoryOrderitem orderitem, InventoryOrder order, bool isContainedDiscount)
        {

            decimal totalPercentageTax = 0;
            var taxs = HerlperInventroyOrderItem.GetTaxces(productId);
            totalPercentageTax = taxs.Sum(x => x.Value);

            foreach (var tax in taxs)
            {
                // check from discount
                decimal totalOrderItemTax = 0;
                if (isContainedDiscount)
                    totalOrderItemTax = this.calc_Order_item_Detalis.Get_Order_Item_Tax() - this.calc_Order_item_Detalis.Get_Order_Item_Discount_Tax();
                else
                    totalOrderItemTax = orderitem.TaxTotal;

                decimal taxAmount = 0;
                taxAmount = totalOrderItemTax * (tax.Value / totalPercentageTax);

                if (model.taxs.ContainsKey(tax.Key))
                    model.taxs[tax.Key].Amount += taxAmount;
                else
                    model.taxs.Add(tax.Key, new Taxs() { Percentage = tax.Value, Amount = taxAmount });
            }

        }

        private void AddPayment(InventoryOrder order, PrinterModel model)
        {
            foreach (var p in order.PaymentsPaymentamounts)
            {
                string name = string.Empty;
                if (p.GlobalTypeId is not null)
                {
                    var payment = App.appServices.payments.global_types.Where(x => x.id == p.GlobalTypeId).FirstOrDefault();
                    name = payment.name;
                }
                else if (p.PaymentTypeId is not null)
                {
                    var payments = App.appServices.payments.payment_types.Where(x => x.id == p.PaymentTypeId).FirstOrDefault();
                    name = payments.name;
                }
                if (model.payments.ContainsKey((DateTime)p.Created))
                    model.payments[(DateTime)p.Created].Amount += p.Amount;
                else
                    model.payments.Add((DateTime)p.Created, new Payment() { Name = name, Amount = p.Amount });
            }
        }
        public async Task PrintAsync(InventoryOrder order)
        {
            Discount discount = GetOrderDiscount(order);
            string casher_name = GetCasherName();
            PrinterModel model = new PrinterModel()
            {
                CasherName = casher_name,
                discount = discount,
                OrderId = order.Id,
                OrderTime = (DateTime)order.OrderDate,
                OrderType = "Payed",
                subTotal = order.Subtotal,
                tax = order.TaxTotal,
                total = order.Price,
            };

            if(order.ClientId is not null)
            {
                var client = App.appServices.user.customers.Where(x => x.id == order.ClientId).FirstOrDefault();
                model.clientName = client?.name ?? string.Empty;
            }


            AddItemsToModel(order, model);
            AddPayment(order, model);

            // for test qrcode
            model.qrCode = "total = 100.00 , subtotal = 86.00 , tax = 14.00";
            decimal totoalDiscount = this.calc_Order_Details.GetOrder_Detalis().Order_Discount_Total_Item;
            decimal percentageDiscount = model.subTotal / model.total;
            model.total -= totoalDiscount; 
            model.subTotal = model.subTotal - (percentageDiscount * totoalDiscount);
            model.totalDiscount = totoalDiscount;
            try
            {
                await _printer.PrintAsync(model);
            }
            catch (Exception ex)
            {
                ToastHelper.Show("Printing Error");
            }


        }


    }
}
