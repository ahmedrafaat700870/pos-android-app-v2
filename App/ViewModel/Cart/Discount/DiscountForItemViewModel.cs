namespace App.ViewModel.Cart.Discount
{
    public partial class DiscountForItemViewModel : ObservableObject
    {
        [ObservableProperty]
        private Style bercentageButton;
        [ObservableProperty]
        private Style salaryButton;
        [ObservableProperty]
        private DiscountForItemLang lang;
        
        public void LoadLang()
        {
            Lang = HerlperSettings.GetLang().DiscountForItemLang.GetLang();
        }
        public ResourceDictionary Resources;
        public void SetStyle()
        {
            BercentageButton = this.Resources["active"] as Style;
            SalaryButton = this.Resources["disActive"] as Style;
        }


        private void chagneSyleSlaryAndBercentage()
        {
            if(this.BercentageButton == this.Resources["active"] as Style)
            {
                BercentageButton = this.Resources["disActive"] as Style;
                SalaryButton = this.Resources["active"] as Style;
            } else
                SetStyle();
        }


        private bool isDiscountBercentage ;
        private Action _calcOrder;
        private CartItemModel _cartItem;
        private readonly Discount_For_Order_Item _discount_for_order_item;
        private Calc_Order_item_Detalis order_item_delies;
        public DiscountForItemViewModel(CartItemModel cartItem , Action calcOrder)
        {
            order_item_delies = new Calc_Order_item_Detalis();
            _calcOrder = calcOrder;
            _discount_for_order_item = new Discount_For_Order_Item() ;
            _cartItem = cartItem;
            _discount_for_order_item.SetOrderItem(_cartItem.orderItem);
            Discount = string.Empty;
            isDiscountBercentage = true;
            LoadLang();
        }


        [RelayCommand]
        private void ClickDiscountBercnaget()
        {
            chagneSyleSlaryAndBercentage();
            isDiscountBercentage = true;
        }

        [RelayCommand]
        private void ClickDiscountSalary()
        {
            chagneSyleSlaryAndBercentage();
            isDiscountBercentage = false;
        }


        [RelayCommand]
        private void addClick()
        {
            decimal discount = 0;
            bool isSuccessConvert = decimal.TryParse(Discount, out discount);
            if (isSuccessConvert)
            {
                bool isDisocuntForTotal = HerlperSettings.IsDiscountForTotal();
                decimal calcolatedDiscount ;
                bool isAddedDiscount = this.isDiscountBercentage ? AddDiscountBercentage(discount, isDisocuntForTotal ,out calcolatedDiscount) : AddDiscountSalary(discount, isDisocuntForTotal , out calcolatedDiscount);
                if(isAddedDiscount)
                {
                    calcolatedDiscount = GetDiscount(isDisocuntForTotal);
                    _cartItem.Discount_percentage = (_cartItem.orderItem.DiscountInPercentage * 100).ToString(HelperFormate.GetFromateNumber()) + "%";
                    //_cartItem._ShowDiscount();
                    _cartItem.Disocunt = calcolatedDiscount.ToString(HelperFormate.GetFromateNumber()) + HelperFormate.GetSinge();
                    _cartItem.ShowDiscount = (calcolatedDiscount > 0 || _cartItem.orderItem.DiscountInPercentage > 0) ? true : false;
                    _calcOrder.Invoke();
                }
            } else
            {
                // add error
            }
            
            ClosePopup();
        }
        [RelayCommand]
        private void cancleClick()
        {
            ClosePopup();
        }

        [ObservableProperty]
        private string discount;

        private bool AddDiscountBercentage(decimal discount, bool isDiscountForTotal , out decimal calcolatgedDiscount )
        {
            calcolatgedDiscount = 0;
            bool isSuccessAddedDiscount = false;
            try
            {
                calcolatgedDiscount = _discount_for_order_item.Add_Discount_Bercentage(discount , App.order , isDiscountForTotal );
                isSuccessAddedDiscount = true;
            }
            catch
            {
                isSuccessAddedDiscount = false;
            }

            return isSuccessAddedDiscount;
        }

        private bool AddDiscountSalary(decimal discount, bool isDiscountForTotal, out decimal calcolatgedDiscount)
        {
            calcolatgedDiscount = 0;
            bool isSuccessAddedDiscount = false;
            try
            {
                calcolatgedDiscount = _discount_for_order_item.Add_Discount_Salary(this.order_item_delies, discount, App.order, isDiscountForTotal);
                isSuccessAddedDiscount = true;
            }
            catch
            {
                isSuccessAddedDiscount = false;
            }

            return isSuccessAddedDiscount;
        }

        private  void ClosePopup()
        {
           MopupService.Instance.PopAsync();
        }



        private decimal GetDiscount(bool isDiscountForTotal)
        {
            decimal totalDiscount = 0;
            order_item_delies.Set_Order(App.order);
            order_item_delies.Set_Order_Item(_cartItem.orderItem);
            order_item_delies.Calc_Order_Item(isDiscountForTotal);
            totalDiscount =  order_item_delies.Get_Order_Item_Disocunt_Total();
            return totalDiscount;
        }
    }
}
