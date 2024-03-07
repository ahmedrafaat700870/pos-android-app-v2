
namespace App.Lang.CameraPage
{
    public partial class CameraViewLang : ObservableObject, IUnitLang<CameraViewLang>
    {
        [ObservableProperty] private string cam1Btn;
        [ObservableProperty] private string cam2Btn;
        [ObservableProperty] private string closeBtn;
        public CameraViewLang GetLang()
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
            Cam1Btn = "Cam1";
            Cam2Btn = "Cam2";
            CloseBtn = "Close";
        }

        private void AddAr()
        {
            Cam1Btn = "الكاميرا الخلفية";
            Cam2Btn = "الكاميرا الامامية";
            CloseBtn = "إغلاق";
        }
    }
}
