using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoiresBatternWithUnitOfWork.EF.Models.Settings
{
    public class PrinterKitchen
    {
        public int Id { get; set; }
        public int PrinterSettingsId { get; set; }
        public string PrinterName { get; set; } = null!;
    }
}
