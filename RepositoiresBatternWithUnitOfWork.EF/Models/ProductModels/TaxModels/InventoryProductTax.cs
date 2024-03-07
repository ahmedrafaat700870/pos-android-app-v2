using System;
using System.Collections.Generic;
using RepositoiresBatternWithUnitOfWork.EF.Models.ProductModels;

namespace RepositoiresBatternWithUnitOfWork.EF.Models.ProductModels.TaxModels
{
    public partial class InventoryProductTax
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int TaxId { get; set; }
        public DateTime created { get; set; }
        public virtual InventoryProduct Product { get; set; } = null!;
        public virtual InventoryTax Tax { get; set; } = null!;

        public int Cloud_Id { get; set; }
        public int Cloud_Product_Id { get; set; }
        public int Cloud_Tax_Id { get; set; }

    }
}
