using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RepositoiresBatternWithUnitOfWork.EF.Models.CloudModels;

namespace RepositoiresBatternWithUnitOfWork.EF.Models.OrderModels.AddOrderModels
{
    public partial class InventoryAddon
    {
        public InventoryAddon()
        {
            InventoryAddontypes = new HashSet<InventoryAddontype>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int StockId { get; set; }


        public int Cloud_Id { get; set; }
        public int Cloud_StockId { get; set; }
        public DateTime created { get; set; }
        public virtual InventoryStock Stock { get; set; } = null!;
        public virtual ICollection<InventoryAddontype> InventoryAddontypes { get; set; }
    }
}
