using HTTPCLIENT.models.branch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTPCLIENT.requests_model
{
    public class get_init_company
    {
        public company company { get; set; } = null;
        public branch branch { get; set; } = null;
        public stock stock { get; set; } = null;
    }
}
