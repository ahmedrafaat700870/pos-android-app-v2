namespace App.Views.ClientPages;

public partial class AddNewClientPage : ContentView
{
	private readonly AddNewClientPageViewModel _vm;

    public AddNewClientPage(AddNewClientPageViewModel vm)
	{
		_vm = vm;
		InitializeComponent();
		_vm.SetResourecs(this.Resources);
        _vm.SetStyles();
		_vm.LoadLang();
		BindingContext = _vm;
	}

    private void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
		if (_vm is null) return;
        int id = GetEntryId(sender);
		_vm.checkFromData(id);
    }

    private void Entry_Focused(object sender, FocusEventArgs e)
    {
        if (_vm is null) return;
        int id = GetEntryId(sender);
		_vm.DefualtStyles();
		_vm.CheckFromStyleAndSetActive(id);
	}


	private int GetEntryId(object sender)
	{
        var _sender = sender as Entry;

        int id = Convert.ToInt32(_sender.AutomationId);

		return id;
    }
	public void LoadLang()
	{
		_vm.LoadLang();
    }
}