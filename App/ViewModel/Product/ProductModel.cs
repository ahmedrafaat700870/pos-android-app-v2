namespace App.ViewModel.Product
{
    public partial class ProductModel : ObservableObject
    {

        [ObservableProperty]
        private string name;
        [ObservableProperty]
        private decimal qty;
        [ObservableProperty]
        private decimal totalPrice;

        [ObservableProperty]
        private string image;

        [ObservableProperty]
        private decimal price;

        public inventory_prodcut prodcut;

        public DateTime AddDate;

        public ProductModel(inventory_prodcut prodcut)
        {
            this.prodcut = prodcut;
            Name = prodcut.name ?? string.Empty;
            Qty = prodcut.quantity;
            TotalPrice = prodcut.price_with_tax;
            Image = prodcut.image ?? string.Empty;
            Price = prodcut.price;
            AddDate = DateTime.Now;
        }

        
        /// <summary>
        /// add or update product in cart 
        /// </summary>
        /// 


        [RelayCommand]
        private void ClickAdd()
        {

            bool containsBox = App.appServices.products.item_box.Any(x => x.product == this.prodcut.id);

            if (containsBox)
            {
                // load data box
                var vm = new ItemBoxViewModel(prodcut);
                var boxPage = new ItemBoxPasge(vm);
                App.helperNavigation.NvigateToUserPage(boxPage);
                
            }
            else OrderHeloper.AddDataProductToCart(prodcut , AddDate);

        }

       

       
    }
}
