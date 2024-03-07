
namespace App.ViewModel.Refund
{
    public partial class Refund_OrderViewModel : ObservableObject, IRefundViewModel
    {
        [ObservableProperty] private ObservableCollection<Refund_OrderItemModel> _refund;
        private IDataRefundServices<InventoryOrder> _orderServices;
        private IRefundServices _refundServices;
        public Refund_OrderViewModel(IDataRefundServices<InventoryOrder> orderServices , IRefundServices refundServices)
        {
            Clear();
            _orderServices = orderServices;
            _refundServices = refundServices;
        }

        public void Clear()
        {
            if (_refund is null)
                _refund = new ObservableCollection<Refund_OrderItemModel>();
            _refund.Clear();
        }

        public async void LoadData()
        {
            List<InventoryOrder> orders = await _orderServices.GetByPage(1);
        }

        public void LoadLang()
        {
        }

        public void Print()
        {
        }

    }
}
