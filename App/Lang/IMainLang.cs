
namespace App.Lang
{
    public interface IMainLang
    {
        IUnitLang<LoginPageLang> LoginPageLang { get; }
        IUnitLang<HomePageLnag> HomePageLnag { get; }
        IUnitLang<ClientPageLang> ClientPageLang { get; }
        IUnitLang<CartPageLang> CartPageLang { get; }

        IUnitLang<PricePopupLang> PricePopupLang { get; }

        IUnitLang<QuantityPopupLang> QuantityPopupLang { get; }
        IUnitLang<DiscountForItemLang> DiscountForItemLang { get; }
        IUnitLang<DiscountForOrderLang> DiscountForOrderLang { get; }

        IUnitLang<DiscountPageLang> DiscountPageLang { get; }
        IUnitLang<PaymentLnag> PaymentLnag { get; }
        IUnitLang<SettingsPageLang> SettingsPageLang { get; }
        IUnitLang<PaymentPagePopupLang> PaymentPagePopupLang { get; }
        IUnitLang<AddNewClientPageLang> AddNewClientPageLang { get; }
        IUnitLang<ItemBoxPageLang> ItemBoxPageLang { get; }
        IUnitLang<SuccesssPageLang> SuccesssPageLang { get; }
        IUnitLang<CameraViewLang> CameraViewLang { get; }

        IUnitLang<SavedOrderPageLang> SavedOrderPageLang { get; }
        IUnitLang<SavedOrderItemLang> SavedOrderItemLang { get; }
        IUnitLang<ToastLang> ToastLang { get; }
    }
}
