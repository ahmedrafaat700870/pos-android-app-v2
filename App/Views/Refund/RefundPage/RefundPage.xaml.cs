namespace App.ViewModel.Refund.RefundPage;
public partial class RefundPage : ContentView
{
	private readonly RefundPagerViewModel _vm;
    public RefundPage(RefundPagerViewModel vm)
	{
		_vm = vm;
		InitializeComponent();
		BindingContext = _vm;
	}
}