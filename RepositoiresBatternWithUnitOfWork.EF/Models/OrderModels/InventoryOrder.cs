using System;
using System.Collections.Generic;
using RepositoiresBatternWithUnitOfWork.EF.Models.AcountModels;
using RepositoiresBatternWithUnitOfWork.EF.Models.CloudModels;
using RepositoiresBatternWithUnitOfWork.EF.Models.SavedSale;
using RepositoiresBatternWithUnitOfWork.EF.Models.OrderModels.PaymentsModdels;


namespace RepositoiresBatternWithUnitOfWork.EF.Models.OrderModels
{
    public partial class InventoryOrder
    {
        public InventoryOrder()
        {
            InventoryOrderPayments = new HashSet<InventoryOrderPayment>();
            InventoryOrderProducts = new List<InventoryOrderProduct>();
            InventoryRefunds = new HashSet<InventoryRefund>();
            PaymentsPaymentamounts = new HashSet<PaymentsPaymentamount>();
        }

        public int Id { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Price { get; set; }
        public decimal TaxTotal { get; set; }
        public decimal Discount { get; set; } = 0;
        public decimal DiscountInPercentage { get; set; } = 0;
        public string? Qrcode { get; set; }
        public int? ClientId { get; set; }
        public int CreatedById { get; set; }
        public int? LastModifiedById { get; set; }
        public int StockId { get; set; }
        public DateTime? OrderDate { get; set; }
        /*public bool Is_Stored { get; set; } = false;*/
        public int Shift_Number { get; set; }
        public bool discount_inpercentage_is_first { get; set; } = false;
        public bool Is_Discount_For_Total { get; set; } = true;

        public bool Is_Asynced { get; set; } = false;

        public DateTime SavedOrderDate { get; set; } 
        public virtual AccountsCustomer? Client { get; set; }

        public virtual AccountsUser CreatedBy { get; set; } = null!;
        public virtual AccountsUser? LastModifiedBy { get; set; }
        public virtual InventoryStock Stock { get; set; } = null!;
        public virtual InventorySavedSale SavedSales { get; set; } = null!;

        public virtual ICollection<InventoryOrderPayment> InventoryOrderPayments { get; set; }
        public virtual List<InventoryOrderProduct> InventoryOrderProducts { get; set; }

        public virtual ICollection<InventoryRefund> InventoryRefunds { get; set; }
        public virtual ICollection<PaymentsPaymentamount> PaymentsPaymentamounts { get; set; }

        

    }
}
