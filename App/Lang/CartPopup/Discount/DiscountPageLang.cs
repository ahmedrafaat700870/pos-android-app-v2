namespace App.Lang.CartPopup.Discount
{
    public partial class DiscountPageLang : ObservableObject, IUnitLang<DiscountPageLang>
    {
        [ObservableProperty]
        private string order;
        [ObservableProperty]
        private string item;
        public DiscountPageLang GetLang()
        {
            var lang = App.appServices.GetAppSettings().LangSelectedIndex;
            if(lang == 0)
            {
                AddEn();
            } else if(lang == 1)
            {
                AddAr();
            }
            return this;
        }

        private void AddEn()
        {
            Order = "order";
            Item = "item";
        }

        private void AddAr()
        {
            Order = "سلة";
            Item = "عنصر";
        }
    }
}
