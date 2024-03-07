namespace App.Views.SavedOrder;
public partial class SavedOrderPage : ContentView
{
    private SavedOrderViewModel _vm;
    public SavedOrderPage(SavedOrderViewModel vm) 
    {
        InitializeComponent();
        _vm = vm;
        BindingContext = _vm;
    }
    public void LoadLang() { }
    public async Task LoadData()
    {
        await _vm.LoadData();
    }
}