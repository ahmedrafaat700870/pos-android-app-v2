using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RepositoiresBatternWithUnitOfWork.EF.Models.OrderModels;

namespace RepositoiresBatternWithUnitOfWork.EF.Models.OrderModels.PaymentsModdels
{
    public partial class PaymentsPaymentamount
    {
        public PaymentsPaymentamount()
        {
            InventoryOrder = new InventoryOrder();
        }

        public int Id { get; set; }
        public decimal Amount { get; set; }
        public int? GlobalTypeId { get; set; }
        public int? PaymentTypeId { get; set; }

        public int InventoryOrderId { get; set; }
        public DateTime? Created { get; set; }
        public virtual InventoryOrder InventoryOrder { get; set; }
        public virtual PaymentsGlobaltype? GlobalType { get; set; }
        public virtual PaymentsPaymenttype? PaymentType { get; set; }

    }
}
