

namespace App.Model
{
    public partial class Refund_OrderItemModel : ObservableObject
    {
        private InventoryOrder _order;
        public Refund_OrderItemModel(InventoryOrder order)
        {
            _order = order;
        }
        [ObservableProperty] private string orderId;
        [ObservableProperty] private DateTime payDate;
        [ObservableProperty] private string client;
        [ObservableProperty] private bool status;


        [RelayCommand]
        private void ClickCard()
        {
            var vm = new OrderPageViewModel();
            vm.Init(_order);
            var page = new OrderPage(vm);
            App.helperNavigation.NvigateToUserPage(page);
        }
    }
}
