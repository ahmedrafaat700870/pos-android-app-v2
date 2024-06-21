namespace App.Views;

public partial class HomePage : ContentView
{
    public readonly HomePageViewModel _vm;

    public HomePage(HomePageViewModel vm)
    {
        _vm = vm;
        InitializeComponent();
        BindingContext = _vm;
        _vm.AddDispatcher(Dispatcher);
        _vm.SetLable(countItem);
    }


    public async Task LoadData()
    {
        // loading data here .
        await _vm.GetDataProducts();
    }

    public void LoadDefalut()
    {
        MainThread.InvokeOnMainThreadAsync( () =>
        {
             _vm.LoadDataGroup(null);
        });
    }

    private  void seachBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        _vm.ChangeSeachBar();
    }

   

    public void LoadLang()
    {
        _vm.LoadLnag();
    }


    
}