namespace App.ViewModel.PaymentPopup
{
    public partial class PaymentPopupPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private decimal balance;
        [ObservableProperty]
        private decimal remaing;
        [ObservableProperty]
        private decimal received;
        private string _paymentName;
        private PaymentsPageViewModel _paymentsPageViewModel;
        public PaymentPopupPageViewModel()
        {
            LoadLang();
        }
        private int id;
        private bool isGlobalType;
        [ObservableProperty] private PaymentPagePopupLang lang;
        public void LoadLang()
        {
            Lang = HerlperSettings.GetLang().PaymentPagePopupLang.GetLang();
        }
        public void Start(PaymentsPageViewModel paymentPageViewModel, string paymentName, int id, bool isGlobalType)
        {
            this.id = id;
            this.isGlobalType = isGlobalType;
            _paymentName = paymentName;
            _paymentsPageViewModel = paymentPageViewModel;
            Balance = _paymentsPageViewModel.GetBalance();
            Remaing = _paymentsPageViewModel.Remaining;
            Received = 0;
        }
        [RelayCommand]
        private void ClickCancel()
        {
            ClosePopupPage();
        }
        [RelayCommand]
        private void ClickAdd()
        {
            decimal r = 0;
            if (Received >= Balance)
            {
                r = received - balance;
                Received = Balance;
            }
            AddPayment();
            ClosePopupPage();
            if (Received >= Balance)
                _paymentsPageViewModel.AddPaymentToOrder();
            if (r > 0)
            {
                var remaning = HerlperSettings.GetLang().ToastLang.GetLang().Remaining;
                ToastHelper.Show(remaning + r.ToString("#.##"));
            }
        }
        private void AddPayment()
        {
            var payment = _paymentsPageViewModel.Payments.Where(x => x.PaymentName == this._paymentName).FirstOrDefault();
            if (payment is null)
                _paymentsPageViewModel.Payments.Add(new PaymentModel(Received, _paymentName, this.isGlobalType, this.id));
            else
                payment.Amount += Received;
            _paymentsPageViewModel.CalcRemaining();
        }
        [RelayCommand]
        private void ClickBalance()
        {
            // payment to order

            Received = Balance;
            ClickAdd();


            ClosePopupPage();
        }
        private async void ClosePopupPage()
        {
            await MopupService.Instance.PopAsync(true);
        }


    }
}
