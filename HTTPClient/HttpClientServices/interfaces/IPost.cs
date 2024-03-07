using HTTPCLIENT.request_bodys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTPCLIENT.HttpClientServices.interfaces
{
    public interface IPost
    {
         Task PostAll<T>(string url, List<T> input);

         Task<T> PostOne<T>(string url, login input);
      
    }
}
