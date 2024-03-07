namespace App.Views.CartPopup;

public partial class PricePopup 
{
    private CartItemModel _cartItem = null!;

    private Action calcOrderData = null!;

    private PricePopupLang _vm;
    public PricePopup()
	{
		InitializeComponent();
        GetViewModel();
        BindingContext = _vm;
	}
    public void Start(CartItemModel cartItem, Action calcOrderData)
    {
        _cartItem = cartItem;
        this.calcOrderData = calcOrderData;
    }
    private void add_Clicked(object sender, EventArgs e)
    {
        // included or not
        MopupService.Instance.PopAllAsync(true);
        decimal price;
        var success = decimal.TryParse(entry.Text, out price);

        if (success)
        {
            HelperTaxIncluded.AddPriceToOrderItem(price, _cartItem.orderItem);
            _cartItem.Price = _cartItem.orderItem.Total;
            _cartItem.Qty = _cartItem.orderItem.Quantity;
            _cartItem.TotalPrice = _cartItem.Price * _cartItem.Qty;
        }
        calcOrderData.Invoke();
    }

    public void Resset()
    {
        GetViewModel();
        entry.Text = string.Empty;
    }

    private void close_Clicked(object sender, EventArgs e)
    {
        MopupService.Instance.PopAllAsync(true);
    }

    private void GetViewModel()
    {
        var vm = HerlperSettings.GetLang().PricePopupLang.GetLang();
        _vm = vm;
    }
}