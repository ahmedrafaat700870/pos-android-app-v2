using App.ViewModel.ItemBox;

namespace App.Views.ItemBox;

public partial class ItemBoxPasge : ContentView
{
	private ItemBoxViewModel _vm;
	public ItemBoxPasge(ItemBoxViewModel vm)
	{
		InitializeComponent();
		_vm = vm;
		_vm.Loading();
        _vm.LoadLang();
        this.BindingContext = _vm;
	}

	public void LoadLang()
	{
		_vm.LoadLang();
	}
}