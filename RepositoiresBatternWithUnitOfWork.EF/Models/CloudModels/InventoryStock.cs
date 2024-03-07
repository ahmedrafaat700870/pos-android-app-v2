using System;
using System.Collections.Generic;
using RepositoiresBatternWithUnitOfWork.EF.Models.OrderModels;
using RepositoiresBatternWithUnitOfWork.EF.Models.OrderModels.AddOrderModels;
using RepositoiresBatternWithUnitOfWork.EF.Models.OrderModels.PaymentsModdels;
using RepositoiresBatternWithUnitOfWork.EF.Models.ProductModels;
using RepositoiresBatternWithUnitOfWork.EF.Models.ProductModels.TaxModels;

namespace RepositoiresBatternWithUnitOfWork.EF.Models.CloudModels
{
    public partial class InventoryStock
    {
        public InventoryStock()
        {
            InventoryAddons = new HashSet<InventoryAddon>();
            InventoryOrders = new HashSet<InventoryOrder>();
            InventoryProductgroups = new HashSet<InventoryProductgroup>();
            InventoryProducts = new HashSet<InventoryProduct>();
            InventoryRefunds = new HashSet<InventoryRefund>();
            InventoryTaxes = new HashSet<InventoryTax>();
            PaymentsPaymenttypes = new HashSet<PaymentsPaymenttype>();
        }
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int BranchId { get; set; }
        public string created { get; set; } = null!;





        public int Cloud_Id { get; set; }
        public int Cloud_Branch_Id { get; set; }

        public virtual BranchesBranch Branch { get; set; } = null!;
        public virtual ICollection<InventoryAddon> InventoryAddons { get; set; }
        public virtual ICollection<InventoryOrder> InventoryOrders { get; set; }
        public virtual ICollection<InventoryProductgroup> InventoryProductgroups { get; set; }
        public virtual ICollection<InventoryProduct> InventoryProducts { get; set; }
        public virtual ICollection<InventoryRefund> InventoryRefunds { get; set; }
        public virtual ICollection<InventoryTax> InventoryTaxes { get; set; }
        public virtual ICollection<PaymentsPaymenttype> PaymentsPaymenttypes { get; set; }
    }
}
