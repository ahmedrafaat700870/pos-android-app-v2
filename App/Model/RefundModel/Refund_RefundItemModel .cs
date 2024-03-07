namespace App.Model
{
    public partial class Refund_RefundItemModel : ObservableObject
    {
        private InventoryRefund _refund;
        public Refund_RefundItemModel(InventoryRefund refund) 
        {
            _refund = refund; 
        }

        [ObservableProperty] private string orderId;
        [ObservableProperty] private string refundId;
        [ObservableProperty] private DateTime refundDate;
        [ObservableProperty] private string client;


        [RelayCommand]
        private void ClickCart()
        {
            var vm = new RefundPagerViewModel();
            vm.Init(_refund);
            var page = new ViewModel.Refund.RefundPage.RefundPage(vm);
            App.helperNavigation.NvigateToUserPage(page);
        }
    }
}
