using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTPCLIENT.HttpClientServices.interfaces
{
    public interface IGet
    {
        Task< List<T>> GetAll<T>(string url);
        Task<T> GetByTime_Stamp<T>(string url, string time_stamp);
        Task< List<T>> GetAll<T>(string url, object input);
        Task<T> Get_one<T>(string url);
    }
}
