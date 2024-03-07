namespace App.Model
{
    public partial class OrderPageModel : ObservableObject
    {
        private int _id;
        [ObservableProperty] private InventoryOrderitem orderItem;
        [ObservableProperty] private decimal qty;
        [ObservableProperty] private string name;
        [ObservableProperty] private decimal price;
        [ObservableProperty] private bool refundAll = false;

        public bool IsDataEnable => !RefundAll;
        public OrderPageModel(InventoryOrderitem orderItem) 
        {
            RefundAll = false;
            this.orderItem = orderItem;
            _id = orderItem.Id;
            Qty = orderItem.Quantity;
            Name = orderItem.name;
            Price = orderItem.Total;
        }

        [RelayCommand]
        private void ClickIncerment()
        {
            ++Qty;
            CalcPrice();
        }
        [RelayCommand]
        private void ClickDecremnt()
        {
            --Qty;
            CalcPrice();
        }

        private void CalcPrice()
        {
            Price *= Qty;
        }
    }
}
