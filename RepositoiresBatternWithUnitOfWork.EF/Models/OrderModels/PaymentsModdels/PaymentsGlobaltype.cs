using System;
using System.Collections.Generic;

namespace RepositoiresBatternWithUnitOfWork.EF.Models.OrderModels.PaymentsModdels
{
    public partial class PaymentsGlobaltype
    {
        public PaymentsGlobaltype()
        {
            PaymentsPaymentamounts = new HashSet<PaymentsPaymentamount>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Cloud_Id { get; set; }

        public virtual ICollection<PaymentsPaymentamount> PaymentsPaymentamounts { get; set; }
    }
}
