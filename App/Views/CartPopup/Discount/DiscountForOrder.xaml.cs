namespace App.Views.CartPopup.Discount;

public partial class DiscountForOrder : ContentView
{
	
	public DiscountForOrder(Action _calcOrder = null!)
	{
		InitializeComponent();
		var vm = new DiscountForIOrderViewModel(_calcOrder);
		vm.Resorces = this.Resources;
		vm.SetStyles();
		this.BindingContext = vm;
    }
}