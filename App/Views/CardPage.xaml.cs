namespace App.Views;
public partial class CardPage : ContentView
{
	private readonly CartViewModel _vm;
    private PricePopup pricePopup;
    private QuantityPopup quantityPopup;
    private DiscountPagePopup discountPopup = null!;
    public CardPage(CartViewModel vm)
    {
        _vm = vm;
        InitializeComponent();
        this.BindingContext = _vm;
        this.pricePopup = new PricePopup();
        this.quantityPopup =  new QuantityPopup();
    }

    public void LoadDataVM()
	{
        _vm.LoadData();
    }

    private async void qty_Clicked(object sender, EventArgs e)
    {
        if (_vm.checkFromSelectedItem())
        {
            quantityPopup.Resset();
            quantityPopup.Start(_vm.selectItem , _vm.CalcOrder , _vm);
            await MopupService.Instance.PushAsync(quantityPopup, true);
        }
    }

    private async void price_Clicked(object sender, EventArgs e)
    {
        if (_vm.checkFromSelectedItem())
        {
            pricePopup.Resset();
            pricePopup.Start(_vm.selectItem, _vm.CalcOrder);
            await MopupService.Instance.PushAsync(pricePopup, true);
        }
    }

    private async void discount_Clicked(object sender, EventArgs e)
    {
        await MopupService.Instance.PushAsync(new DiscountPagePopup(_vm.selectItem , _vm.CalcOrder), true);
    }

    public void LoadLang()
    {
        _vm.LoadLang();
    }
}