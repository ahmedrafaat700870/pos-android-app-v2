namespace App.ViewModel
{
    public partial class HomePageViewModel : ObservableObject
    {
        private readonly IUpdateDataHome _updateDataHome;

        private Task LoadDataGroupAsync() => Task.Run(() => LoadDataGroup(null));

        private readonly IApplicationData _applicationData;
        public HomePageViewModel(IApplicationData applicationData, IUpdateDataHome updateDataHome )
        {
            _updateDataHome = updateDataHome;
            prodcuts = new ObservableCollection<ProductModel>();
            groups = new ObservableCollection<GroupModel>();
            BackFromGroup = new ObservableCollection<BackFromGroupModel>();
            _applicationData = applicationData;
            OrderHeloper.SetActionCountProductInSale(ChangeCountProductInSale);
            CameraIndicators = new activityIndicatorsHomePage() { IsActive = false, IsItemVisable = true };
            ClientIndicators = new activityIndicatorsHomePage() { IsActive = false, IsItemVisable = true };
            CartIndicators = new activityIndicatorsHomePage() { IsActive = false, IsItemVisable = true };
            LoadLnag();
            CountOfProductInSale = 0;
        }
        public HomePageViewModel(IApplicationData applicationData, IUpdateDataHome updateDataHome , int countProductInSale)
        {
            _updateDataHome = updateDataHome;
            prodcuts = new ObservableCollection<ProductModel>();
            groups = new ObservableCollection<GroupModel>();
            BackFromGroup = new ObservableCollection<BackFromGroupModel>();
            _applicationData = applicationData;
            OrderHeloper.SetActionCountProductInSale(ChangeCountProductInSale);
            CameraIndicators = new activityIndicatorsHomePage() { IsActive = false, IsItemVisable = true };
            ClientIndicators = new activityIndicatorsHomePage() { IsActive = false, IsItemVisable = true };
            CartIndicators = new activityIndicatorsHomePage() { IsActive = false, IsItemVisable = true };
            LoadLnag();
            CountOfProductInSale = countProductInSale;
        }
        public void SetLable(Label label)
        {
            this.label = label;
        }
        private Label label;
        private async void changeAnigmation()
        {
            await label.ScaleTo(1.5);
            await label.ScaleTo(.5);
            await label.ScaleTo(1.5);
            await label.ScaleTo(.5);
            await label.ScaleTo(1.5);
            await label.ScaleTo(1);
        }
        [ObservableProperty] private HomePageLnag lang;
        public void LoadLnag()
        {
            Lang = HerlperSettings.GetLang().HomePageLnag.GetLang();
        }
        public async Task GetDataProducts()
        {
            await _applicationData.GetData();
            LoadDataGroup(null);
        }
        [RelayCommand]
        private async void ClickClient()
        {
            await ChangeIndicatorStatus(ClientIndicators);
            await NavigateToClientPage();
            await ChangeIndicatorStatus(ClientIndicators);
        }
        private async Task NavigateToClientPage()
        {
            await Task.Run(() =>
            {
                App.helperNavigation.NavigateToClientPage();
            });
        }
        [RelayCommand]
        private async void ClickCart()
        {
            await ChangeIndicatorStatus(CartIndicators);
            await NavigateToCartPage();
            await ChangeIndicatorStatus(CartIndicators);

        }
        private async Task NavigateToCartPage()
        {
            await Task.Run(() =>
            {
                App.helperNavigation.NvigateToCartPage();
            });
        }


        [ObservableProperty]
        private ObservableCollection<ProductModel> prodcuts;
        [ObservableProperty]
        private ObservableCollection<GroupModel> groups;
        [ObservableProperty]
        private ObservableCollection<BackFromGroupModel> backFromGroup;
        [ObservableProperty]
        private string seachBar;
        [ObservableProperty]
        private int countOfProductInSale;

        public int GetCountProductInSale() => CountOfProductInSale;
        private void ChangeCountProductInSale(int count)
        {
            CountOfProductInSale = count;
            changeAnigmation();
        }
        private void clearProductsAndGroups()
        {
            Prodcuts.Clear();
            Groups.Clear();
            BackFromGroup.Clear();
        }
        private IDispatcher dispatcher;
        public void AddDispatcher(IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
        }
        public void LoadDataGroupFirstTime()
        {
            DataGroups.Clear();
            LoadDataGroup(null);
        }

        public void LoadGroupFirstTime()
        {
            DataGroups.Clear();
            LoadDataGroup(null);
        }



        public void LoadDataGroup(int? groupId)
        {
            DataGroups.Push(groupId);
            clearProductsAndGroups();


            var _groups = App.appServices.products.product_groups.Where(x => x.parent == groupId);
            foreach (var group in _groups)
                Groups.Add(new GroupModel(group, LoadDataGroup));


            var _products = App.appServices.products.products.Where(x => x.group == groupId);
            foreach (var product in _products)
                Prodcuts.Add(new ProductModel(product));

            if (groupId is null) return;
            BackFromGroup.Add(new BackFromGroupModel(BackToGroup));

        }
        private void BackToGroup()
        {
            DataGroups.Pop();
            int? lastGroup = DataGroups.Pop();
            LoadDataGroup(lastGroup);
        }
        private Stack<int?> DataGroups = new Stack<int?>();
        private void RessetDataGroups()
        {
            DataGroups = new Stack<int?>();
        }
        public void ChangeSeachBar()
        {
            long barcode = 0;
            var isBarCode = long.TryParse(this.SeachBar, out barcode);
            if (isBarCode)
            {
                int sType = App.scalesHelper.GetScaleTyep();
                if (this.SeachBar.Length == 13 && 13 == sType)
                {
                    // barcode or sclae 13
                    IScalesServices s = new Scale13Services();
                    var isSuccess = s.GetByCode(barcode);
                    if (!isSuccess)
                    {
                        var successAddByBarCode = AddProductByBarcode(barcode);
                        if (!successAddByBarCode)
                            return;
                    }
                    RessetSeachBar();
                }
                else if (SeachBar.Length == 18 && 18 == sType)
                {
                    IScalesServices s = new Scale18Services();
                    var isSuccess = s.GetByCode(barcode);
                    // falid found product .
                    RessetSeachBar();
                }

            }
            // seach for product or groups that contains this charcter .

            SeachByName();
        }
        private void RessetSeachBar()
        {
            SeachBar = string.Empty;
            clearProductsAndGroups();
            RessetDataGroups();
            LoadDataGroup(null);
        }

        [RelayCommand]
        private async void Search()
        {
                ChangeSeachBar();
            
        }

        private void SeachByName()
        {
            RessetDataGroups();
            clearProductsAndGroups();
            if (string.IsNullOrEmpty(SeachBar)) // set default
            {
                LoadDataGroup(null);
                return;
            }
            var _products = App.appServices.products.products.Where(x => x.name.Contains(SeachBar));
            foreach (var product in _products)
                Prodcuts.Add(new ProductModel(product));
            var _groups = App.appServices.products.product_groups.Where(x => x.name.Contains(SeachBar));
            foreach (var group in _groups)
                Groups.Add(new GroupModel(group, LoadDataGroup));
            DataGroups.Push(null);
        }
        [RelayCommand]
        private async void ClickCamera()
        {
            await ChangeIndicatorStatus(CameraIndicators);
            await LoadCamera();
            await ChangeIndicatorStatus(CameraIndicators);
        }
        private async Task ChangeIndicatorStatus(activityIndicatorsHomePage indicator)
        {
            await Task.Run(() =>
            {
                indicator.IsActive = !indicator.IsActive;
                indicator.IsItemVisable = !indicator.IsItemVisable;
            });
        }
        public async Task LoadCamera()
        {
            await Task.Run(() =>
            {
                _CameraView oCameraView = new _CameraView(SetSeach);
                App.helperNavigation.NvigateToUserPage(oCameraView);
            });
        }
        private void SeachByCode()
        {
            if (string.IsNullOrEmpty(SeachBar))
            {
                // set default 
                LoadDataGroup(null);
            }
            RessetDataGroups();
            clearProductsAndGroups();
            var _products = App.appServices.products.products.Where(x => x.code.Contains(SeachBar));
            foreach (var product in _products)
                Prodcuts.Add(new ProductModel(product));
        }
        private bool AddProductByBarcode(long barcode)
        {
            var p = App.appServices.products.products.FirstOrDefault(x => x.barcode == barcode.ToString());
            if (p is not null)
            {
                // add p
                OrderHeloper.AddToOrder(p, DateTime.Now);
                return true;
            }
            // check if item box cover barcode
            var i = App.appServices.products.item_box.FirstOrDefault(x => x.barcode == barcode.ToString());
            if (i is not null)
            {
                var product = App.appServices.products.products.FirstOrDefault(x => x.id == i.product);
                ItemBoxHelper.AddBoxToOrder(i, product);
                return true;
            }
            return false;
        }
        private void SetSeach(string barcode)
        {
            this.SeachBar = barcode;
        }
        [ObservableProperty]
        private activityIndicatorsHomePage cameraIndicators;
        [ObservableProperty]
        private activityIndicatorsHomePage clientIndicators;
        [ObservableProperty]
        private activityIndicatorsHomePage cartIndicators;
    }

    public partial class activityIndicatorsHomePage : ObservableObject
    {
        [ObservableProperty]
        private bool isActive;
        [ObservableProperty]
        private bool isItemVisable;
    }

}
