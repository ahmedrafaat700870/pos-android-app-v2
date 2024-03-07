namespace App.Lang
{
    public partial class PaymentLnag : ObservableObject, IUnitLang<PaymentLnag>
    {
        [ObservableProperty] private string orderAmountLabel;
        [ObservableProperty] private string taxesLabel;
        [ObservableProperty] private string discountLabel;
        [ObservableProperty] private string remaniningLable;
        public PaymentLnag GetLang()
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
            OrderAmountLabel = "Order Amount";
            TaxesLabel = "Taxes";
            DiscountLabel = "Discount";
            RemaniningLable = "Remaining";
        }

        private void AddAr()
        {
            OrderAmountLabel = "مبلغ الطلب";
            TaxesLabel = "الضرائب";
            DiscountLabel = "تخفيض";
            RemaniningLable = "متبقي";
        }
    }
}
