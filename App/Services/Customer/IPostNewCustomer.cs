using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.Customer
{
    public interface IPostNewCustomer
    {
        Task<int> PostNewUser(string name, string email, string phone, string vat_number, bool is_client);
    }
}
