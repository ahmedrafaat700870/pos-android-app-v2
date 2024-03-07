namespace App.Views;

public partial class HomePage : ContentView
{
    private readonly HomePageViewModel _vm;

    public HomePage(HomePageViewModel vm)
    {
        _vm = vm;
        InitializeComponent();
        BindingContext = _vm;
        _vm.SetLable(countItem);
    }


    public async Task LoadData()
    {
        // loading data here .
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


    private async void ScrollView_OnScrolled(object? sender, ScrolledEventArgs e)
    {
        if (!(sender is ScrollView scrollView)) return;

        var scrollSpace = scrollView.ContentSize.Height - scrollView.Height;

        if ((scrollSpace - 10) > e.ScrollY)
            await _vm.ShowItemsHeader();
        else // load more items when coming to the end of the list of ScrollView 
            await _vm.ShowButtonUpdate();
    }
}