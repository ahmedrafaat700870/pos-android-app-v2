using System;
using System.Collections.Generic;
using RepositoiresBatternWithUnitOfWork.EF.Models.AcountModels;
using RepositoiresBatternWithUnitOfWork.EF.Models.CloudModels;
using RepositoiresBatternWithUnitOfWork.EF.Models.PrintStation;

namespace RepositoiresBatternWithUnitOfWork.EF.Models.ProductModels
{
    public partial class InventoryProductgroup
    {
        public InventoryProductgroup()
        {
            InventoryProducts = new HashSet<InventoryProduct>();
            InverseParent = new HashSet<InventoryProductgroup>();

            GroupPrintStations = new HashSet<GroupPrintStation>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? CreatedById { get; set; }
        public int? LastModifiedById { get; set; }
        public int? ParentId { get; set; }
        public int StockId { get; set; }



        public int Cloud_Id { get; set; }
        public int? Cloud_Created_By_Id { get; set; }
        public int? Cloud_Last_Modified_By_Id { get; set; }
        public int? Cloud_Parent_Id { get; set; }
        public int Cloud_StockId { get; set; }

        public bool isDeleted { get; set; } = false;

        public DateTime created { get; set; }
        public string? ImageBased64 { get; set; }
        public virtual AccountsUser? CreatedBy { get; set; }
        public virtual AccountsUser? LastModifiedBy { get; set; }
        public virtual InventoryProductgroup? Parent { get; set; }
        public virtual InventoryStock Stock { get; set; } = null!;
        public virtual ICollection<InventoryProduct> InventoryProducts { get; set; }
        public virtual ICollection<InventoryProductgroup> InverseParent { get; set; }


        public virtual ICollection<GroupPrintStation> GroupPrintStations { get; set; }

    }
}
