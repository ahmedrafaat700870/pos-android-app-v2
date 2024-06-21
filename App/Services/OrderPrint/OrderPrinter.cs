

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

        public async Task PrintAsync(InventoryOrder order)
        {


            string casherName = "ahmed"; // order?.CreatedBy?.FirstName ?? string.Empty + " " + order?.CreatedBy?.LastName ?? string.Empty;
            Discount discount = new Discount();

            if (order.Discount > 0)
            {
                discount.DiscountType = "$";
                discount.DiscountAmount = order.Discount;
            }
            if (order.DiscountInPercentage > 0)
            {
                discount.DiscountType = "%" + " " + order.DiscountInPercentage;
                this.calc_Order_Details.Set_Order(order);
                this.calc_Order_Details.Set_Order_Item_Details(this.calc_Order_item_Detalis);
                this.calc_Order_Details.Calc_Order();
                discount.DiscountAmount = this.calc_Order_Details.Get_Order_Discount_Total_Item();
            }
            App.order.OrderDate = DateTime.Now;
            PrinterModel model = new PrinterModel()
            {
                CasherName = casherName,
                discount = discount,
                OrderId = order.Id,
                OrderTime = (DateTime)order.OrderDate,
                OrderType = "Payed",
                subTotal = order.Subtotal,
                tax = order.TaxTotal,
                total = order.Price,
                Items = new List<OrderItems>()
            };
            foreach (var orderProduct in order.InventoryOrderProducts)
            {
                OrderItems orderItems = new OrderItems();
                orderItems.ItemName = orderProduct?.Orderitem?._product_api?.name ?? string.Empty;
                orderItems.ItemPrice = orderProduct.Orderitem.Total;
                orderItems.qty = orderProduct.Orderitem.Quantity;
                Discount order_item_discount = new Discount()!;
                if (orderProduct.Orderitem.Discount > 0)
                {
                    order_item_discount.DiscountType = "$";
                    order_item_discount.DiscountAmount = orderProduct.Orderitem.Discount;
                }
                if (orderProduct.Orderitem.DiscountInPercentage > 0)
                {
                    order_item_discount.DiscountType = "%" + " " + orderProduct.Orderitem.DiscountInPercentage;
                    this.calc_Order_item_Detalis.Set_Order(order);
                    this.calc_Order_item_Detalis.Set_Order_Item(orderProduct.Orderitem);
                    this.calc_Order_item_Detalis.Calc_Order_Item(order.Is_Discount_For_Total);
                    order_item_discount.DiscountAmount = this.calc_Order_item_Detalis.Get_Order_Item_Disocunt_Total();
                }
                orderItems.discount = order_item_discount;
                model.Items.Add(orderItems);
            }

            // for test qrcode
            model.qrCode = "total = 100.00 , subtotal = 86.00 , tax = 14.00";

            await _printer.PrintAsync(model);


        }
    }
}
