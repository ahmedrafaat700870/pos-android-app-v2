
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTPCLIENT.models.branch
{

    public class branch
    {
        public int branch_Id { get; set; }
        public int id { get; set; }
        public string name { get; set; } = null;
        public string phone { get; set; } = null;
        public string telephone { get; set; } = null;
        public string governorate { get; set; } = null;
        public string city { get; set; } = null;
        public string place { get; set; } = null;
        public string description { get; set; } = null;
        public string work_hours { get; set; } = null;
        public DateTime created { get; set; }
        public DateTime last_modified { get; set; }
        public int company { get; set; }

    }
}
