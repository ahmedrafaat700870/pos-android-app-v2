using System;
using System.Collections.Generic;
using RepositoiresBatternWithUnitOfWork.EF.Models.AcountModels;
using RepositoiresBatternWithUnitOfWork.EF.Models.CloudModels;
using RepositoiresBatternWithUnitOfWork.EF.Models.Item_Box_t;
using RepositoiresBatternWithUnitOfWork.EF.Models.OrderModels;
using RepositoiresBatternWithUnitOfWork.EF.Models.PrintStation;
using RepositoiresBatternWithUnitOfWork.EF.Models.ProductModels.TaxModels;
using RepositoiresBatternWithUnitOfWork.EF.Models.Promotions;

namespace RepositoiresBatternWithUnitOfWork.EF.Models.ProductModels
{
    public partial class InventoryProduct
    {
        public InventoryProduct()
        {

            InventoryOrderitems = new HashSet<InventoryOrderitem>();
            InventoryProductTaxes = new HashSet<InventoryProductTax>();
            InventoryRefunditems = new HashSet<InventoryRefunditem>();

            Boxs = new HashSet<ItemBox>();
            Promo = new HashSet<promo_item>();

            ProductPrintStations = new HashSet<ProductPrintStation>();

        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal TaxTotal { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public decimal LastCost { get; set; }
        public decimal BeforeTax { get; set; }
        public bool LowStockBool { get; set; }
        public bool TaxIncluded { get; set; }
        public decimal PriceWithTax { get; set; }
        public bool Active { get; set; }
        public decimal Quantity { get; set; }
        public string? Barcode { get; set; }
        public string? Code { get; set; }
        public string? Image { get; set; }
        public int? CreatedById { get; set; }
        public int? GroupId { get; set; }
        public int? LastModifiedById { get; set; }
        public int? StockId { get; set; }
        public int? SupplierId { get; set; }
        public bool Pinter_Kitchen { get; set; } = false;
        public string? ImageBased64 { get; set; }

        public int Cloud_Id { get; set; }
        public int? Cloud_CreatedBy_Id { get; set; }
        public int? Cloud_Group_Id { get; set; }
        public int? Cloud_LastModifiedBy_Id { get; set; }
        public int? Cloud_SupplierId { get; set; }
        public int? Cloud_Stock_Id { get; set; }

        public bool isDeleted { get; set; } = false;
        public DateTime created { get; set; }

        public virtual AccountsUser? CreatedBy { get; set; }
        public virtual InventoryProductgroup? Group { get; set; }
        public virtual AccountsUser? LastModifiedBy { get; set; }
        public virtual InventoryStock? Stock { get; set; }
        public virtual AccountsCustomer? Supplier { get; set; }
        public virtual ICollection<InventoryOrderitem> InventoryOrderitems { get; set; }
        public virtual ICollection<InventoryProductTax> InventoryProductTaxes { get; set; }
        public virtual ICollection<InventoryRefunditem> InventoryRefunditems { get; set; }
        public virtual ICollection<promo_item> Promo { get; set; } = null!;
        public virtual ICollection<ItemBox> Boxs { get; set; }


        public virtual ICollection<ProductPrintStation> ProductPrintStations { get; set; }
    }
}
