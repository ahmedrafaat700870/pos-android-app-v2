
using RepositoiresBatternWithUnitOfWork.EF.Models.OrderModels.AddOrderModels;

namespace Services.Promo.Promo_Type
{
	public class Promo_Items
	{
		public int id { get; set; }
		public int promo_appaly_to_next { get; set; } = 1;
	}
    public class Add_Promo_Contional_AppToNext : Add_Promo_To_Order_item
    {
        private InventoryOrder _Order { get; set; }
        private InventoryOrderProduct _Order_Prodcut;
        public Add_Promo_Contional_AppToNext(InventoryOrderitem orderitem, promo_item promo, InventoryOrder order, InventoryOrderProduct order_prodcut) : base(orderitem, promo)
        {
            this._Order = order;
            this._Order_Prodcut = order_prodcut;
        }
        public static int promo_appaly_to_next = 1;
		public static List<Promo_Items> promo_items { get; set; } 
		= new List<Promo_Items>();
		public InventoryOrderProduct? Add_Promo_Contional(int InteredQty = 0)
        {
            if (this.Promo.fixed_price == 0 && this.Promo.discount_in_percentage == 0 )
                return null;

            //decimal last_qty = Get_Order_Item_Count();

            decimal qty = this._Order_item.Quantity;
            var last_qty = Get_Order_Item_Count();
            
            int x = Convert.ToInt32(last_qty) % Convert.ToInt32(this.Promo.apply_all);

            if((x != 0 && qty == 1) || (last_qty == 0 && qty == 1))
				return null;
			checak_order_item_exsits_in_promo_items();
			if (qty == 1)
			{
				add_by_one(qty);
				return null;
			}

			decimal order_item_count = 0;
			decimal order_item_promo_count = 0;

			add_by_many(x , out order_item_count ,out order_item_promo_count , qty );

			this._Order_item.Quantity = order_item_count;
			if (order_item_promo_count > 0)
			{
				var order_item_promo = create_new_order_item(order_item_promo_count);
				InventoryOrderProduct promo_order_prodcut = new InventoryOrderProduct
				{
					Added_Date = this._Order_Prodcut.Added_Date,
					Orderitem = order_item_promo
				};
				add_promo_to_order_item(order_item_promo);
				return promo_order_prodcut;
			}
			return null; 
        }

		public static void Resat()
		{
			promo_items = new List<Promo_Items>();
		}
		public static void Remove_Item(int qty , int id)
		{

		}
		private void checak_order_item_exsits_in_promo_items()
		{
			var item = promo_items.Where(x =>x.id == this._Order_item.ProductId).FirstOrDefault();
			if(item is null)
				promo_items.Add(new Promo_Items() { id = this._Order_item.ProductId});
		}
		private Promo_Items get_promo_item()
		{
			return promo_items.Where(x => x.id == this._Order_item.Product.Id).FirstOrDefault()!;
		}
		private void add_by_one(decimal qty )
		{
			var promo_item = get_promo_item();
			if ( promo_item.promo_appaly_to_next <= this.Promo.apply_to_next)
			{
				// add promo in invenotryOrderprodcut.not promo
				this._Order_item.is_promo = true;
				add_promo_to_order_item(this._Order_item);
				promo_item.promo_appaly_to_next += 1;
			}
			else
				promo_item.promo_appaly_to_next = 1;

		}

		private void add_by_many(int x ,out decimal order_item_count, out decimal order_item_promo_count , decimal qty)
		{
			order_item_count = 0;
			order_item_promo_count = 0;
			// add many
			int item_count = x;
			var promo_item = get_promo_item();
			for (int i = 0; i < qty; i++)
			{
				int y = item_count % Convert.ToInt32( this.Promo.apply_to_next);
				if (y != 0)
				{
					order_item_count++;
					item_count++;
				}
				else
				{
					if (promo_item.promo_appaly_to_next <= this.Promo.apply_to_next)
					{
						promo_appaly_to_next += 1;
						order_item_promo_count++;
						item_count++;
						if(promo_appaly_to_next == this.Promo.apply_to_next)
							promo_item.promo_appaly_to_next = 1;
					}
					else
					{
						promo_item.promo_appaly_to_next = 1;
						order_item_count++;
						item_count++;
					}
				}

			}

		
		}
		
		private void create_inventory_order_item_promo(decimal order_item_count , decimal order_item_promo_count)
		{
			this._Order_item.Quantity = order_item_count;
		}
		
		private decimal Get_Order_Item_Count()
        {
			decimal count = 0;//= this._Order.InventoryOrderProducts.Where(x => !x.Orderitem.is_promo).Count();
            var order_items= this._Order.InventoryOrderProducts.Where(x => !x.Orderitem.is_promo && x.Orderitem.Product.Id == this._Order_item.Product.Id);
            foreach(var order_item in order_items)
            {
                count += order_item.Orderitem.Quantity;
            }
            return count ;
        }

        private InventoryOrderProduct ? get_last_order_item_is_promo()
        {
            var last_order_item_promo = this._Order.InventoryOrderProducts.Where(x =>x.Orderitem.is_promo && x.Orderitem.Product.Id == this._Order_item.Product.Id).LastOrDefault()!;

            return last_order_item_promo;
		}

        private InventoryOrderitem create_new_order_item(decimal qty)
        {
			InventoryOrderitem promo_order_item = new InventoryOrderitem
			{
				Add_Date = this._Order_item.Add_Date,
				original_price = this._Order_item.original_price,
				ProductId = this._Order_item.ProductId,
				Product = this._Order_item.Product,
				Quantity = qty,
				tax_included = this._Order_item.tax_included,
				Total = this._Order_item.Total,
				TaxTotal = this._Order_item.TaxTotal,
				Percentage_Taxes = this._Order_item.Percentage_Taxes,
				Subtotal = this._Order_item.Subtotal,
				InventoryAddonitems = new HashSet<InventoryAddonitem>(),
				is_promo = true,
				ItemBoxId = null,
				Invoice = null,
				_product_api = _Order_item._product_api
			};

            return promo_order_item;
		}

        private void add_promo_to_order_item(InventoryOrderitem promo_order_item)
        {
			if (this.Promo.fixed_price != 0)
			{
				// change price order item .
				promo_order_item.original_price = this.Promo.fixed_price;
				if (promo_order_item.tax_included)
				{
					promo_order_item.Subtotal = this.Promo.fixed_price / (promo_order_item.Percentage_Taxes + 100) * 100;
					promo_order_item.TaxTotal = this.Promo.fixed_price - promo_order_item.Subtotal;
					promo_order_item.Total = this.Promo.fixed_price;
				}
				else
				{
					// calc order detalis .
					promo_order_item.Subtotal = this.Promo.fixed_price;
					promo_order_item.TaxTotal = this.Promo.fixed_price * (promo_order_item.Percentage_Taxes / 100);
					promo_order_item.Total = this.Promo.fixed_price + promo_order_item.TaxTotal;
				}

			}
			else if (this.Promo.discount_in_percentage != 0)
			{
				promo_order_item.DiscountInPercentage = this.Promo.discount_in_percentage;
			}
		}

		public override void Add_Promo() {}
    }
}
