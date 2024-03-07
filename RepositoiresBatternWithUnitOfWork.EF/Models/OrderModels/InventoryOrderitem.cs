using System;
using System.Collections.Generic;
using HTTPCLIENT.models.api_prodcut;
using RepositoiresBatternWithUnitOfWork.EF.Models.CloudModels;
using RepositoiresBatternWithUnitOfWork.EF.Models.OrderModels.AddOrderModels;
using RepositoiresBatternWithUnitOfWork.EF.Models.ProductModels;

namespace RepositoiresBatternWithUnitOfWork.EF.Models.OrderModels
{
    public partial class InventoryOrderitem
    {
        public InventoryOrderitem()
        {
            InventoryAddonitems = new HashSet<InventoryAddonitem>();
            InventoryOrderProducts = new HashSet<InventoryOrderProduct>();
        }

        public int Id { get; set; }
        public string name { get; set; }
        public decimal Quantity { get; set; }
        public decimal Discount { get; set; }
        public decimal DiscountInPercentage { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public decimal TaxTotal { get; set; }
        public int? InvoiceId { get; set; }
        public int? ItemBoxId { get; set; }
        public int ProductId { get; set; }
        public DateTime Add_Date { get; set; }
        public decimal original_price { get; set; }
        public bool discount_inpercentage_is_first { get; set; } = false;
        public decimal Percentage_Taxes { get; set; } = 0;
        public bool tax_included { get; set; }
        public bool is_promo { get; set; } = false;
        public bool Is_Discount_For_Total { get; set; } = true;
        public bool is_box { get; set; } = false;
        public int box_id { get; set; } = 0;
        public int? cloud_box_id { get; set; } = null!;

        public virtual InventoryRefunditem InventoryRefunditem { get; set; } = null!;
        public virtual InventoryOrder? Invoice { get; set; }
        public virtual InventoryProduct Product { get; set; } = null!;
        public virtual ICollection<InventoryAddonitem> InventoryAddonitems { get; set; }
        public virtual ICollection<InventoryOrderProduct> InventoryOrderProducts { get; set; }

        public inventory_prodcut? _product_api = null!;
    }
}
