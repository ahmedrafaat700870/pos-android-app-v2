using XamarinESCUtils.Model;
using XamarinESCUtils.Platforms.Common;

namespace App.ViewModel.Settings
{
    public partial class SettingsPageViewModel : ObservableObject
    {

        private readonly IBlueToothService _blueToothService;
        private string[] pattern13 =
        [
            "1-5-6-1 price",
            "1-6-5-1 price",
            "2-4-6-1 price",
            "2-5-5-1 price",
            "2-6-4-1 price",
            "1-5-6-1 whieght",
            "1-6-5-1 whieght",
            "2-4-6-1 whieght",
            "2-5-5-1 whieght",
            "2-6-4-1 whieght"
            ];
        private string[] pattern18 =
            ["1-5-6-5-1", "1-6-5-5-1", "2-4-6-5-1", "2-5-5-5-1", "2-6-4-5-1"];

        [ObservableProperty]
        private List<string> scalePatterns;
        [ObservableProperty]
        private int selectedScalePattern;

        [ObservableProperty]
        private List<string> items;

        [ObservableProperty]
        private int selectedIndexLang;
        [ObservableProperty]
        private int selectedIndexDiscount;
        [ObservableProperty]
        private List<string> discountType;
        private SettingsModel _model;

        [ObservableProperty]
        private int starterCode;

        [ObservableProperty]
        private int endCode;

        [ObservableProperty]
        private int selectedScaleType;

        [ObservableProperty]
        private List<string> scalesTypes;

        [ObservableProperty]
        private int numberOfDightprice;
        [ObservableProperty]
        private int numberOfDightWeight;

        [ObservableProperty]
        private bool isNumberOfDightWeightVisable;

        [ObservableProperty]
        private bool isNumberOfDightPriceVisable;

        [ObservableProperty] private SettingsPageLang lang;

        [ObservableProperty] private List<string> printers;
        public void LoadLang()
        {
            Lang = HerlperSettings.GetLang().SettingsPageLang.GetLang();
            pattern13 = Lang.Pattern13;
        }
        private PrintService _printService;
        public SettingsPageViewModel(PrintService printService)
        {
            _blueToothService = App.GetBlueToothService();
            //LoadData();
            items = new List<string>();
            discountType = new List<string>();
            scalesTypes = new List<string>();
            scalePatterns = pattern13.ToList();
            IsNumberOfDightPriceVisable = true;
            IsNumberOfDightWeightVisable = false;
            _printService = printService;
            this.Printer = "printer";
        }

        private List<BluetoothInfo> bluetoothInfos = new List<BluetoothInfo>();

        [ObservableProperty] private string printer;
        [ObservableProperty] private int printerIndex;
        private string PrinterName;
       
        public void LoadData()
        {
            LoadLang();
            _model = GetSettingModle();
            SelectedIndexLang = _model.LangSelectedIndex;
            StarterCode = _model.StarterSacleCode;
            EndCode = _model.EndCode;
            SelectedScaleType = 0;
            SelectedIndexDiscount = _model.DiscountSelectedIndex;

            
            NumberOfDightprice = _model.ScaleDightOfPrice;
            NumberOfDightWeight = _model.ScaleDigthOfWehight;
            this.PrinterName = _model.Printer;
            if (_model.Scale == 18)
            {
                SelectedScaleType = 1;
                ScalePatterns = this.pattern18.ToList();
            }

            SelectedScalePattern = _model.SaclePattern - 1;
            ChagedNumberOfPriceAndWheightVisiable();
            //Printers = _printService.GetDeviceList().ToList();
            bluetoothInfos = _blueToothService.GetDeviceList().ToList();
            Printers = bluetoothInfos.Select(x => x.Name).ToList();
        }


        private void ChagedNumberOfPriceAndWheightVisiable()
        {
            if (SelectedScaleType == 1)
            {
                IsNumberOfDightWeightVisable = true;
                IsNumberOfDightPriceVisable = true;
            }
            else if (SelectedScalePattern > 4)
            {
                IsNumberOfDightPriceVisable = false;
                IsNumberOfDightWeightVisable = true;
            }
            else
            {
                IsNumberOfDightPriceVisable = true;
                IsNumberOfDightWeightVisable = false;
            }
        }

       
        private SettingsModel GetSettingModle()
        {
            return App.appServices.GetAppSettings();
        }
        public void SelectedItemChanged()
        {

        }

        [RelayCommand]
        private void ClickCancel()
        {
            GoHome();
        }


        public void ChangePrinter()
        {
            PrinterName = this.Printers[PrinterIndex];
        }

