using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RepositoiresBatternWithUnitOfWork.EF.Models.AcountModels;

namespace RepositoiresBatternWithUnitOfWork.EF.Models.CloudModels
{
    public partial class CompanyCompany
    {

        public CompanyCompany()
        {
            AccountsCustomers = new HashSet<AccountsCustomer>();
            AccountsCustomgroups = new HashSet<AccountsCustomgroup>();
            AccountsUsers = new HashSet<AccountsUser>();
            BranchesBranches = new HashSet<BranchesBranch>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? VatRegNumber { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Logo { get; set; }
        public string created { get; set; } = null!;



        public int? Cloud_Id { get; set; } = null!;




        public virtual ICollection<AccountsCustomer> AccountsCustomers { get; set; }
        public virtual ICollection<AccountsCustomgroup> AccountsCustomgroups { get; set; }
        public virtual ICollection<AccountsUser> AccountsUsers { get; set; }
        public virtual ICollection<BranchesBranch> BranchesBranches { get; set; }
    }
}
