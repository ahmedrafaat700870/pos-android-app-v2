namespace App.Model
{
    public partial class PaymentModel : ObservableObject
    {

        public PaymentModel(decimal amount, string paymentName , bool isGlobalType , int id)
        {
            this.PaymentName = paymentName;
            this.Amount = amount;
            IsGlobalType = isGlobalType;
            Id = id;
        }

        [ObservableProperty]
        private string paymentName;

        [ObservableProperty]
        private decimal amount;

        public bool IsGlobalType;

        public int Id;

    }
}
