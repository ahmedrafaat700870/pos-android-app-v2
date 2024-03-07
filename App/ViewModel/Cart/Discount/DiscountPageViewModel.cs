namespace App.ViewModel.Cart.Discount
{
    public partial class DiscountPageViewModel : ObservableObject
    {
        private ResourceDictionary Resorces;


        private Action alertSelectedItem;
        public void SertAlertSelectedItem(Action alertSelectedItem)
        {
            this.alertSelectedItem = alertSelectedItem;
        }
        private Action _calcOrder;

        [ObservableProperty]
        private ContentView conatiner;

        private CartItemModel _cartItem;


        [ObservableProperty]
        private Style orderButton;

        [ObservableProperty]
        private Style orderBorder;

        [ObservableProperty]
        private Style itemButton;

        [ObservableProperty]
        private Style itemBorder;

        private void SetStyle()
        {
            if (_cartItem is null)
            {
                OrderButton = this.Resorces["activeButton"] as Style;
                ItemButton = this.Resorces["disActiveButton"] as Style;
                OrderBorder = this.Resorces["activeBorder"] as Style;
                ItemBorder = this.Resorces["disActiveBorder"] as Style;
            }
            else
            {
                OrderButton = this.Resorces["disActiveButton"] as Style;
                ItemButton = this.Resorces["activeButton"] as Style;
                OrderBorder = this.Resorces["disActiveBorder"] as Style;
                ItemBorder = this.Resorces["activeBorder"] as Style;
            }

        }

        [ObservableProperty]
        private DiscountPageLang lang;

        public void LoadLang()
        {
            Lang = HerlperSettings.GetLang().DiscountPageLang.GetLang();
        }
        public DiscountPageViewModel(CartItemModel cartItem, ResourceDictionary Resorces
            , Action _calcOrder = null!)
        {

            this.Resorces = Resorces;
            if (cartItem is null)
                Conatiner = new DiscountForOrder(_calcOrder);
            else
            {
                _cartItem = cartItem;
                Conatiner = new DiscountForItem(cartItem, _calcOrder);
            }

            this._calcOrder = _calcOrder;
            SetStyle();
            LoadLang();
        }


        [RelayCommand]
        private void clickOrder()
        {
            ChangeStyles();
            Conatiner = new DiscountForOrder(_calcOrder);
        }
        [RelayCommand]
        private async void clickItem()
        {

            if (this._cartItem is null)
            {
                if (alertSelectedItem is not null) alertSelectedItem.Invoke();
                return;
            }
            ChangeStyles();
            Conatiner = new DiscountForItem(this._cartItem, _calcOrder);
        }


        private void ChangeStyles()
        {
            if (this.OrderButton == this.Resorces["activeButton"] as Style)
            {
                this.OrderButton = this.Resorces["disActiveButton"] as Style;
                this.OrderBorder = this.Resorces["disActiveBorder"] as Style;

                this.ItemButton = this.Resorces["activeButton"] as Style;
                this.ItemBorder = this.Resorces["activeBorder"] as Style;


            }
            else
            {
                this.OrderButton = this.Resorces["activeButton"] as Style;
                this.OrderBorder = this.Resorces["activeBorder"] as Style;

                this.ItemButton = this.Resorces["disActiveButton"] as Style;
                this.ItemBorder = this.Resorces["disActiveBorder"] as Style;
            }
        }
    }
}
