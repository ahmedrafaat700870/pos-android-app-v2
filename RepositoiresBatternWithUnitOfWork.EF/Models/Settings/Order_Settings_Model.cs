using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoiresBatternWithUnitOfWork.EF.Models.Settings
{
    [PrimaryKey("id")]
    public class Order_Settings_Model
    {
        public int id { get; set; }
        public bool prevent_negative { get; set; }
        public bool reset_invoice { get; set; }
        public bool allow_price_changing { get; set; }
        public int cloud_id { get; set; }
    }
}
