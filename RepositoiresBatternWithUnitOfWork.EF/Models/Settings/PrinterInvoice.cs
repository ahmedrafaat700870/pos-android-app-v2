using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoiresBatternWithUnitOfWork.EF.Models.Settings
{
    public class PrinterInvoice
    {
        public int Id { get; set; }
        public int PrinterSettingsId { get; set; }
        public string PrinterName { get; set; } = null!;
        public string Img_Base_64 { get; set; } = null!;
        public string Invoice_Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string No { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;

    }
}
