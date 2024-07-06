using App.Services.OrderPrint;

namespace App.ViewModel
{
    public partial class PaymentsPageViewModel : ObservableObject
    {

        [ObservableProperty]
        private decimal orderAmount;
        [ObservableProperty]
        private decimal taxes;
        [ObservableProperty]
        private decimal discount;
        [ObservableProperty]
        private decimal remaining;

        [ObservableProperty]
        private ObservableCollection<MethodPaymentModel> methodPayments;

        [ObservableProperty]
        private ObservableCollection<PaymentModel> payments;

        private readonly PaymentPagePopup _popup;

        private readonly CartViewModel cardViewModel;

        [ObservableProperty] private PaymentLnag lang;
        public void LoadLang()
        {
            Lang = HerlperSettings.GetLang().PaymentLnag.GetLang();
        }

        private readonly IOrderPrinter _orderPrinter;
        public PaymentsPageViewModel(CartViewModel cardViewModel , IOrderPrinter orderPrinter)
        {
            _orderPrinter = orderPrinter;
            MethodPayments = new ObservableCollection<MethodPaymentModel>();
            Payments = new ObservableCollection<PaymentModel>();
            _popup = new PaymentPagePopup();
            this.cardViewModel = cardViewModel;
            LoadLang();
        }

        private void AddGlopalPayments()
        {
            foreach (var payment in App.appServices.payments.global_types)
                MethodPayments.Add(new MethodPaymentModel(payment.name, null!, true, payment.id, _popup, this));
        }

        private void AddPaymentPayment()
        {
            foreach (var payment in App.appServices.payments.payment_types)
                MethodPayments.Add(new MethodPaymentModel(payment.name, null!, false, payment.id, _popup, this));
        }

        private void CalcOrder()
        {
            Calc_Order_Details calcOrder = new Calc_Order_Details();
            calcOrder.Set_Order(App.order);
            calcOrder.Calc_Order();
            OrderAmount = calcOrder.Get_Order_Total_After_Discount();
            Taxes = calcOrder.Get_Order_Tax_After_Discount();
            Discount = calcOrder.Get_Order_Discount_Total_Item();
            CalcRemaining();
        }

        public async Task AddPaymentToOrder()
        {
            await Task.Run(() =>
               {
                   List<PaymentsPaymentamount> orderPayments = new List<PaymentsPaymentamount>();
                   foreach (var item in this.Payments)
                   {
                       var addPayment = new PaymentsPaymentamount()
                       {
                           Created = DateTime.Now,
                           Amount = item.Amount,
                       };

                       if (item.IsGlobalType)
                           addPayment.GlobalTypeId = item.Id;
                       else
                           addPayment.PaymentTypeId = item.Id;
                       orderPayments.Add(addPayment);
                       App.order.PaymentsPaymentamounts = orderPayments;
                   }
               });
            App.order.OrderDate = DateTime.Now;
            bool isSuccess = await App.postOrder.PostOrderV2();
            if (isSuccess)
                await _orderPrinter.PrintAsync(App.order);
            App.postOrder.RessetOrder();
        }




        public void CalcRemaining()
        {
            Remaining = this.Payments.Sum(x => x.Amount) - this.OrderAmount;
        }

        public decimal GetBalance()
        {
            return this.OrderAmount - this.Payments.Sum(x => x.Amount);
        }

        public void Start()
        {
            /* MethodPayments.Clear();
            Payments.Clear();*/
            MethodPayments = new ObservableCollection<MethodPaymentModel>();
            Payments = new ObservableCollection<PaymentModel>();
            AddGlopalPayments();
            AddPaymentPayment();

            CalcOrder();
        }

    }


}
