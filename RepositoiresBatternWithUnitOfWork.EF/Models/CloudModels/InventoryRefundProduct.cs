using System;
using System.Collections.Generic;

namespace RepositoiresBatternWithUnitOfWork.EF.Models.CloudModels
{
    public partial class InventoryRefundProduct
    {
        public int Id { get; set; }
        public int RefundId { get; set; }
        public int RefunditemId { get; set; }

        public virtual InventoryRefund Refund { get; set; } = null!;
        public virtual InventoryRefunditem Refunditem { get; set; } = null!;
    }
}
