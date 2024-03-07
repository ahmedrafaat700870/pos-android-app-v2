using System;
using System.Collections.Generic;
using RepositoiresBatternWithUnitOfWork.EF.Models.CloudModels;
using RepositoiresBatternWithUnitOfWork.EF.Models.OrderModels;
using RepositoiresBatternWithUnitOfWork.EF.Models.ProductModels;

namespace RepositoiresBatternWithUnitOfWork.EF.Models.AcountModels
{
    public partial class AccountsCustomer
    {
        public AccountsCustomer()
        {
            InventoryOrders = new HashSet<InventoryOrder>();
            InventoryProducts = new HashSet<InventoryProduct>();
        }
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Avatar { get; set; }
        public string? PhoneNumber { get; set; } = null!;
        public string? Email { get; set; } = null!;
        public string? Address { get; set; } = null!;
        public bool IsSupplier { get; set; }
        public string? VatNumber { get; set; } = null!;
        public int CompanyId { get; set; }
        public string? ImageBased64 { get; set; }

        public string customer_uuid { get; set; } = string.Empty;

        public bool isDeleted { get; set; } = false;

        public int Cloud_Id { get; set; }
        public int Cloud_Company_Id { get; set; }


        //   Added_Date
        public DateTime date_created { get; set; }
        public virtual CompanyCompany Company { get; set; } = null!;
        public virtual ICollection<InventoryOrder> InventoryOrders { get; set; }
        public virtual ICollection<InventoryProduct> InventoryProducts { get; set; }

    }
}
