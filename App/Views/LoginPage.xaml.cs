namespace App.Views;
public partial class LoginPage : ContentPage
{
    private readonly LoginPageViewModel _loginPage;
    public LoginPage(LoginPageViewModel loginPage)
    {
        InitializeComponent();

        _loginPage = loginPage;
        _loginPage.SetActions(this.InternetNotConnected, this.UsernameOrPasswordIncorrect);
        BindingContext = _loginPage;
        this._loginPage.SetLoginPage(this);
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        _loginPage.LoginCommand.Execute(nameof(sender));
    }

    private async void InternetNotConnected()
    {
        await DisplayAlert("Alert", "please check from internet connection and try again", "OK");
    }


    private async void UsernameOrPasswordIncorrect()
    {
        await DisplayAlert("Alert", "user name or password is incorrect.", "OK");
    }

}