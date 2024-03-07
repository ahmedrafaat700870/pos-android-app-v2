namespace App.Lang
{
    public partial class CartPageLang : ObservableObject, IUnitLang<CartPageLang>
    {
        [ObservableProperty]
        private string qtyBtn;
        [ObservableProperty]

        private string priceBtn;
        [ObservableProperty]

        private string clearBtn;
        [ObservableProperty]

        private string discountBtn;
        [ObservableProperty]

        private string productNameLabel;
        [ObservableProperty]

        private string unitPriceLable;
        [ObservableProperty]

        private string quantityLable;
        [ObservableProperty]

        private string totalPriceLable;

        [ObservableProperty]

        private string itemDiscountLable;


        [ObservableProperty]

        private string subtTotalLable;
        [ObservableProperty]

        private string taxLable;
        [ObservableProperty]

        private string discountLable;
        [ObservableProperty]

        private string totalAmountLabel;


        [ObservableProperty]
        private string cashBtn;
        [ObservableProperty]
        private string cridtBtn;
        [ObservableProperty] 
        private string paymentBtn;


        [ObservableProperty]
        private string totalOrderLabel;

        public CartPageLang GetLang()
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
            QtyBtn = "Qty" ;
            PriceBtn = "Price";
            ClearBtn = "Clear";
            DiscountBtn = "Discount";
            ProductNameLabel = "Product name";
            UnitPriceLable = "Unit price";
            QuantityLable = "Qty";
            TotalPriceLable = "Total price";
            ItemDiscountLable = "discount";
            SubtTotalLable = "SubTotal";
            TaxLable = "Tax";
            DiscountLable = "Discount";
            TotalAmountLabel = "TotalAmount";
            CashBtn = "Cash";
            CridtBtn = "Cridt";
            PaymentBtn = "Payments";
            TotalOrderLabel = "Total Order";

        }
        private void AddAr() 
        {
            QtyBtn = "كية";
            PriceBtn = "سعر";
            ClearBtn = "مسح";
            DiscountBtn = "تخفيض";
            ProductNameLabel = "اسم المنتج";
            UnitPriceLable = "سعر الوحدة";
            QuantityLable = "كية";
            TotalPriceLable = "السعر الكلي";
            ItemDiscountLable = "تخفيض";
            SubtTotalLable = "الإجمالي الفرعي";
            TaxLable = "ضريبة";
            DiscountLable = "تخفيض";
            TotalAmountLabel = "المبلغ الإجمالي";
            CashBtn = "نقدي";
            CridtBtn = "ائتمان";
            PaymentBtn = "المدفوعات";
            TotalOrderLabel = "اجمالى السلة";
        }
    }
}
