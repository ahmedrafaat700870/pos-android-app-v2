namespace App.ViewModel.ItemBox
{
    public partial class BoxModel : ObservableObject
    {
        [ObservableProperty]
        private string name;
        [ObservableProperty]
        private decimal price;
        [ObservableProperty]
        private string image;
        private ItemBoxes box;
        private inventory_prodcut prodcut;
        private InventoryOrderitem orderItem;
        public BoxModel(ItemBoxes box ,inventory_prodcut prodcut)
        {
            Image = prodcut.image ?? string.Empty;
            decimal _price = box.unit_of_price * box.count;
            this.prodcut = prodcut; 
            this.box = box;
            Name = box.name;
            AddOrderItem();
            decimal percentageTaxces = HerlperInventroyOrderItem.GetPercentageTaxces(prodcut.id);
            orderItem.Percentage_Taxes = percentageTaxces;
            HelperTaxIncluded.AddPriceToOrderItem(_price , orderItem);
            price = orderItem.Total;
        }

        private void AddOrderItem()
        {
            var inventoryOrder = new InventoryOrderitem()
            {
                Quantity = 0,
                Subtotal = prodcut.subtotal,
                Total = prodcut.price_with_tax,
                ProductId = prodcut.id,
                tax_included = prodcut.tax_included,
                TaxTotal = prodcut.tax_total,
                original_price = prodcut.price,
                _product_api = prodcut , 
                name = box.name,
            };
            orderItem = inventoryOrder;
        }

        [RelayCommand]
        private void ClickAdd()
        {
            // add new item to order
            AddToOrder();
            NaviageToHomePage();
        }

        private void AddToOrder()
        {
            orderItem.Add_Date = DateTime.Now;
            OrderHeloper.AddOrderItemToOrder(orderItem);
        }
        
        // navigate to home page 
    
        private void NaviageToHomePage()
        {
            App.helperNavigation.NavigateToHome();
        }
    }
}