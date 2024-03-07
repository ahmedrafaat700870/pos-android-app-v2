namespace App.Lang.SavedOrder
{
    public partial class SavedOrderItemLang : ObservableObject, IUnitLang<SavedOrderItemLang>
    {
        [ObservableProperty] private string owner;
        [ObservableProperty] private string addBtn;
        [ObservableProperty] private string cancleBtn;
        public List<string> From = new List<string>();
        public SavedOrderItemLang GetLang()
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
            Owner = "Owner";
            AddBtn = " Add ";
            CancleBtn = "Remove";
            From.Clear();
            From.Add("days");
            From.Add("hours");
            From.Add("minutes");
            From.Add("seoncds");
        }

        private void AddAr()
        {
            Owner = "المالك";
            AddBtn = "إضافة";
            CancleBtn = " حذف ";
            From.Clear();
            From.Add("يوم");
            From.Add("ساعة");
            From.Add("دقيقة");
            From.Add("ثانية");
        }
    }
}
