namespace App.Lang.CartPopup
{
    public partial class PricePopupLang : ObservableObject, IUnitLang<PricePopupLang>
    {
        [ObservableProperty]
        private string todaysEnteryPriceLable;
        [ObservableProperty]
        private string entryPriceLable;
        [ObservableProperty]
        private string cancelBtn;
        [ObservableProperty]
        private string addBtn;

        public PricePopupLang GetLang()
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
            TodaysEnteryPriceLable = "Today’s entry price";
            EntryPriceLable = "Entry price";
            CancelBtn = "Cancel";
            AddBtn = "Add";
        }
        private void AddAr()
        {
            TodaysEnteryPriceLable = "سعر الدخول اليوم";
            EntryPriceLable = "سعر الدخول";
            CancelBtn = "إلغاء";
            AddBtn = "إضافة";
        }
    }
}
