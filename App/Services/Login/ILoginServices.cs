

namespace App.Services.Login
{
    public interface ILoginServices
    {
        Task<user_model> Login(string username , string password);

    }
}
