namespace App.Views.CartItems;

public partial class cartItem : ContentView
{
	public cartItem()
	{
		InitializeComponent();
	}

   

    private void Button_Clicked(object sender, EventArgs e)
    {
        this.myGrid.BackgroundColor = new Color(0, 0, 0);
    }

    private void Button_Focused(object sender, FocusEventArgs e)
    {

    }
}