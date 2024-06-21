namespace App.Views;

public partial class HomePageV2 : ContentView
{
	private HomePageViewModel _vm;
	public HomePageV2(HomePageViewModel vm)
	{
		_vm = vm;	
		InitializeComponent();
		this.BindingContext = _vm;
	}

	public async Task LoadData()
	{
		await _vm.GetDataProducts();
	}
    private void seachBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        _vm.ChangeSeachBar();
    }

    public void LoadLang()
    {
        _vm.LoadLnag();
    }

}