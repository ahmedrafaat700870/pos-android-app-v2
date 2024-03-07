
using System.Data;

namespace App.Model
{
    public partial class SavedOrderItemModel : ObservableObject
    {
        [ObservableProperty] private int id;
        [ObservableProperty] private string from;
        [ObservableProperty] private string owner;
        [ObservableProperty] private string timeSavedOrder;
        [ObservableProperty] private string dateSavedOrder;
        private InventoryOrder order;
        private readonly ISavedOrder savedOrder;
        private Action<SavedOrderItemModel> ReomvedSavedOrder;
        private void Set_Header_Time(DateTime header_time)
        {
            DateTime end_date = DateTime.Now;
            TimeSpan time = end_date.Subtract(header_time);
            string days = time.Days.ToString();
            string hours = time.Hours.ToString();
            string min = time.Minutes.ToString();
            string second = time.Seconds.ToString();
            int lang = App.appServices.GetAppSettings().LangSelectedIndex;
            if (days != "0")
            {
                if (lang == 0)
                    From = days + " " + Lang.From[0];
                else if (lang == 1)
                    From = Lang.From[0]+ " " + days ;
            }
            else if (hours != "0")
            {
                if(lang == 0)
                    From = hours + " " + Lang.From[1];
                else if(lang == 1)
                    From = Lang.From[1] + " " + hours ;
            }
            else if (min != "0")
            {
                if (lang == 0)
                    From = min + " " + Lang.From[2];
                else if (lang == 1)
                    From = Lang.From[2] + " " + min;
            }
            else if (second != "0")
            {
                if(lang == 0)
                    From = second + " " + Lang.From[3];
                else if(lang == 1)
                    From = Lang.From[3] + " " + second ;
            }
        }

        private void Set_Footer_Timer(DateTime footer_timer)
        {
            TimeSavedOrder = footer_timer.ToString("hh:mm tt");
        }

        private void Set_Footer_Date(DateTime footer_date)
        {
            DateSavedOrder = footer_date.ToString("MM/dd/yyyy");
        }
       


        [ObservableProperty] private SavedOrderItemLang lang;

        public void LoadLang()
        {
            Lang = HerlperSettings.GetLang().SavedOrderItemLang.GetLang();
        }

        public SavedOrderItemModel(InventoryOrder order, ISavedOrder savedOrder, Action<SavedOrderItemModel> ReomvedSavedOrder)
        {             
            LoadLang();
            this.order = order;
            Id = order.Id;
            this.savedOrder = savedOrder;
            this.ReomvedSavedOrder = ReomvedSavedOrder;
            Set_Header_Time(order.SavedOrderDate);
            Set_Footer_Date(order.SavedOrderDate);
            Set_Footer_Timer(order.SavedOrderDate);
            if (order.ClientId == 0)
                Owner = Lang.Owner;
            else
            {
                var Client = App.appServices.user.customers.FirstOrDefault(x =>x.id == order.ClientId);
                Owner = Client?.name ?? Lang.Owner;
            }
        }

        private void RemoveSlif()
        {
            this.ReomvedSavedOrder.Invoke(this);
        }


        [RelayCommand]
        private async void ClickRemove()
        {
            bool deletedItems = await this.savedOrder.Remove(order.Id);
            var lang = HerlperSettings.GetLang().ToastLang.GetLang();
            if (deletedItems)
            {
                ShowToast(lang.Success);
                RemoveSlif();
            }
            else
                ShowToast(lang.Falid);
        }

        [RelayCommand]
        private async void ClickAdd()
        {
            App.order = order;
            bool deletedItems = await this.savedOrder.Remove(order.Id);
            var lang = HerlperSettings.GetLang().ToastLang.GetLang();
            if (deletedItems)
                ShowToast(lang.Success);
            else
                ShowToast(lang.Falid);
            GoHome();
            OrderHeloper.CalcOrderItemCountInOrder();
        }

        private void GoHome()
        {
            App.helperNavigation.NavigateToHome();
        }

        private void ShowToast(string message)
        {
            ToastHelper.Show(message);
        }

    }
}
