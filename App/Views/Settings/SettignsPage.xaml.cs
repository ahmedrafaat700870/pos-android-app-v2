namespace App.Views.Settings;

public partial class SettignsPage : ContentView
{
	private readonly SettingsPageViewModel _vm;
	public SettignsPage(SettingsPageViewModel vm)
	{
		_vm = vm;
		InitializeComponent();
		BindingContext = _vm;
	}

	public void LoadData()
	{
		_vm.LoadData();
	}


    public void LoadLang()
    {
        _vm.LoadLang();
    }

    private void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
		_vm.SelectedScaleTypeChanged();
    }

    private void pattern_SelectedIndexChanged(object sender, EventArgs e)
    {
		_vm.SelectedPatternChanged();
    }

    private void starterCodeEntery_TextChanged(object sender, TextChangedEventArgs e)
    {
		_vm.StarterCodeChanged();
    }

    private void dightOfPrice_TextChanged(object sender, TextChangedEventArgs e)
    {
        _vm.ValidateDightOfPrice();
    }

    private void dightOfWeight_TextChanged(object sender, TextChangedEventArgs e)
    {
        _vm.ValidateDightOfWeight();
    }

    private void Picker_SelectedIndexChanged_1(object sender, EventArgs e)
    {
        _vm.ChangePrinter();
    }
}