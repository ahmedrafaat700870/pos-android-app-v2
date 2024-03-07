namespace App.Services.Login
{
    public class LoginServicesTest : ILoginServices
    {
        private user_model user = new user_model()
        {
            email = "ahmed5@gmail.com", 
            created = DateTime.Now,
            avatar = string.Empty,
            avatar_base64 = null,
            lange = "ar",
            role = string.Empty,
            token = string.Empty,
        };
        public async Task<user_model> Login(string username, string password)
        {
            return await Task.FromResult(this.user);
        }
    }
}
