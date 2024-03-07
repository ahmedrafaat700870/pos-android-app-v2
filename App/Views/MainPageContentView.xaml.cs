namespace App.Views;
public partial class MainPageContentView : ContentPage
{
    private MainPageContentViewViewModel _vm;
    public MainPageContentView(MainPageContentViewViewModel vm)
    {
        _vm = vm;
        BindingContext = _vm;
        InitializeComponent();
    }

    public async void addData()
    {
        App.SetMainPageConventView(_vm);
    }

    public async Task LoadDataHome()
    {
        await _vm.LoadDataHomeViewModel();
    }

    
    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        await Shell.Current.Navigation.PopAsync();
    }
}