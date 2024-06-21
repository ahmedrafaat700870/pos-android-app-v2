
namespace App.Services.PrinterServices.OrderPrinter
{
    public class PrinterModel
    {
        public PrinterModel() 
        {
            Items = new List<OrderItems>();
        }
        public int OrderId { get; set; }
        public DateTime OrderTime { get; set; }
        public string OrderType { get; set; }
        public string CasherName { get; set; }
        public string PrunchName { get; set; }
        public List<OrderItems> Items { get; set; }

        public Discount? discount { get; set; }
        public decimal totalDiscount { get; set; }
        public decimal total { get; set; }
        public decimal subTotal { get;set; }
        public decimal tax { get;set; }
        public string qrCode { get; set; }
    }

    public class OrderItems
    {
        public decimal qty { get;set; }
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public decimal total => qty * ItemPrice;
        public Discount? discount { get; set; }
    }

    public class Discount()
    {
        public string DiscountType { get; set; }
        public decimal DiscountAmount { get; set; }
    }


}
