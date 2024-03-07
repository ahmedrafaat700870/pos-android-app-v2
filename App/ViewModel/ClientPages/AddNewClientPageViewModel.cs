namespace App.ViewModel.ClientPages
{
    public partial class AddNewClientPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool isClient;
        [ObservableProperty]
        private string name;
        [ObservableProperty]
        private string phone;
        [ObservableProperty]
        private string email;
        [ObservableProperty]
        private string vat_registrations_number;
        [ObservableProperty]
        private string id_number;
        [ObservableProperty]
        private List<obStyle> styles;

        private  ResourceDictionary Resources;

        [ObservableProperty]
        private AddNewClientPageLang lang;

       

        public void SetResourecs(ResourceDictionary Resources )
        {
            this.Resources = Resources;
            addStyle();
        }

        private Style activeBorder;
        private Style disActiveBorder;
        private Style errorBorder;
        private Style activeEntry;
        private Style disActiveEntry;
        private Style errorEntry;

        public void LoadLang()
        {
            Lang = HerlperSettings.GetLang().AddNewClientPageLang.GetLang();
        }
        public void addStyle()
        {
            activeBorder = this.Resources["activeBorder"] as Style;
            disActiveBorder = this.Resources["disActiveBorder"] as Style;
            errorBorder = this.Resources["errorBorder"] as Style;

            activeEntry = this.Resources["activeLable"] as Style;
            disActiveEntry = this.Resources["disActiveLable"] as Style;
            errorEntry = this.Resources["errorLalble"] as Style;
        }

        public void SetStyles()
        {
            this.Styles[0].Border = activeBorder;
            this.Styles[0].Entry = activeEntry;

            this.Styles[1].Border =disActiveBorder;
            this.Styles[1].Entry = disActiveEntry;

            this.Styles[2].Border =disActiveBorder;
            this.Styles[2].Entry = disActiveEntry;

            this.Styles[3].Border =disActiveBorder;
            this.Styles[3].Entry = disActiveEntry;

            this.Styles[4].Border =disActiveBorder;
            this.Styles[4].Entry = disActiveEntry;
        }

        private readonly IPostNewCustomer _postCustomerServices;

        public AddNewClientPageViewModel(IPostNewCustomer postCustomerServices)
        {
            _postCustomerServices = postCustomerServices;
            IsClient = true;
            Name = string.Empty;
            Phone = string.Empty;
            Email = string.Empty;
            Vat_registrations_number = string.Empty;
            Id_number = string.Empty;
            this.Styles = new List<obStyle>(5);

            for (int i = 0; i < 5; i++)
                this.Styles.Add(new obStyle()) ;
        }

        [RelayCommand]
        private void CancleClick()
        {
            App.helperNavigation.NavigateToHome();
        }

        [RelayCommand]
        private async void AddClick()
        {

            bool isValid = isFormValid();
            if (!isValid || string.IsNullOrEmpty(Name))
                return;

            int status = await _postCustomerServices.PostNewUser(Name , Email , Phone , Vat_registrations_number, isClient);

            var lang = HerlperSettings.GetLang().ToastLang.GetLang();
            if(status == 0)
            {
                // data not valid 
                var mesage = lang.FalidAddingNewClientInData;
                ToastHelper.Show(mesage);
            } else if( status == 1)
            {
                // server error
                var mesage = lang.FalidAddingNewclient;
                ToastHelper.Show(mesage);
            } else
            {
                // success
                var mesage = lang.AddNewClientSuccesfuly;
                ToastHelper.Show(mesage);
                App.helperNavigation.NavigateToHome();
            }

            // Notify success
        }
        public void DefualtStyles()
        {
            foreach(obStyle style in this.Styles)
            {
                if (style.Border == errorBorder)
                    continue;

                style.Border = disActiveBorder; 
                style.Entry = disActiveEntry;
            }
        }
        public void CheckFromStyleAndSetActive(int id)
        {
            if (this.Styles[id].Border == errorBorder)
                return;

            SetStyleActive(id);

        }

        public void SetStyleActive(int id)
        {
            this.Styles[id].Border = activeBorder;
            this.Styles[id].Entry = activeEntry;
        }

        public void SetStyleDisActive(int id)
        {
            this.Styles[id].Border = disActiveBorder;
            this.Styles[id].Entry = disActiveEntry;
        }

        public void SetStyleError(int id)
        {
            this.Styles[id].Border = errorBorder;
            this.Styles[id].Entry = errorEntry;
        }


        public void checkFromData(int id)
        {
            if (Styles[0].Border is null)
                return;

            bool isValid = false;

            if (id == 0)
            {
                isValid = ValidateName();
            } 
            else if (id == 1)
            {
                isValid = ValidatePhone();
            }
            else if (id == 2)
            {
                isValid = ValidateEmail();
            }
            else if (id == 3)
            {
                isValid = ValidateVatRegistratioinsNumber();
            }
            else if (id == 4)
            {
                isValid = ValidateIdNumber();
            }

            if(!isValid)
            {
                SetStyleError(id);
            } else
            {
                SetStyleActive(id);
            }

        }

        private bool ValidateName()
        {
            bool isValid = true;
           
            if(this.Name.Length == 0 || this.Name.Length >= 50)
                isValid = false;
            if (string.IsNullOrEmpty(this.Name))
                isValid = true;

            return isValid;
        }

        private bool ValidatePhone()
        {
            bool isValid = false;

            string motif = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
            isValid = Regex.IsMatch(Phone, motif) ? true : false ;

            if(string.IsNullOrEmpty(Phone))
                isValid = true;
            return isValid;
        }
        private bool ValidateEmail()
        {
            bool isValid = false;

            var pattern = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";
            var regex = new Regex(pattern);

            isValid = regex.IsMatch(Email);

            if(string.IsNullOrEmpty(Email))
                isValid = true;


            return isValid;
        }

        private bool ValidateVatRegistratioinsNumber()
        {
            if(string.IsNullOrEmpty(Vat_registrations_number))
                return true;

            long n;
            bool isNumber = long.TryParse(Vat_registrations_number , out n);
            if (!isNumber)
                return false;

            if(string.IsNullOrEmpty(Vat_registrations_number))
                return false;
            if (Vat_registrations_number.Length == 13)
                return true;
            return false;

        }

        private bool ValidateIdNumber()
        {


            if (string.IsNullOrEmpty(Id_number))
                return true;

            long n;

            bool isNumber = long.TryParse(Id_number, out n);
            if (!isNumber)
                return false;

            if (Id_number.Length == 11)
                return true;

            return false;
        }


        private bool isFormValid()
        {
            bool valid = true;
            foreach(var style in this.Styles)
                if(style.Border == errorBorder)
                    valid = false;
            return valid;
        }

    }

    public partial class obStyle : ObservableObject
    {
        [ObservableProperty] public Style border ;
        [ObservableProperty] public Style entry;
    }
}
