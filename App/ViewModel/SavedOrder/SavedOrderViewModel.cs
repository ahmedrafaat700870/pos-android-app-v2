namespace App.ViewModel.SavedOrder
{
    public partial class SavedOrderViewModel : ObservableObject
    {
        [ObservableProperty] private ObservableCollection<SavedOrderItemModel> items;

        private readonly ISavedOrder _savedOrder;
        public SavedOrderViewModel(ISavedOrder savedorder) // ISavedOrder savedOrder
        {
            Items = new ObservableCollection<SavedOrderItemModel>();
            _savedOrder = savedorder;
        }

        [ObservableProperty] private SavedOrderPageLang lang;

        public void GetLnag()
        {
            Lang = HerlperSettings.GetLang().SavedOrderPageLang.GetLang();
        }

        public async Task LoadData()
        {
            GetLnag();
            Clear();
            var orders = await _savedOrder.GetAll();
            foreach (var order in orders)
                Items.Add(new SavedOrderItemModel(order ,this._savedOrder , RemoveOrderFromSavedOrder));
        }

        private void RemoveOrderFromSavedOrder(SavedOrderItemModel savedOrder)
        {
            this.Items.Remove(savedOrder);
            bool isEmpty = this.Items?.Any() != true;
            if (isEmpty)
                GoHome();
        }

        private void GoHome()
        {
            App.helperNavigation.NavigateToHome();
        }

        public bool IsOrderNotEmpty()
        {
            if(App.order.ClientId != 0 || App.order.ClientId != null || App.order.InventoryOrderProducts is not null || App.order.InventoryOrderProducts.Count > 0)
                return false;
            return true;
        }

        public async Task<bool> SaveOrder()
        {
            return await this._savedOrder.Add(App.order);
        }

        public async Task<bool> UpdateOrder()
        {
            return await this._savedOrder.UpdateOrder(App.order);
        }

        private void Clear()
        {
            Items.Clear();
        }
    }
}
