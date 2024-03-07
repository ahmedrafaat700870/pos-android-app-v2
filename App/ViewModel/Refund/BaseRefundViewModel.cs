namespace App.ViewModel.Refund
{
    public partial class BaseRefundViewModel : ObservableObject
    {
        [ObservableProperty] private bool isActivityVisiableAndRunner;
        [ObservableProperty] private bool isGridVisiable;
        private void InitViews()
        {
            IsActivityVisiableAndRunner = false;
            IsGridVisiable = true;
          
        }
        private readonly Refund_OrderView Refund_OrderView;
        private readonly Refund_RefundView Refund_RefundView;
        private async Task ChangeActiviyStatus()
        {
            await Task.Run(() =>
            {
                IsActivityVisiableAndRunner = !IsActivityVisiableAndRunner;
                IsGridVisiable = !IsGridVisiable;
            });
        }
        public BaseRefundViewModel(Refund_OrderView Refund_OrderView, Refund_RefundView Refund_RefundView) 
        {
            this.Refund_OrderView = Refund_OrderView;
            this.Refund_RefundView = Refund_RefundView;
            InitViews();
            Content = Refund_OrderView;
        }
        [RelayCommand]
        private async void ClickOrders()
        {
            await ChangeActiviyStatus();
            Content = Refund_OrderView;
            Content.LoadData();
            await ChangeActiviyStatus();
        }
        [RelayCommand]
        private async void ClickRefunds()
        {
            await ChangeActiviyStatus();
            Content = Refund_RefundView;
            Content.LoadData();
            await ChangeActiviyStatus();
        }
        [ObservableProperty] private BaseRefundView content;

    }
}
