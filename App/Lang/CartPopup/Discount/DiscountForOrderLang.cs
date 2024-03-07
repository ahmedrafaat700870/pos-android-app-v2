namespace App.Lang.CartPopup.Discount
{
    public partial class DiscountForOrderLang : ObservableObject , IUnitLang<DiscountForOrderLang>
    {
        [ObservableProperty]
        private string discountForOrderLabel;
        [ObservableProperty]
        private string singPercentageLabel;
        [ObservableProperty]
        private string singDolarLabel;
        [ObservableProperty]
        private string cancelBtn;
        [ObservableProperty]
        private string addBtn;

        public DiscountForOrderLang GetLang()
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
            DiscountForOrderLabel = "discount for order";
            SingPercentageLabel = "%";
            SingDolarLabel = "$";
            CancelBtn = "Cancel";
            AddBtn = "Add";
        }

        private void AddAr()
        {
            DiscountForOrderLabel = "خصم على السلة";
            SingPercentageLabel = "%";
            SingDolarLabel = "$";
            CancelBtn = "إلغاء";
            AddBtn = "إضافة";
        }
    }
}
