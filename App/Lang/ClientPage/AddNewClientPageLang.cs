namespace App.Lang.ClientPage
{
    public partial class AddNewClientPageLang : ObservableObject, IUnitLang<AddNewClientPageLang>
    {

        [ObservableProperty] private string addNewClientAndSuplier;
        [ObservableProperty] private string nameEntry;
        [ObservableProperty] private string phoneEntrty;
        [ObservableProperty] private string emailEntry;
        [ObservableProperty] private string vatRegestrationNumberEntry;
        [ObservableProperty] private string idNumberEntry;
        [ObservableProperty] private string client;
        [ObservableProperty] private string cancelBtn;
        [ObservableProperty] private string addBtn;

        public AddNewClientPageLang GetLang()
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
            AddNewClientAndSuplier = "Add new client or supplier";
            NameEntry = "name";
            PhoneEntrty = "phone";
            EmailEntry = "email";
            VatRegestrationNumberEntry = "vat registrations number";
            IdNumberEntry = "Id Number";
            Client = "Client";
            CancelBtn = "Cancel";
            AddBtn = "Add";
        }

        private void AddAr()
        {
            AddNewClientAndSuplier = "إضافة عميل أو مورد جديد";
            NameEntry = "اسم";
            PhoneEntrty = "رقم الهاتف";
            EmailEntry = "البريد الالكترونى";
            VatRegestrationNumberEntry = "رقم تسجيل ضريبة القيمة المضافة";
            IdNumberEntry = "رقم الهوية";
            Client = "عميل";
            CancelBtn = "إلغاء";
            AddBtn = "إضافة";
        }
    }
}
