namespace App.Lang
{
    public partial class HomePageLnag : ObservableObject, IUnitLang<HomePageLnag>
    {
        [ObservableProperty] private string seachForProdcut;
        public HomePageLnag GetLang()
        {
            var l = App.appServices.GetAppSettings().LangSelectedIndex;
            if (l == 0)
                AddEn();
            else if(l == 1)
                AddAn();
            return this;
        }

        private void AddEn() { SeachForProdcut = "Search by product name or barcode"; }
        private void AddAn() { SeachForProdcut = "البحث حسب اسم المنتج أو الباركود"; }
    }
}
