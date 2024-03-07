using System;
using System.Collections.Generic;

namespace RepositoiresBatternWithUnitOfWork.EF.Models.OrderModels
{
    public partial class InventoryOrderProduct
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int OrderitemId { get; set; }

        public DateTime Added_Date { get; set; }
        public virtual InventoryOrder Order { get; set; } = null!;
        public virtual InventoryOrderitem Orderitem { get; set; } = null!;
    }
}
