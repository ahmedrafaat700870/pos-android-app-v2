
namespace App.Views.Refund.OrderPage;

public partial class OrderPage : ContentView
{
	private readonly OrderPageViewModel _vm;


	public OrderPage(OrderPageViewModel vm)
	{
		_vm = vm;
		InitializeComponent();
		BindingContext = _vm;
	}

}