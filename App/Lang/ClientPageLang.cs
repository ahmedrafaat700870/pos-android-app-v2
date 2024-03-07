
namespace App.Lang
{
    public partial class ClientPageLang : ObservableObject, IUnitLang<ClientPageLang>
    {
        [ObservableProperty] private string client;
        [ObservableProperty] private string cancelBtn;
        [ObservableProperty] private string addBtn;
        public ClientPageLang GetLang()
        {
            var Lang = App.appServices.GetAppSettings().LangSelectedIndex;
            if (Lang is 0)
            {
                AddEn();
            }
            else if (Lang is 1)
            {
                AddAr();
            }
            return this;
        }
        private void AddEn()
        {
            Client = "Client";
            CancelBtn = "Cancel";
            AddBtn = "Add";
        }
        private void AddAr()
        {
            Client = "عميل";
            CancelBtn = "إلغاء";
            AddBtn = "إضافة";
        }

      
    }
}
