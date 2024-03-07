namespace App.Views.CartPopup.Discount;

public partial class DiscountForItem : ContentView
{
	public DiscountForItem(CartItemModel cartItem , Action calcOrder = null!)
	{
		InitializeComponent();
        var vm = new DiscountForItemViewModel(cartItem, calcOrder);
        vm.Resources = this.Resources;
        vm.SetStyle();
        BindingContext = vm;
    }
}