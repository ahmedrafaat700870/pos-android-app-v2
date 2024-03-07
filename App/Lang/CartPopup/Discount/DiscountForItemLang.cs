namespace App.Lang.CartPopup.Discount
{
    public partial class DiscountForItemLang : ObservableObject, IUnitLang<DiscountForItemLang>
    {
        [ObservableProperty]
        private string discountForItemLabel;
        [ObservableProperty]

        private string singPercentageLabel;
        [ObservableProperty]

        private string singDolarLabel;
        [ObservableProperty]

        private string cancelBtn;
        [ObservableProperty]

        private string addBtn;



        public DiscountForItemLang GetLang()
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
            DiscountForItemLabel = "discount for item";
            SingPercentageLabel = "%";
            SingDolarLabel = "$";
            CancelBtn = "Cancel";
            AddBtn = "Add";
        }

        private void AddAr()
        {
            DiscountForItemLabel = "خصم على عنصر";
            SingPercentageLabel = "%";
            SingDolarLabel = "$";
            CancelBtn = "إلغاء";
            AddBtn = "إضافة";
        }
    }
}
