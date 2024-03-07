namespace App.Model
{
    public partial class MethodPaymentModel : ObservableObject
    {
        [ObservableProperty]
        private string paymentName;
        [ObservableProperty]
        private string paymentIcon;
        [ObservableProperty]
        private bool showIcon;


        public int Id;
        public bool IsGlobalType;


        private readonly PaymentPagePopup _paymentPopup;
        private PaymentsPageViewModel _paymentPageViewModel;


        public MethodPaymentModel(string _paymentName , string _paymentIcon , bool isGlobalType , int id , PaymentPagePopup paymentPopup , PaymentsPageViewModel paymentPageViewModel) 
        {
            IsGlobalType = isGlobalType;
            Id = id;
            if(string.IsNullOrEmpty(_paymentIcon))
            {
                PaymentIcon = string.Empty;
                ShowIcon = false;
            } else
            {
                ShowIcon = true;
                PaymentIcon = _paymentName;
            }
            _paymentPopup = paymentPopup;
            PaymentName = _paymentName;
            _paymentPageViewModel = paymentPageViewModel;
        }

        [RelayCommand]
        private void ClickMethodPayment()
        {
            _paymentPopup.Start(_paymentPageViewModel, PaymentName , Id , IsGlobalType);
            
            MopupService.Instance.PushAsync(_paymentPopup , true);
        }

    }
}
