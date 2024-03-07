namespace App.ViewModel.Refund.Order_Page
{
    public partial class OrderPageViewModel : ObservableObject
    {
        [ObservableProperty] private ObservableCollection<OrderPageModel> orderItems;
        [ObservableProperty] private OrderPageModel orderItem;
        [ObservableProperty] private bool refundAll;
        [ObservableProperty] private int orderId;
        [ObservableProperty] private string clientName;
        [ObservableProperty] private string orderDate;
        [ObservableProperty] private string status;
        public OrderPageViewModel()
        {
            RefundAll = false;
        }
        public void Init(InventoryOrder order)
        {
            OrderId = order.Id;
            ClientName = order?.Client?.Name ?? string.Empty;
            OrderDate = order.OrderDate.ToString() ?? string.Empty;
            Status = "Payed";
            RefundAll = false;
            if (this.OrderItems is null)
                this.OrderItems = new ObservableCollection<OrderPageModel>();
            var _orderItems = order.InventoryOrderProducts.Select(x => x.Orderitem);
            foreach (var item in _orderItems)
                this.OrderItems.Add(new OrderPageModel(item));
        }
        [RelayCommand]
        private void ClickPrint()
        {
            // print order
        }

        [RelayCommand]
        private void ClickRefund()
        {
            // 1 get data refund .
            // 2 send data to api .
            // 3 if success =>
            // 3.1 print data refund.
        }

    }
}
