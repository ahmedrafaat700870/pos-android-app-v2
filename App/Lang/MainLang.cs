

namespace App.Lang
{
    public class MainLang : IMainLang
    {
        public MainLang()
        {
            LoginPageLang = new LoginPageLang();
            ClientPageLang = new ClientPageLang();
            HomePageLnag = new HomePageLnag();
            CartPageLang = new CartPageLang();
            PricePopupLang = new PricePopupLang();
            QuantityPopupLang = new QuantityPopupLang();
            DiscountForItemLang = new DiscountForItemLang();
            DiscountForOrderLang = new DiscountForOrderLang();
            DiscountPageLang = new DiscountPageLang();
            PaymentLnag = new PaymentLnag();
            SettingsPageLang = new SettingsPageLang();
            PaymentPagePopupLang = new PaymentPagePopupLang();  
            AddNewClientPageLang = new AddNewClientPageLang();
            ItemBoxPageLang = new ItemBoxPageLang();
            SuccesssPageLang = new SuccesssPageLang();
            CameraViewLang = new CameraViewLang();
            SavedOrderPageLang = new SavedOrderPageLang();
            SavedOrderItemLang = new SavedOrderItemLang();
            ToastLang = new ToastLang();
        }

        public IUnitLang<LoginPageLang> LoginPageLang { get; }
        public IUnitLang<HomePageLnag> HomePageLnag { get; }
        public IUnitLang<ClientPageLang> ClientPageLang { get; }
        public IUnitLang<CartPageLang> CartPageLang { get; }
        public IUnitLang<PricePopupLang> PricePopupLang { get; }
        public IUnitLang<QuantityPopupLang> QuantityPopupLang { get; }
        public IUnitLang<DiscountForItemLang> DiscountForItemLang { get; }
        public IUnitLang<DiscountForOrderLang> DiscountForOrderLang { get; }
        public IUnitLang<DiscountPageLang> DiscountPageLang { get; }
        public IUnitLang<PaymentLnag> PaymentLnag { get; }
        public IUnitLang<SettingsPageLang> SettingsPageLang { get; }
        public IUnitLang<PaymentPagePopupLang> PaymentPagePopupLang { get; }

        public IUnitLang<AddNewClientPageLang> AddNewClientPageLang { get; }
        public IUnitLang<ItemBoxPageLang> ItemBoxPageLang { get; }

        public IUnitLang<SuccesssPageLang> SuccesssPageLang { get; }

        public IUnitLang<CameraViewLang> CameraViewLang { get; }

        public IUnitLang<SavedOrderPageLang> SavedOrderPageLang { get; }
        public IUnitLang<SavedOrderItemLang> SavedOrderItemLang { get; }

        public IUnitLang<ToastLang> ToastLang { get; }


    }



}
