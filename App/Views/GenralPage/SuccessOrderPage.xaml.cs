namespace App.Views.GenralPage;
public partial class SuccessOrderPage : ContentView
{
    private SuccesssPageLang vmLang;
	public SuccessOrderPage()
	{
		InitializeComponent();
        LoadLang();
        BindingContext = vmLang;
    }

    private void LoadLang()
    {
        vmLang = HerlperSettings.GetLang().SuccesssPageLang.GetLang();
    }

    public async void load()
    {
        //base.OnAppearing();
        vmLang.GetLang();
        img.ScaleTo(1.5);
        msg.ScaleTo(1);

        await img.ScaleTo(0.5);
        await img.ScaleTo(1.5);
        await img.ScaleTo(0.5);
        await img.ScaleTo(1.5);
        await img.ScaleTo(0.5);
        await img.ScaleTo(1.5);
        await img.ScaleTo(1);

        homebtn.FadeTo(1, length: 200);
        await homebtn.ScaleTo(1);
        //homebtn_Clicked(null , null);
    }

    private void homebtn_Clicked(object sender, EventArgs e)
    {
        App.helperNavigation.NavigateToHome();
    }
}