namespace App.Lang.PaymentPopup
{
    public partial class PaymentPagePopupLang : ObservableObject, IUnitLang<PaymentPagePopupLang>
    {
        [ObservableProperty]
        private string balance;
        [ObservableProperty]
        private string remaining;
        [ObservableProperty]
        private string received;
        [ObservableProperty]
        private string cancle;
        [ObservableProperty]
        private string add;
        public PaymentPagePopupLang GetLang()
        {
            int l = App.appServices.GetAppSettings().LangSelectedIndex;
            if (l == 0)
                AddEn();
            else if (l == 1)
                AddAr();
            return this;
        }
        private void AddEn() 
        {
            Balance = "Balance";
            Remaining = "Remaining";
            Received = "Received";
            Cancle = "Cancel";
            Add = "Add";
        }
        private void AddAr() 
        {
            Balance = "الرصيد";
            Remaining = "المتبقي";
            Received = "تم الاستلام";
            Cancle = "إلغاء";
            Add = "إضافة";
        }
    }
}
