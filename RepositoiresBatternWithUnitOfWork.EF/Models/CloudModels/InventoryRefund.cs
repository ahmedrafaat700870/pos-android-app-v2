using System;
using System.Collections.Generic;
using RepositoiresBatternWithUnitOfWork.EF.Models.AcountModels;
using RepositoiresBatternWithUnitOfWork.EF.Models.OrderModels;

namespace RepositoiresBatternWithUnitOfWork.EF.Models.CloudModels
{
    public partial class InventoryRefund
    {
        public InventoryRefund()
        {
            InventoryRefunditems = new HashSet<InventoryRefunditem>();
        }

        public int Id { get; set; }
        public decimal Total { get; set; }
        public bool FullRefund { get; set; }
        public int CreatedById { get; set; }
        public int InvoiceId { get; set; }
        public int StockId { get; set; }
        public DateTime Add_Date { get; set; }
        public DateTime? Order_Date { get; set; }
        public decimal Discount { get; set; }


        public virtual AccountsUser CreatedBy { get; set; } = null!;
        public virtual InventoryOrder Invoice { get; set; } = null!;
        public virtual InventoryStock Stock { get; set; } = null!;


        public virtual ICollection<InventoryRefunditem> InventoryRefunditems { get; set; }
    }
}
