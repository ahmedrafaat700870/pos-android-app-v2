namespace App.Views.Refund;
public partial class RefundPage : ContentView
{
	private readonly BaseRefundViewModel _vm;
	public RefundPage(BaseRefundViewModel _vm)
	{
		this._vm = _vm;
		InitializeComponent();
		BindingContext = this._vm;
	}


	public void LoadData()
	{

	}
}