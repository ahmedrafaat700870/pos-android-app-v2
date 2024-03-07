
namespace App.Lang.ItemBox
{
    public partial class ItemBoxPageLang : ObservableObject, IUnitLang<ItemBoxPageLang>
    {
        [ObservableProperty] private string itemBoxPageLabel;
        [ObservableProperty] private string addBtn;
        public ItemBoxPageLang GetLang()
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
            ItemBoxPageLabel = "Item Box Page";
            AddBtn = "Add";
        }
        private void AddAr()
        {
            ItemBoxPageLabel = "صفحة صندوق العناصر";
            AddBtn = "إضافة";
        }


    }
}
