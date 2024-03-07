
namespace App.Lang.SavedOrder
{
    public partial class SavedOrderPageLang : ObservableObject, IUnitLang<SavedOrderPageLang>
    {
        [ObservableProperty] private string header;
        
        public SavedOrderPageLang GetLang()
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
            Header = "Saved order page";
        }
        private void AddAr() 
        {
            Header = "صفحة المحفوظة";
        }
    }
}
