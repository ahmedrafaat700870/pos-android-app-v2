namespace App.Lang.CartPopup
{
    public partial class QuantityPopupLang : ObservableObject , IUnitLang<QuantityPopupLang>
    {
        [ObservableProperty]
        private string todaysEnteryQuantityLable;
        [ObservableProperty]
        private string entryQuantityLable;
        [ObservableProperty]
        private string cancelBtn;
        [ObservableProperty]
        private string addBtn;

        public QuantityPopupLang GetLang()
        {
            var lang = App.appServices.GetAppSettings().LangSelectedIndex;
            if (lang == 0)
                AddEn();
            else if (lang == 1)
                AddAr();

            return this;
        }


        private void AddEn()
        {
            TodaysEnteryQuantityLable = "Today’s entry price";
            EntryQuantityLable = "Entry price";
            CancelBtn = "Cancel";
            AddBtn = "Add";
        }
        private void AddAr()
        {
            TodaysEnteryQuantityLable = "سعر الدخول اليوم";
            EntryQuantityLable = "سعر الدخول";
            CancelBtn = "إلغاء";
            AddBtn = "إضافة";
        }
    }
}
