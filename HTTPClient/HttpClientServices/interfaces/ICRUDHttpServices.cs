using HTTPCLIENT.request_bodys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTPCLIENT.HttpClientServices.interfaces
{
    public interface ICRUDHttpServices : IGet, IPost
    {
        bool add_token(string token);

    }
}
