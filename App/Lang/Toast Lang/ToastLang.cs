namespace App.Lang.Toast_Lang
{
    public partial class ToastLang : ObservableObject, IUnitLang<ToastLang>
    {
        [ObservableProperty] private string remaining;
        [ObservableProperty] private string postOrderfalid;
        [ObservableProperty] private string addItemInOrder;
        [ObservableProperty] private string savedOrderSuccessfuly;
        [ObservableProperty] private string noOrdersSaved;
        // settings page 
        [ObservableProperty] private string selectePattern;
        [ObservableProperty] private string successAddsettings;
        [ObservableProperty] private string settings;
        [ObservableProperty] private string starterCodeCanNotbezero;
        // client page 
        [ObservableProperty] private string addNewClientSuccesfuly;
        [ObservableProperty] private string falidAddingNewclient;
        [ObservableProperty] private string falidAddingNewClientInData;
        // saved order item
        [ObservableProperty] private string success;
        [ObservableProperty] private string falid;
        public ToastLang GetLang()
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
            PostOrderfalid = "post order failed";
            AddItemInOrder = "please add item to order";
            SavedOrderSuccessfuly = "Saved Order Successfully";
            NoOrdersSaved = "No Orders Saved";

            SelectePattern = "please Select Pattern";
            SuccessAddsettings = "Settings";
            Settings = "success add settings";
            StarterCodeCanNotbezero = "starter code can't be zero or less";

            AddNewClientSuccesfuly = "add new client successfully";
            FalidAddingNewclient = "server error";
            FalidAddingNewClientInData = "data not valid ";

            Remaining = " remaining ";
            Success = "success";
            Falid = "falid";
        }

        private void AddAr()
        {
            PostOrderfalid = "فشل الطلب اللاحق";
            AddItemInOrder = "يرجى إضافة عنصر للطلب";
            SavedOrderSuccessfuly = "تم حفظ الطلب بنجاح";
            NoOrdersSaved = "لم يتم حفظ أي طلبات";

            SelectePattern = "الرجاء تحديد النمط";
            SuccessAddsettings = "إعدادات";
            Settings = "تمت إضافة الإعدادات بنجاح";
            StarterCodeCanNotbezero = "لا يمكن أن يكون رمز البدء صفرًا أو أقل";
            AddNewClientSuccesfuly = "إضافة عميل جديد بنجاح";
            FalidAddingNewclient = "خطأ في الخادم";
            FalidAddingNewClientInData = "البيانات غير صالحة";
            Remaining = " متبقي ";

            Success = "نجاح";
            Falid = "فشل";
        }
    }
}
