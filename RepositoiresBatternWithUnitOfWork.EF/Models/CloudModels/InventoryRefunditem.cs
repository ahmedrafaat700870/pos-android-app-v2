using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using RepositoiresBatternWithUnitOfWork.EF.Models.OrderModels;
using RepositoiresBatternWithUnitOfWork.EF.Models.ProductModels;

namespace RepositoiresBatternWithUnitOfWork.EF.Models.CloudModels
{
    public partial class InventoryRefunditem
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
        public decimal Quantity { get; set; }
        public decimal discount { get; set; }
        public int ProductId { get; set; }
        public int RefundedInvoiceId { get; set; }
        public int InventoryOrderitemId { get; set; }
        public bool is_promo { get; set; }
        public DateTime Add_Date { get; set; }

        public virtual InventoryProduct Product { get; set; } = null!;
        public virtual InventoryOrderitem Orderitem { get; set; } = null!;
        public virtual InventoryRefund RefundedInvoice { get; set; } = null!;
    }
}
