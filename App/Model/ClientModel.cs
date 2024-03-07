namespace App.Model
{
    public partial class ClientModel : ObservableObject
    {
        private account_clients client;



        public account_clients GetClient()
        {
            return this.client;
        }

        [ObservableProperty]
        private bool isVisiable;
        public ClientModel(account_clients client)
        {
            IsVisiable = true;
            this.Id = client.id;
            this.Name = client.name;
            
            if(client.avatar is null)
                IsVisiable = false;

            this.Image = client?.avatar ?? string.Empty;
            this.Date = client.date_created;
            this.PhoneNumber = client.phone_number;
            this.client = client;
        }

        [ObservableProperty]
        private int _id;
        [ObservableProperty]
        private string _name;
        [ObservableProperty]
        private string image;
        [ObservableProperty]
        private DateTime date;
        [ObservableProperty]
        private string phoneNumber;

        [ObservableProperty]
        private double heightCiell;
    }
}
