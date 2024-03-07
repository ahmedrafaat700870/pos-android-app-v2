
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTPCLIENT.models.branch
{
    

    public class company
    {
        public int company_Id { get; set; }
        public int id { get; set; }
        /*public object owners { get; set; } = null;*/
        public string logo { get; set; } = null;
        public string name { get; set; } = null;
        public string vat_reg_number { get; set; } = null;
        public string phone { get; set; } = null;
        public string address { get; set; } = null;
        public string email { get; set; } = null;
        public DateTime created { get; set; }

       

    }
}
