namespace App.Lang.GenralPage
{
    public partial class SuccesssPageLang : ObservableObject, IUnitLang<SuccesssPageLang>
    {
        [ObservableProperty] private string msgLable;
        [ObservableProperty] private string goToHomeBtn;
        public SuccesssPageLang GetLang()
        {
            int lang = App.appServices.GetAppSettings().LangSelectedIndex;
            if (lang == 0)
                AddEn();
            else if (lang == 1)
                AddAr();
            return this;
        }

        private void AddEn()
        {
            MsgLable = "Order Placed Success";
            GoToHomeBtn = "Go To Home";
        }

        private void AddAr()
        {
            MsgLable = "تم وضع الطلب بنجاح";
            GoToHomeBtn = "اذهب إلى الصفحة الرئيسية";

        }
    }
}
