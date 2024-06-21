

namespace App.Services.CreatNewCustomer
{
    public interface ICreateNewCustomer
    {
        Task Create(Account_Client_Post_Model model);
    }
}
