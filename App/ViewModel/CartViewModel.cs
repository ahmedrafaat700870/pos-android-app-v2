﻿using App.Services.OrderPrint;

namespace App.ViewModel
{
    public partial class CartViewModel : ObservableObject
    {
        [ObservableProperty] private decimal total;
        [ObservableProperty] private decimal subtoal;
        [ObservableProperty] private decimal tax;
        [ObservableProperty] private decimal disocunt;
        [ObservableProperty] private bool isIndicatroActive = false;
        [ObservableProperty] private bool isFormVisiable = true;

        private readonly ICalacOrderServices _orderServices;
        private Order_Detalis order_detalis;

        [ObservableProperty] private CartPageLang lang;

        public void LoadLang()
        {
            Lang = HerlperSettings.GetLang().CartPageLang.GetLang();
        }

        private readonly IOrderPrinter _printer;
        public CartViewModel(ICalacOrderServices orderServices , IOrderPrinter printer)
        {
            _printer = printer;
            _orderServices = orderServices;
            this.Items = new ObservableCollection<CartItemModel>();
            LoadLang();
        }


        private void ChangeIndicatorStatus()
        {
            IsIndicatroActive = !IsIndicatroActive;
            IsFormVisiable = !IsFormVisiable;
        }


        public void LoadData()
        {
            this.Items.Clear();
            var items = App.order.InventoryOrderProducts;
            foreach (var item in items)
                this.Items.Add(new CartItemModel(item.Orderitem, item.Added_Date));
            CalcOrder();
        }

        public void CalcOrder()
        {
            order_detalis = _orderServices.Calc(App.order);
            this.Subtoal = (order_detalis.Order_Sub_Total - order_detalis.Order_Discount_Subtotal_Item);
            this.Tax = (order_detalis.Order_Tax - order_detalis.Order_Discount_Tax_Item);
            this.Disocunt = (order_detalis.Order_Discount_Total_Item);
            this.Total = (order_detalis.Order_Total - order_detalis.Order_Discount_Total_Item);
        }

        [ObservableProperty] public CartItemModel selectItem;
        [ObservableProperty] private ObservableCollection<CartItemModel> _items;

        [RelayCommand]
        private void cashPayment()
        {
            bool isOrderEmpty = CheckFromOrderEmpty();
            if (isOrderEmpty)
            {
                ToastAddItemToOrder();
                return;
            }

            var cashPayment = new PaymentsPaymentamount()
            {
                Created = DateTime.Now,
                Amount = Total,
                GlobalTypeId = App.appServices.payments.global_types[0].id,
            };
            PostOrder(cashPayment);
        }

        [RelayCommand]
        private void CriedtPayment()
        {
            bool isOrderEmpty = CheckFromOrderEmpty();
            if (isOrderEmpty)
            {
                ToastAddItemToOrder();
                return;
            }

            var cridtPayment = new PaymentsPaymentamount()
            {
                Created = DateTime.Now,
                Amount = Total,
                GlobalTypeId = App.appServices.payments.global_types[1].id,
            };
            PostOrder(cridtPayment);

        }

        private async void PostOrder(PaymentsPaymentamount payment)
        {
            App.order.PaymentsPaymentamounts.Add(payment);
            ChangeIndicatorStatus();
            App.order.OrderDate = DateTime.Now;
            bool isSuccess = await App.postOrder.PostOrderV2();

            if (isSuccess)
            {
                await _printer.PrintAsync(App.order);
                App.postOrder.RessetOrder();
            }

            ChangeIndicatorStatus();
        }

        [RelayCommand]
        private void ClickPayment()
        {
            bool isOrderEmpty = CheckFromOrderEmpty();
            if (isOrderEmpty)
            {
                ToastAddItemToOrder();
                return;
            }

            App.helperNavigation.NvigateToPaymentPage();
        }

        [RelayCommand]
        private void clearCart()
        {
            Items.Clear();
            App.order = new InventoryOrder();
            Resst();
            CalcOrder();
            OrderHeloper.CalcOrderItemCountInOrder();
        }

        [RelayCommand]
        private async void reomveItemFromCart()
        {
            if (this.SelectItem is null)
                return;
            await MoveItemByIndexToLast(this.Items.IndexOf(this.SelectItem));
            await RemoveLastElementInItems();
            reomveItemFromOrder();
            Resst();
            CalcOrder();
            OrderHeloper.CalcOrderItemCountInOrder();
        }

        private Task<bool> MoveItemByIndexToLast(int index) => Task.Run(() =>
        {
            if(!this.Items.Contains(this.Items[index])) return false;
            this.Items.Move(index , this.Items.Count -1);
            return true;
        });
        

        private Task RemoveLastElementInItems() => Task.Run(() =>
        {
            var removedItem = this.Items.LastOrDefault();
            if (this.Items.Contains(removedItem))
                this.Items.Remove(removedItem);
        });

        private void RemoveSelectedItemFromCart()
        {
            if (this.Items.Contains(this.SelectItem))
                this.Items.Remove(this.SelectItem);
        }

        private int reomveItemFromOrder()
        {
            if (this.SelectItem is null) return 0;

            var date = this.SelectItem.AddDate;
            return App.order.InventoryOrderProducts.RemoveAll(x => x.Added_Date == date);
        }

        public bool checkFromSelectedItem()
        {
            return this.SelectItem is null ? false : true;
        }

        private void Resst()
        {
            this.SelectItem = null;
        }

        private bool CheckFromOrderEmpty() => App.order.InventoryOrderProducts.Count == 0;

        private void ToastAddItemToOrder()
        {
            var message = HerlperSettings.GetLang().ToastLang.GetLang().AddItemInOrder;
            ToastHelper.Show(message);
        }
    }
}