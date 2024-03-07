namespace App.ViewModel
{
    public partial class MainPageContentViewViewModel : ObservableObject
    {
        private readonly ISavedOrder savedOrder;
        private IEmpty emptySavedOrders;
        private readonly HomePage _homePage = null!;
        private readonly CardPage _cardPage = null!;
        private readonly ClientPage _clientPage = null!;
        private SavedOrderPage savedOrderPage;
        private readonly AddNewClientPage _addNewClientPage = null!;
        private readonly PaymentsPage _paymentPage = null!;
        private readonly SettignsPage _settingPage = null!;
       // private readonly RefundPage _refundPage = null!;
        [ObservableProperty] private ContentView mainContentView;
        private Color disActiveColor = new Color(41, 45, 50);
        private Color activeColor = new Color(51, 102, 255);

        [ObservableProperty] private Color homeColor;
        [ObservableProperty] private Color settingsColor;
        [ObservableProperty] private Color logoutColor;
        [ObservableProperty] private Color savedPageColor;
        [ObservableProperty] private Color refundPageColor;
        
        public void SetDefualtColor()
        {
            HomeColor = disActiveColor;
            SettingsColor = disActiveColor;
            LogoutColor = disActiveColor;
            SavedPageColor = disActiveColor;
            refundPageColor = disActiveColor;
        }
        public MainPageContentViewViewModel(HomePage homePage, CardPage cardPage, ClientPage clientpage, AddNewClientPage addNewClientPage, PaymentsPage paymentsPage, SettignsPage settingPage, ISavedOrder savedOrder , SavedOrderPage saveOrderPage)  //, RefundPage refundPage
        {
            _homePage = homePage;
            _cardPage = cardPage;
            _clientPage = clientpage;
            _settingPage = settingPage;
            _addNewClientPage = addNewClientPage;
            _paymentPage = paymentsPage;
            this.savedOrderPage = saveOrderPage ;
         //   _refundPage = refundPage;
            SetDefualtColor();
            HomeColor = activeColor;
            this.MainContentView = _homePage ?? new ContentView();
            this.emptySavedOrders = emptySavedOrders;
            this.savedOrder = savedOrder;
        }

        [RelayCommand]
        private void NavigateToRefundPage()
        {
            //_refundPage.LoadData();
            //this.MainContentView = _refundPage;
            SetDefualtColor();
            HomeColor = refundPageColor;
        }


        [RelayCommand]
        private void NavigateToHomePage()
        {
            _homePage.LoadLang();
            this.MainContentView = _homePage;
            SetDefualtColor();
            HomeColor = activeColor;
        }
        public async Task LoadDataHomeViewModel()
        {
            await _homePage.LoadData();
        }
        [RelayCommand]
        private void NaviageToCardPage()
        {
            _cardPage.LoadLang();
            this.MainContentView = _cardPage;
            _cardPage.LoadDataVM();
            SetDefualtColor();
        }
        [RelayCommand]
        private async void NavigateToClientPage()
        {
            SetDefualtColor();
            _clientPage.LoadLang();
            this.MainContentView = _clientPage;
            await _clientPage.Start();
        }
        [RelayCommand]
        private void NavigateToAddNewClinet()
        {
            SetDefualtColor();
            _addNewClientPage.LoadLang();
            this.MainContentView = this._addNewClientPage;
        }
        [RelayCommand]
        private void NavigateToPaymentPage()
        {
            SetDefualtColor();
            _paymentPage.LoadLang();
            this.MainContentView = this._paymentPage;
            _paymentPage.Start();
        }
        public void NaviagteToView(ContentView page)
        {
            SetDefualtColor();
            this.MainContentView = page;
        }
        public void NaviagteToPage(ContentPage page)
        {
            this.MainContentView.Content = page.Content;
            SetDefualtColor();
        }
        [RelayCommand]
        private void Logout()
        {
            App.DataUserRemeberMe.ReomveLastUser();
            SetDefualtColor();
            LogoutColor = activeColor;
            Application.Current.Quit();
        }

        [RelayCommand]
        private void NavigateToSettingPage()
        {
            _settingPage.LoadLang();
            this.MainContentView = _settingPage;
            _settingPage.LoadData();
            SetDefualtColor();
            SettingsColor = activeColor;
        }
        [RelayCommand]
        private async void NavigateToSavedOrderPage()
        {
            var lang = HerlperSettings.GetLang().ToastLang.GetLang();
            if (App.order.Id != 0 || App.order.InventoryOrderProducts.Count > 0)
            {
                this.savedOrder.Add(App.order);
                App.order = new InventoryOrder();
                OrderHeloper.CalcOrderItemCountInOrder();
                ToastHelper.Show(lang.SavedOrderSuccessfuly);
                return;
            }

            this.emptySavedOrders = GetIEmtpy();
            if (emptySavedOrders.IsSavedOrdersEmpty())
            {
                ToastHelper.Show(lang.NoOrdersSaved);
                return;
            }

            //this.savedOrderPage = getSavedOrderPage();
            await this.savedOrderPage.LoadData();
            this.MainContentView = this.savedOrderPage;
            SetDefualtColor();
            SavedPageColor = activeColor;
        }
        private IEmpty GetIEmtpy()
        {
            if (this.emptySavedOrders is null)
                this.emptySavedOrders = this.savedOrder;
            return emptySavedOrders;
        }
    }
}
