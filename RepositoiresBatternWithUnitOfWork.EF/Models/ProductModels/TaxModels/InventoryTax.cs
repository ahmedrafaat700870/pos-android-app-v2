using System;
using System.Collections.Generic;
using RepositoiresBatternWithUnitOfWork.EF.Models.CloudModels;

namespace RepositoiresBatternWithUnitOfWork.EF.Models.ProductModels.TaxModels
{
    public partial class InventoryTax
    {
        public InventoryTax()
        {
            InventoryProductTaxes = new HashSet<InventoryProductTax>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal PercentageValue { get; set; }
        public int StockId { get; set; }
        public DateTime created { get; set; }

        public int Cloud_Id { get; set; }
        public int Cloud_Stock_Id { get; set; }

        public virtual InventoryStock Stock { get; set; } = null!;
        public virtual ICollection<InventoryProductTax> InventoryProductTaxes { get; set; }
    }
}
