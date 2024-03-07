using System;
using System.Collections.Generic;
using RepositoiresBatternWithUnitOfWork.EF.Models.CloudModels;
using RepositoiresBatternWithUnitOfWork.EF.Models.DayShift;
using RepositoiresBatternWithUnitOfWork.EF.Models.OrderModels;
using RepositoiresBatternWithUnitOfWork.EF.Models.ProductModels;

namespace RepositoiresBatternWithUnitOfWork.EF.Models.AcountModels
{
    public partial class AccountsUser
    {
        public AccountsUser()
        {
            InventoryOrderCreatedBies = new HashSet<InventoryOrder>();
            InventoryOrderLastModifiedBies = new HashSet<InventoryOrder>();
            InventoryProductCreatedBies = new HashSet<InventoryProduct>();
            InventoryProductLastModifiedBies = new HashSet<InventoryProduct>();
            InventoryProductgroupCreatedBies = new HashSet<InventoryProductgroup>();
            InventoryProductgroupLastModifiedBies = new HashSet<InventoryProductgroup>();
            InventoryRefunds = new HashSet<InventoryRefund>();
        }

        public int Id { get; set; }
        public string Password { get; set; } = null!;
        public bool IsSuperuser { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool IsStaff { get; set; }
        public bool IsActive { get; set; }
        public string Username { get; set; } = null!;
        public string Role { get; set; } = null!;
        public string? Avatar { get; set; }
        public DateTime? Birth { get; set; }
        public string Country { get; set; } = null!;
        public string? PhoneNumber { get; set; } = null!;
        public int? StartingCash { get; set; }
        public string Timezone { get; set; } = null!;
        public string Lang { get; set; } = null!;
        public int? BranchId { get; set; }
        public int? CompanyId { get; set; }
        public string SerialNumber { get; set; } = null!;
        public string? ImageBased64 { get; set; }

        public DateTime? created { get; set; } = null;

        public int Cloud_Id { get; set; }
        public int? Cloud_Branch_Id { get; set; }
        public int? Cloud_Company_Id { get; set; }





        public virtual UserWorkShift? UserWorkShift { get; set; } = null!;
        public virtual BranchesBranch? Branch { get; set; } = null!;

        public virtual AuthtokenToken? AuthtokenToken { get; set; } = null!;
        public virtual ICollection<InventoryOrder> InventoryOrderCreatedBies { get; set; }
        public virtual ICollection<InventoryOrder> InventoryOrderLastModifiedBies { get; set; }
        public virtual ICollection<InventoryProduct> InventoryProductCreatedBies { get; set; }
        public virtual ICollection<InventoryProduct> InventoryProductLastModifiedBies { get; set; }
        public virtual ICollection<InventoryProductgroup> InventoryProductgroupCreatedBies { get; set; }
        public virtual ICollection<InventoryProductgroup> InventoryProductgroupLastModifiedBies { get; set; }
        public virtual ICollection<InventoryRefund> InventoryRefunds { get; set; }

    }
}
