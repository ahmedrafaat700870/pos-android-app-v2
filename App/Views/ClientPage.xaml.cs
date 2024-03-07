namespace App.Views;

public partial class ClientPage : ContentView
{
	private readonly ClientPageViewModel _vm;
    
    public ClientPage(ClientPageViewModel vm)
	{
        _vm = vm;
		InitializeComponent();
		BindingContext = _vm;
	}


	public async Task Start()
	{
        await _vm.Start();
    }

    private async void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
		await _vm.SeachForClient();
    }


    private  void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		_vm.AddClientToOrder();
    }
    public void LoadLang()
    {
        _vm.LoadLang();
    }
}