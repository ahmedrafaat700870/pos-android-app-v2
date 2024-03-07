using System;
using System.Collections.Generic;
using RepositoiresBatternWithUnitOfWork.EF.Models.CloudModels;

namespace RepositoiresBatternWithUnitOfWork.EF.Models.OrderModels.PaymentsModdels
{
    public partial class PaymentsPaymenttype
    {
        public PaymentsPaymenttype()
        {
            PaymentsPaymentamounts = new HashSet<PaymentsPaymentamount>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool Enabled { get; set; }
        public bool MarkPaid { get; set; }
        public bool CustomerRequired { get; set; }
        public int StockId { get; set; }
        public int Cloud_Id { get; set; }

        public virtual InventoryStock Stock { get; set; } = null!;
        public virtual ICollection<PaymentsPaymentamount> PaymentsPaymentamounts { get; set; }
    }
}
