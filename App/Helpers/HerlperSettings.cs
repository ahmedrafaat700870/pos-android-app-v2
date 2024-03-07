
namespace App.Helpers
{
    public class HerlperSettings
    {
        private static IMainLang _MainLang;
        public static bool IsDiscountForTotal() => App.appServices.GetAppSettings().DiscountSelectedIndex == 0;

        public static IMainLang GetLang()
        {
            if (_MainLang == null)
                _MainLang = new MainLang(); 
            return _MainLang;
        }
    }
}
