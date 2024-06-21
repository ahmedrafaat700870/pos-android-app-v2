#if ANDROID
using XamarinESCUtils.Platforms.Android;
#endif
using XamarinESCUtils.Platforms.Common;

namespace App
{
    public partial class App : Application
    {
        public static AppServices appServices = new AppServices();
        public static InventoryOrder order = new InventoryOrder();
        public static HelperNavigation helperNavigation;
        public static PostOrderToAPI postOrder;
        public static ScalesHelper scalesHelper;
        public static HelperPromo helperPromo;
        private static MainPageContentViewViewModel mainPageViewModel;
        private static Calc_Order_item_Detalis CalcOrderItem;
        private static ReadAndWriteFile fileHelper;
        private static IBlueToothService _blueToothService;
        private static IEscUtil _escUtil;

        public static IBlueToothService GetBlueToothService()
        {
            if (_blueToothService is null)
            {
#if ANDROID
                _blueToothService = new BluetoothService();
#endif
            }
            return _blueToothService; 
        }

        public static IEscUtil GetEscUtil()
        {
            if(_escUtil is null)
            {
#if ANDROID
                _escUtil = new EscUtil();
#endif
            }
            return _escUtil;
        }


        public static DataUserRemeberMe DataUserRemeberMe;

        public static void GetDataPriveUser()
        {
            DataUserRemeberMe = new DataUserRemeberMe();
            DataUserRemeberMe.GetRememerMeData();
        }

        public static Calc_Order_item_Detalis GetCaclOrderItem()
        {
            if(CalcOrderItem is null)
            {
                CalcOrderItem = new Calc_Order_item_Detalis();
                CalcOrderItem.Set_Order(App.order);
            }
            CalcOrderItem.Set_Order(App.order);
            return CalcOrderItem;
        }

        public App(HttpClient client, ICRUDHttpServices curdservices , IPostOrder dataPost )
        {
            InitializeComponent();
            helperPromo = new HelperPromo();
            scalesHelper = new ScalesHelper();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            curdservices = new CRUDHttpServices(client);
            MainPage = new AppShell();
            postOrder = new PostOrderToAPI(dataPost);
            Current.UserAppTheme = AppTheme.Light;
            GetDataPriveUser();
        }

        public static void SetMainPageConventView(MainPageContentViewViewModel _mainPageViewModel)
        {
            mainPageViewModel = _mainPageViewModel;
            helperNavigation = new HelperNavigation(_mainPageViewModel);
        }

        public static MainPageContentViewViewModel GetMainPage()
        {
            return mainPageViewModel;
        }

        public static ReadAndWriteFile GetReadAndWriteFile()
        {
            if (fileHelper is null)
                fileHelper = new ReadAndWriteFile();
            return fileHelper;
        }
    }
}
