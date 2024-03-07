using System;
using System.Collections.Generic;
using RepositoiresBatternWithUnitOfWork.EF.Models.AcountModels;

namespace RepositoiresBatternWithUnitOfWork.EF.Models.CloudModels
{
    public partial class AccountsCustomgroup
    {
        public int GroupPtrId { get; set; }
        public int CompanyId { get; set; }
        public int CreatorId { get; set; }

        public virtual CompanyCompany Company { get; set; } = null!;
        public virtual AccountsUser Creator { get; set; } = null!;
    }
}