        [RelayCommand]
        private async void ClickAdd()
        {
            //ResourcesSettings.Lnag = "en";
            // save data in sqlLite;
            var lang = HerlperSettings.GetLang().ToastLang.GetLang();
            if (SelectedScalePattern == -1)
            {
                var message = lang.SelectePattern;

                ShowMessage(message);
                return;
            }

            if (StarterCode <= 0)
            {
                var message = lang.StarterCodeCanNotbezero;
                ShowMessage(message);
                return;
            }


            _model.DiscountSelectedIndex = SelectedIndexDiscount;
            _model.LangSelectedIndex = SelectedIndexLang;
            _model.EndCode = EndCode;
            _model.Scale = 13;
            _model.ScaleDightOfPrice = 0;
            _model.ScaleDigthOfWehight = NumberOfDightWeight;
            _model.ScaleDightOfPrice = NumberOfDightprice;
            if (!string.IsNullOrEmpty(PrinterName)) 
            {
                var b = this.bluetoothInfos.Where(x => x.Name == PrinterName).FirstOrDefault();
                var data = JsonConvert.SerializeObject(b);
                _model.Printer = data;
            }
            if (SelectedScaleType == 1)
                _model.Scale = 18;

            _model.SaclePattern = SelectedScalePattern + 1;

            string content = JsonConvert.SerializeObject(_model);
            App.GetReadAndWriteFile().WirteTextToFile(content, lang.Settings);
            ShowMessage(lang.SuccessAddsettings);
            App.appServices.SetAppSettings(_model);

            GoHome();
        }

        public void SelectedScaleTypeChanged()
        {
            SelectedScalePattern = 0;
            ScalePatterns = SelectedScaleType == 0 ? pattern13.ToList() : pattern18.ToList();
            ChagedNumberOfPriceAndWheightVisiable();
        }

        public void SelectedPatternChanged()
        {
            int indexPattern = SelectedScalePattern;
            if (indexPattern < 0) return;
            int starterCode = Convert.ToInt32(ScalePatterns[indexPattern].FirstOrDefault().ToString());
            if (StarterCode.ToString().Length > starterCode)
            {
                StarterCode = Convert.ToInt32(StarterCode.ToString().FirstOrDefault().ToString());
            }
            else if (StarterCode.ToString().Length < starterCode)
            {
                StarterCode = Convert.ToInt32(StarterCode.ToString() + StarterCode.ToString());
            }
            ChagedNumberOfPriceAndWheightVisiable();
            ValidateDightOfPrice();
            ValidateDightOfWeight();
        }

        public void StarterCodeChanged()
        {
            int indexPattern = SelectedScalePattern;
            if (indexPattern < 0) return;
            int starterCode = Convert.ToInt32(ScalePatterns[indexPattern].FirstOrDefault().ToString());
            SelectedScalePattern = StarterCode.ToString().Length != starterCode ? -1 : SelectedScalePattern;
            ChagedNumberOfPriceAndWheightVisiable();
        }

        private void GoHome()
        {
            App.helperNavigation.NavigateToHome();
        }

        private void ShowMessage(string error)
        {
            ToastHelper.Show(error);
        }

        public void ValidateDightOfPrice()
        {
            int max;

            if (SelectedScalePattern == -1)
            {
                NumberOfDightprice = 0;
                var message = HerlperSettings.GetLang().ToastLang.GetLang().SelectePattern;
                ShowMessage(message);
                return;
            }

            if (SelectedScaleType == 0)
            {
                if (SelectedScalePattern is 0 || SelectedScalePattern is 2)
                    max = 6;
                else if (SelectedScalePattern is 1 || SelectedScalePattern is 3)
                    max = 5;
                else
                    max = 4;
            }
            else
            {
                if (SelectedScalePattern is 0 || SelectedScalePattern is 2)
                    max = 6;
                else if (SelectedScalePattern is 1 || SelectedScalePattern is 3)
                    max = 5;
                else
                    max = 4;
            }

            NumberOfDightprice = NumberOfDightprice > max ? max : NumberOfDightprice;

        }
        public void ValidateDightOfWeight()
        {
            int max;

            if (SelectedScalePattern == -1)
            {
                NumberOfDightWeight = 0;
                var message = HerlperSettings.GetLang().ToastLang.GetLang().SelectePattern;
                ShowMessage(message);
                return;
            }
            if (SelectedScaleType == 0)
            {
                if (SelectedScalePattern is 5 || SelectedScalePattern is 7)
                    max = 6;
                else if (SelectedScalePattern is 6 || SelectedScalePattern is 8)
                    max = 5;
                else
                    max = 4;
            }
            else
            {
                max = 5;
            }

            NumberOfDightWeight = NumberOfDightWeight > max ? max : NumberOfDightWeight;
        }
    }
}
