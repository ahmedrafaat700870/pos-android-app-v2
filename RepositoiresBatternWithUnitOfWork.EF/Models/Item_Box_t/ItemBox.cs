using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoiresBatternWithUnitOfWork.EF.Models.Item_Box_t
{
    public class ItemBox
    {
        public int Id { get; set; }
        public string box_name { get; set; } = null!;
        public string? Image_base64 { get; set; } = null!;
        public int InventoryProductId { get; set; }
        public decimal Box_Count { get; set; }
        public decimal Unit_of_price { get; set; }
        public string? Box_BarCode { get; set; } = null!;
        public bool isDeleted { get; set; } = false;
        public DateTime created { get; set; }
        public int Cloud_Id { get; set; }
        public int Cloud_Product_id { get; set; }
    }
}
