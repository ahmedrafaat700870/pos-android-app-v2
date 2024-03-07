using RepositoiresBatternWithUnitOfWork.EF.Models.OrderModels;
using System;
using System.Collections.Generic;

namespace RepositoiresBatternWithUnitOfWork.EF.Models.OrderModels.AddOrderModels
{
    public partial class InventoryAddonitem
    {
        public int Id { get; set; }
        public int AddonTypeId { get; set; }
        public int OrderItemId { get; set; }
        public decimal Qty { get; set; }
        public decimal Orignal_Price { get; set; }
        public decimal Tax_Total { get; set; }
        public decimal Price_Befor_Tax { get; set; }
        public decimal Total { get; set; }
        public decimal Discount_inpercentage { get; set; }
        public decimal Discount { get; set; }

        public DateTime? added_date { get; set; }
        public virtual InventoryAddontype AddonType { get; set; } = null!;
        public virtual InventoryOrderitem OrderItem { get; set; } = null!;
    }
}
