
namespace App.ViewModel.Refund.RefundPage
{
    public partial class RefundPagerViewModel : ObservableObject
    {
        [ObservableProperty] private ObservableCollection<RefundPageModel> _items;

        [ObservableProperty] private int orderId;
        [ObservableProperty] private int refundId;
        [ObservableProperty] private string clientName;
        [ObservableProperty] private string refundDate;
        [ObservableProperty] private string status;

        private InventoryRefund _refund;

        public RefundPagerViewModel()
        {

        }

        public void Init(InventoryRefund refund)
        {
            OrderId = refund.InvoiceId;
            RefundId = refund.Id;
            ClientName = refund?.Invoice?.Client?.Name ?? string.Empty;
            RefundDate = refund?.Add_Date.ToString() ?? string.Empty;
            Status = "Refunded";
            if (Items is null)
                this.Items = new ObservableCollection<RefundPageModel>();
            _refund = refund!;
            var items = refund?.InventoryRefunditems ?? new List<InventoryRefunditem>();
            foreach (var item in items )
                this.Items.Add(new RefundPageModel(item));   
        }

        [RelayCommand]
        private void ClickPrint()
        {
            // here print refund.
        }

    }
}
