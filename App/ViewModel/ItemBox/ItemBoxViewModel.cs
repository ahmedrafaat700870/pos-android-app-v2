namespace App.ViewModel.ItemBox
{
    public partial class ItemBoxViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<BoxModel> itemBoxs;

        private inventory_prodcut prodcut;
        public ItemBoxViewModel(inventory_prodcut prodcut) 
        {
            this.prodcut = prodcut;

            ItemBoxs = new ObservableCollection<BoxModel>();
            
        }

        [ObservableProperty] private ItemBoxPageLang lang;

        public void LoadLang()
        {
            Lang = HerlperSettings.GetLang().ItemBoxPageLang.GetLang();
        }
        public void Loading()
        {
            Clear();
            LoadData();
        }

        private void Clear()
        {
            this.ItemBoxs.Clear();
        }
        private void LoadData()
        {
            var dataBox = App.appServices.products.item_box.Where(x =>x.product == prodcut.id);

            var mainBox = new ItemBoxes() { count = 1 , name = this.prodcut.name , unit_of_price = this.prodcut.price , product = this.prodcut.id , image = this.prodcut.image , created = DateTime.Now  };
            ItemBoxs.Add(new BoxModel(mainBox, this.prodcut));
            foreach (var box in dataBox)
                ItemBoxs.Add(new BoxModel(box , this.prodcut) );
        }


    }
}
