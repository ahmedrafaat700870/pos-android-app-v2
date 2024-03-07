namespace App.Lang.Settings
{
    public partial class SettingsPageLang : ObservableObject, IUnitLang<SettingsPageLang>
    {

        [ObservableProperty] private string language;
        [ObservableProperty] private string discount;
        [ObservableProperty] private string scaleSettings;
        [ObservableProperty] private string saterCode;
        [ObservableProperty] private string endCode;
        [ObservableProperty] private string scalesType;
        [ObservableProperty] private string scalesPatterns;
        [ObservableProperty] private string numberOfDegitsPrice;
        [ObservableProperty] private string numberOfDegitsWeghit;
        [ObservableProperty] private string cancel;
        [ObservableProperty] private string add;

        [ObservableProperty] private  string[] pattern13;
        [ObservableProperty] private ObservableCollection<string> langs;
        [ObservableProperty] private ObservableCollection<string> taxs;
        [ObservableProperty] private ObservableCollection<string> listScalesType;
        public SettingsPageLang GetLang()
        {
            int lang = App.appServices.GetAppSettings().LangSelectedIndex;
            ListScalesType = ["13", "18"];
            if (lang == 0)
                AddEn();
            else if (lang == 1)
                AddAr();

            return this;
        }
        private void AddEn()
        {
            Language = "Language";
            Discount = "Discount";
            ScaleSettings = "Scale Settings";
            SaterCode = "Starter Code";
            EndCode = "End Code";
            ScalesType = "Scales Type";
            ScalesPatterns = "Scales Patterns";
            NumberOfDegitsPrice = "Number Of Digits Price";
            NumberOfDegitsWeghit = "Number Of Digits Weight";
            Cancel = "Cancel";
            Add = "Add";
            Pattern13 =
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
            Langs = ["en" , "ar"];
            Taxs = ["after tax", "before tax"];
            
        }
        private void AddAr()
        {
            Language = "اللغة";
            Discount = "تخفيض";
            ScaleSettings = "إعدادات الميزان";
            SaterCode = "كود البداية";
            EndCode = "رمز النهاية";
            ScalesType = "نوع الموازين";
            ScalesPatterns = "أنماط الموازين";
            NumberOfDegitsPrice = "عدد الأرقام السعر";
            NumberOfDegitsWeghit = "عدد أرقام الوزن";
            Cancel = "إلغاء";
            Add = "إضافة";

            Pattern13 =
            [
               "1-5-6-1 سعر",
                "1-6-5-1 سعر",
                "2-4-6-1 سعر",
                "2-5-5-1 سعر",
                "2-6-4-1 سعر",
                "1-5-6-1 وزن",
                "1-6-5-1 وزن",
                "2-4-6-1 وزن",
                "2-5-5-1 وزن",
                "2-6-4-1 وزن"
           ];
            Langs = ["انجليزى", "عربى"];
            Taxs = ["بعد الضريبة", "قبل الضريبة"];

        }

    }
}
