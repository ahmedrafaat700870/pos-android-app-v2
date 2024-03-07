namespace App.Views;

public partial class PaymentsPage : ContentView
{
	private readonly PaymentsPageViewModel vm;

    public PaymentsPage(PaymentsPageViewModel vm)
	{
		this.vm = vm;
		InitializeComponent();
		BindingContext = vm;
	}

	public void Start()
	{
		vm.Start();
	}

	public void LoadLang() 
	{
		vm.LoadLang();
	}
}