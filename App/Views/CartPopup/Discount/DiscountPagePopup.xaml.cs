namespace App.Views.CartPopup.Discount;

public partial class DiscountPagePopup 
{
	private  async void AlertMessage()
	{
        await DisplayAlert("Alert", "please selecte item", "OK");
    }


    public DiscountPagePopup(CartItemModel seleectedItem  = null , Action clacOrder = null!)
	{
        InitializeComponent();
        var vm = new DiscountPageViewModel(seleectedItem , this.Resources, clacOrder);
		vm.SertAlertSelectedItem(this.AlertMessage);
        BindingContext = vm;
	}


	
}