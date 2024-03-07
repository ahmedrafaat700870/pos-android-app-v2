using System;
using System.Collections.Generic;
using RepositoiresBatternWithUnitOfWork.EF.Models.AcountModels;

namespace RepositoiresBatternWithUnitOfWork.EF.Models.CloudModels
{
    public partial class BranchesBranch
    {
        public BranchesBranch()
        {
            AccountsUsers = new HashSet<AccountsUser>();
        }

        public int Id { get; set; } // true
        public string Name { get; set; } = null!;
        public string? Phone { get; set; } = null!;
        public string? Telephone { get; set; } = null!;
        public string? Governorate { get; set; } = null!;
        public string? City { get; set; } = null!;
        public string? Place { get; set; } = null!;
        public string? Description { get; set; } = null!;
        public string? WorkHours { get; set; } = null!;
        public string created { get; set; } = null!;
        public string last_modified { get; set; } = null!;
        public int CompanyId { get; set; }


        public int? Could_Id { get; set; }
        public int? Cloud_CompanyId { get; set; }

        public virtual CompanyCompany Company { get; set; } = null!;
        public virtual InventoryStock? InventoryStock { get; set; } = null!;
        public virtual ICollection<AccountsUser> AccountsUsers { get; set; } = null!;
    }
}
