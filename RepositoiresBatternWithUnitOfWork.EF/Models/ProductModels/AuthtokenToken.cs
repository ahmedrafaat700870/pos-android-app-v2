using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RepositoiresBatternWithUnitOfWork.EF.Models.AcountModels;

namespace RepositoiresBatternWithUnitOfWork.EF.Models.ProductModels
{
    [PrimaryKey("Id")]
    public partial class AuthtokenToken
    {
        public int Id { get; set; }
        public string Key { get; set; } = null!;
        public DateTime created { get; set; }
        public int UserId { get; set; }

        public int Cloud_User_Id { get; set; }

        public virtual AccountsUser User { get; set; } = null!;
    }
}
