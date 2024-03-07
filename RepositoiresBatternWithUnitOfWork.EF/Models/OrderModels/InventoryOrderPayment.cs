using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepositoiresBatternWithUnitOfWork.EF.Models.OrderModels
{
    public partial class InventoryOrderPayment
    {
        public InventoryOrderPayment()
        {

        }


        public int Id { get; set; }
        public int OrderId { get; set; }
        /*     public int _InventoryOrderId { get; set; }*/

        /*      public virtual InventoryOrder Order { get; set; } = null!;*/

    }
}
