namespace App.Model
{
    public partial class RefundPageModel : ObservableObject
    {
        private int id;
        [ObservableProperty] private string name;
        [ObservableProperty] private decimal qty;
        [ObservableProperty] private decimal price;

        public RefundPageModel(InventoryRefunditem item)
        {
            id = item.Id;
            Name = item.Orderitem.name;
            Qty = item.Quantity;
            Price = item.Total;
        }

        
    }
}
