namespace App.Views.Refund;
public partial class Refund_OrderView : BaseRefundView
{
    private readonly Refund_OrderViewModel _vm;
	public Refund_OrderView(Refund_OrderViewModel vm)
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