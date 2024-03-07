using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoiresBatternWithUnitOfWork.EF.Models.PrintStation
{
    public class PrintStation
    {
        public int Id { get; set; }
        public string name { get; set; } = null!;
        public string toPrinter { get; set; } = null!;

        public PrintStation()
        {
            products = new HashSet<ProductPrintStation>();
            groups = new HashSet<GroupPrintStation>();
        }


        public virtual ICollection<ProductPrintStation> products { get; set; }

        public virtual ICollection<GroupPrintStation> groups { get; set; }




    }
}
