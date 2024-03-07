namespace App.Views.PaymentPopup;

public partial class PaymentPagePopup 
{
	private readonly PaymentPopupPageViewModel _vm;

    public PaymentPagePopup()
	{
		_vm = new PaymentPopupPageViewModel();
		InitializeComponent();
		BindingContext = _vm;
	}

	public void Start(PaymentsPageViewModel paymentPageViewModel , string paymentName , int id , bool isGlobalType)
	{
		_vm.Start(paymentPageViewModel ,  paymentName , id , isGlobalType);
	}

	public void LoadLang()
	{
		_vm.LoadLang();
	}
}