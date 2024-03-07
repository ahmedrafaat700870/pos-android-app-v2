using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoiresBatternWithUnitOfWork.EF.Models.Settings
{
    public class PrinterSettings
    {
        public int Id { get; set; }
        public int SettingId { get; set; }
        public virtual PrinterInvoice? PrinterInvoice { get; set; } = null!;
        public virtual PrinterKitchen? PrinterKitchen { get; set; } = null!;
    }
}
