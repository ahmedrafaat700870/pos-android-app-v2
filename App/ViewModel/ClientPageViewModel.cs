namespace App.ViewModel
{
    public partial class ClientPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<ClientModel> clients;

        [ObservableProperty]
        private ClientModel selectedClient;

        [ObservableProperty]
        private string search;


        [ObservableProperty]
        private ClientPageLang lang;

        [ObservableProperty] private bool isListViewVisable;
        [ObservableProperty] private bool isActivatorVisable;
        [RelayCommand]
        private void CancleClick()
        {
            App.helperNavigation.NavigateToHome();
        }
        [RelayCommand]
        private void AddClick()
        {
            App.helperNavigation.NavigateToAddNewClinet();
        }

        public void LoadLang()
        {
            Lang = HerlperSettings.GetLang().ClientPageLang.GetLang();
        }

        private readonly IApplicationData clientData;
        private void ChageStatusActivator()
        {
            IsListViewVisable = !IsListViewVisable;
            IsActivatorVisable = !IsActivatorVisable;
        }
        public ClientPageViewModel(IApplicationData applicationData)
        {
            IsActivatorVisable = false;
            IsListViewVisable = true;
            clientData = applicationData;
            clients = new ObservableCollection<ClientModel>();
            LoadLang();
        }

        public async Task Start()
        {
            clearCart();
            clearSelectedClient();

            var users = App.appServices?.user?.customers ?? new List<account_clients>();
            foreach (var user in users)
                Clients.Add(new ClientModel(user));
        }

        private void clearCart()
        {
            if (Clients is null)
                Clients = new ObservableCollection<ClientModel>();
            Clients.Clear();
        }

        private void clearSelectedClient()
        {
            SelectedClient = null;
        }

        public async Task SeachForClient()
        {

            if (string.IsNullOrEmpty(Search))
                await Start();

            this.Clients = this.Clients
                .Where(x => x.Id.ToString().Contains(Search ?? string.Empty)
                || x.Date.ToString().Contains(Search ?? string.Empty)
                || x.Name.Contains(Search ?? string.Empty)
                || x.PhoneNumber.Contains(Search ?? string.Empty))
                .ToObservableCollection();
        }

        public void AddClientToOrder()
        {
            var client = this.SelectedClient.GetClient();
            App.order.ClientId = client.id;
            App.GetMainPage().NavigateToHomePageCommand.Execute(true);
        }

        [RelayCommand]
        private async void ClickReferess()
        {

            ChageStatusActivator();
            try
            {
                await (clientData as IClientData).GetDataUser();
                await Start();
            }
            catch (Exception ex) {}
            ChageStatusActivator();
        }

    }
}
