namespace App.ViewModel.Cart.Discount
{
    public partial class DiscountForIOrderViewModel : ObservableObject
    {
        private Action _calcOrder;
        public ResourceDictionary Resorces;
        private bool isDiscountBercentage;
        private  Discount_Order_Services discount_for_order;

        [ObservableProperty]
        private Style bercentageButton;
        [ObservableProperty]
        private Style salaryButton;

        [ObservableProperty]
        private DiscountForOrderLang lang;

        public void LoadLnag()
        {
            Lang = HerlperSettings.GetLang().DiscountForOrderLang.GetLang();
        }
        public void SetStyles()
        {
            if(this.Resorces is not null)
            {
                BercentageButton = (this.Resorces["active"] as Style)!;
                SalaryButton = (this.Resorces["disActive"] as Style)!;
            }
        }

        public DiscountForIOrderViewModel(Action calcOrder)
        {
            _calcOrder = calcOrder;
            this.discount_for_order = new Discount_Order_Services();
            this.isDiscountBercentage = true;
            LoadLnag();
        }

        [ObservableProperty]
        private string discount = string.Empty;

        [RelayCommand]
        private void clickBercentage()
        {
            ChangeStylesButtonAndSalary();
            this.isDiscountBercentage = true;
        }

        [RelayCommand]
        private void clickSalary()
        {
            ChangeStylesButtonAndSalary();
            this.isDiscountBercentage = false;
        }

        private void ChangeStylesButtonAndSalary()
        {
            if(this.BercentageButton == this.Resorces["active"] as Style)
            {
                this.BercentageButton = (this.Resorces["disActive"] as Style)!;
                this.SalaryButton = (this.Resorces["active"] as Style)!;
            } else
            {
                this.BercentageButton = (this.Resorces["active"] as Style)!;
                this.SalaryButton = (this.Resorces["disActive"] as Style)!;
            }
        }

        [RelayCommand]
        private void addClick()
        {
            decimal _disocunt = 0;
            bool isSuccessConverted = decimal.TryParse(Discount ?? string.Empty, out _disocunt);
           
            if (!isSuccessConverted) // add error convert here .
                return;

            bool isDisocuntForTotal = HerlperSettings.IsDiscountForTotal();

            bool isAddedDiscount = isDiscountBercentage ? AddDiscountBercentage(_disocunt, isDisocuntForTotal) : AddDiscountSalary(_disocunt, isDisocuntForTotal);

            if(isAddedDiscount)
            {
                _calcOrder.Invoke();
            } else
            {
                // error here .
            }


            ClosePopup();

        }

        [RelayCommand]
        private void cancleClick()
        {
            ClosePopup();
        }

        private bool AddDiscountBercentage(decimal discount , bool isDiscountForTotal)
        {
            bool isSuccessAddedDiscount = false;
            try
            {
                discount_for_order.Add_Discount_Bercentage(discount, App.order, isDiscountForTotal);
                isSuccessAddedDiscount = true;
            }
            catch
            {
                isSuccessAddedDiscount = false;
            }

            return isSuccessAddedDiscount;
        }

        private bool AddDiscountSalary(decimal discount, bool isDiscountForTotal)
        {
            bool isSuccessAddedDiscount = false;
            try
            {
                discount_for_order.Add_Discount_Salary( new Calc_Order_Details() , discount, App.order, isDiscountForTotal);
                isSuccessAddedDiscount = true;
            }
            catch
            {
                isSuccessAddedDiscount = false;
            }

            return isSuccessAddedDiscount;
        }
        private void ClosePopup()
        {
            MopupService.Instance.PopAsync();
        }
    }
}
