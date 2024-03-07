using RepositoiresBatternWithUnitOfWork.EF.Models.ProductModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoiresBatternWithUnitOfWork.EF.Models.PrintStation
{
    public class GroupPrintStation
    {
        public int Id { get; set; }
        public int groupId { get; set; }
        public int printStationId { get; set; }

        public virtual PrintStation printStation { get; set; } = null!;
        public virtual InventoryProductgroup group { get; set; } = null!;

    }
}
