

namespace App.Services.Customer
{
    public class PostNewCustomer : IPostNewCustomer
    {
        private readonly ICreateNewCustomer _services;
        public PostNewCustomer(ICreateNewCustomer services)
        {
            _services = services;
        }

        public PostNewCustomer()
        {
        }

        public async Task<int> PostNewUser(string name, string email, string phone, string vat_number, bool is_client)
        {
            
            var customer = CreateCustomer(name , email , phone , vat_number , is_client);

            if (customer is null)
                return 0;

            try
            {
                await _services.Create(customer);
            } catch (Exception ex)
            {
                return 1;
            }
            return 2;

        }

        private Account_Client_Post_Model CreateCustomer(string name, string email , string phone , string vat_number , bool is_client)
        {
            return new Account_Client_Post_Model()
            {
                avatar = null ,
                address = null ,
                email = email ,
                name = name ,
                phone_number = phone,
                vat_number = vat_number ,
                is_supplier= is_client,
            };
        }
    }
}
