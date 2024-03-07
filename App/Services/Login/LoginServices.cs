namespace App.Services.Login
{
    public class LoginServices : ILoginServices
    {
        private readonly ICRUDHttpServices CRUDHttpServices;

        private readonly HttpClient _httpClient;
        public LoginServices(ICRUDHttpServices CRUDHttpServices , HttpClient client)
        {
            this.CRUDHttpServices = CRUDHttpServices;
            _httpClient = client;
        }

        public async Task<user_model> Login(string username, string password)
        {
            login user = new login() { username = username, password = password };
            user_model resulat = null!;
            try
            {
                resulat = await CRUDHttpServices.PostOne<user_model>(URLS.login_url, user);
            } catch (Exception ex   )
            {
                resulat = null!;
            }
            return resulat;
        }


    }
}
