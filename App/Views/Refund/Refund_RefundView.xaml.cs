namespace App.Views.Refund;
public partial class Refund_RefundView : BaseRefundView
{
	private readonly Refund_RefundViewModel _vm;
	public Refund_RefundView(Refund_RefundViewModel vm)
	{
		_vm = vm;
		InitializeComponent();
		BindingContext = _vm;
	}
    public override void LoadData()
    {
		_vm.LoadData();
		_vm.LoadLang();
    }
}