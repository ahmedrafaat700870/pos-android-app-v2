namespace App.ViewModel.Refund
{
    public partial class Refund_RefundViewModel : ObservableObject, IRefundViewModel
    {
        [ObservableProperty] private ObservableCollection<Refund_RefundItemModel> _refund;

        private IDataRefundServices<InventoryRefund> _refundServices;

        public Refund_RefundViewModel(IDataRefundServices<InventoryRefund> refundServices)
        {
            Clear();
            _refundServices = refundServices;
        }

        public void Clear()
        {
            if (this.Refund is null)
                this.Refund = new ObservableCollection<Refund_RefundItemModel>();
            this.Refund.Clear();
        }

        public async void LoadData()
        {
            List<InventoryRefund> data = await this._refundServices.GetByPage(1);
        }

        public void LoadLang()
        {

        }

        public void Print()
        {
        }
    }
}
