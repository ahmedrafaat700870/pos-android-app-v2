using RepositoiresBatternWithUnitOfWork.EF.Models.OrderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoiresBatternWithUnitOfWork.EF.Models.SavedSale
{
    public class InventorySavedSale
    {
        public InventorySavedSale()
        {
            oInventoryOrder = new InventoryOrder();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int InventoryOrder_Id { get; set; }
        public InventoryOrder oInventoryOrder { get; set; }

    }
}
