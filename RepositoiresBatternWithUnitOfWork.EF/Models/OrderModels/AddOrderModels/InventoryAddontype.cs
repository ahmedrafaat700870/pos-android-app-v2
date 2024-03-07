using System;
using System.Collections.Generic;

namespace RepositoiresBatternWithUnitOfWork.EF.Models.OrderModels.AddOrderModels
{
    public partial class InventoryAddontype
    {
        public InventoryAddontype()
        {
            InventoryAddonitems = new HashSet<InventoryAddonitem>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int AddonId { get; set; }
        public decimal Price { get; set; }

        public int Cloud_Id { get; set; }
        public int Cloud_AddonId { get; set; }

        public DateTime created { get; set; }

        public virtual InventoryAddon Addon { get; set; } = null!;
        public virtual ICollection<InventoryAddonitem> InventoryAddonitems { get; set; }
    }
}
