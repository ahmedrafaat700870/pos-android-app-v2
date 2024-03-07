namespace App.Views.CartPopup;

public partial class QuantityPopup : PopupPage
{
    private CartItemModel _cartItem = null!;

    private Action calcOrderData = null!;
    private CartViewModel cartViewModel;

    private QuantityPopupLang _vm;
    public QuantityPopup()
	{
        InitializeComponent();
        GetViewModel();
        BindingContext = _vm;
    }
    public void Start(CartItemModel cartItem, Action calcOrderData , CartViewModel cartViewModel)
    {
        _cartItem = cartItem;
        this.cartViewModel = cartViewModel;
        this.calcOrderData = calcOrderData;
    }
    private void close_Clicked(object sender, EventArgs e)
    {
        MopupService.Instance.PopAllAsync(true);
    }

    private void add_Clicked(object sender, EventArgs e)
    {
        MopupService.Instance.PopAllAsync(true);
        decimal qty;
        var success = decimal.TryParse(entry.Text , out qty);
        if(success)
            _cartItem.ChangeQty(qty , cartViewModel.LoadData);
        calcOrderData.Invoke();
    }

    public void Resset()
    {
        GetViewModel();
        this.entry.Text = string.Empty;
    }

    private void GetViewModel()
    {
        var vm = HerlperSettings.GetLang().QuantityPopupLang.GetLang();
        _vm = vm;
    }
}