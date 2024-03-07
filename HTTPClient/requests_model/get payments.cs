using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HTTPCLIENT.models;

namespace HTTPCLIENT.requests_model
{
    public class get_payments
    {
        public List<global_type> global_types = new List<global_type>();
        public List<payment_type> payment_types = new List<payment_type>();
    }
}
