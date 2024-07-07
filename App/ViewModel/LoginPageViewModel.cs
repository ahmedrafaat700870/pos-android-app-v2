namespace App.ViewModel
{
    public partial class LoginPageViewModel : ObservableObject
    {
        private readonly ILoginServices _loginServices;
        private Action InterNetConnectonError;
        private Action UsernameOrPasswrodError;
        [ObservableProperty]
        private bool isIndicatroActive;
        [ObservableProperty]
        private bool isLoginVisiable;
        private LoginPage loginPage;
        public void SetLoginPage(LoginPage loginPage)
        {
            this.loginPage = loginPage;
        }
        [ObservableProperty]
        private LoginPageLang lang;
        public void LoagLang()
        {
            Lang = HerlperSettings.GetLang().LoginPageLang.GetLang();
        }
        [ObservableProperty] private bool isRememberMeChecked = false;
        private async Task ChangeStatusLogin()
        {
            IsIndicatroActive = !IsIndicatroActive;
            IsLoginVisiable = !IsLoginVisiable;
        }
        private MainPageContentView mainPage;
        private readonly IApplicationData _applicationData;
        public LoginPageViewModel(ILoginServices loginServices, MainPageContentView mainPage, IApplicationData applicationData)
        {
            IsIndicatroActive = false;
            IsLoginVisiable = true;
            Username = string.Empty;
            Password = string.Empty;
            _loginServices = loginServices;
            this.mainPage = mainPage;
            LoagLang();
            _applicationData = applicationData;
            //CheckFromLastUserRemeberMe();

            CheckFromUserRemeberMeV2();


        }


        private void ReomveDataUser()
        {
            App.DataUserRemeberMe.ReomveLastUser();
        }

        private async void CheckFromUserRemeberMeV2()
        {
            var rememberMe = await SecureStorage.Default.GetAsync(ConstantLogin.RememberMe) ?? string.Empty; // Preferences.Default.Get<bool>(ConstantLogin.RememberMe, false);
            if (!string.IsNullOrEmpty(rememberMe))
            {
                this.Username = await SecureStorage.Default.GetAsync(ConstantLogin.UserName) ?? string.Empty;
                this.Password = await SecureStorage.Default.GetAsync(ConstantLogin.Password) ?? string.Empty;
                this.IsRememberMeChecked = true;
                Login();
            }
        }

        private void CheckFromLastUserRemeberMe()
        {

            if (!App.DataUserRemeberMe.isContainsDataUser()) return;
            var DataUser = App.DataUserRemeberMe.DataUser;
            IsRememberMeChecked = App.DataUserRemeberMe.DataUser.rememberMe;
            if (DataUser.rememberMe)
            {
                Username = DataUser.userName;
                Password = DataUser.password;
                Login();
            }
        }

        public void UpdateDataLastUser()
        {
            var DataUser = App.DataUserRemeberMe;
            if (IsRememberMeChecked)
            {
                DataUser.SetData(Username, Password, IsRememberMeChecked);
                DataUser.SaveData();
            } else 
            {
                DataUser.ReomveLastUser();
            }
        }

        [RelayCommand]
        private async void ClickNewUser()
        {
            string url = "http://onepos.cloud/join#";
            try
            {
                Uri uri = new Uri(url);
                await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception ex) 
            {
                // An unexpected error occurred. No browser may be installed on the device.
            }
        }
        [ObservableProperty]
        private string username;
        [ObservableProperty]
        private string password;
        [ObservableProperty]
        private string errorMessage;
        [RelayCommand]
        private async void Login()
        {
            // check from internet .
            try
            {
                await ChangeStatusLogin();
                if (!await CheckFromInternetConnectionV2())
                {
                    InterNetConnectonError.Invoke();
                    await ChangeStatusLogin();
                    return;
                }


                if (await CheckFromUserNameOrPassowrdIsEmpty())
                {
                    UsernameOrPasswrodError.Invoke();
                    await ChangeStatusLogin();
                    return;
                }


                if(this.IsRememberMeChecked)
                {
                    await SecureStorage.Default.SetAsync(ConstantLogin.RememberMe , ConstantLogin.RememberMe);
                    await SecureStorage.Default.SetAsync(ConstantLogin.UserName , Username);
                    await SecureStorage.Default.SetAsync(ConstantLogin.Password , Password);
                }

                //UpdateDataLastUser();



                var user = await _loginServices.Login(Username, Password);
                if (user is not null)
                {
                    AddUserData(user);
                    _applicationData.GetData();
                    mainPage.addData();
                    await mainPage.LoadDataHome();
                    await Shell.Current.Navigation.PushAsync(mainPage);
                }
                else
                    this.UsernameOrPasswrodError.Invoke();
            }
            catch (System.FormatException ex)
            {
                await Shell.Current.Navigation.PushAsync(mainPage);
            }


            await ChangeStatusLogin();

        }
        public void SetActions(Action internet, Action username_or_password)
        {
            this.InterNetConnectonError = internet;
            this.UsernameOrPasswrodError = username_or_password;
        }
        private async Task<bool> CheckFromUserNameOrPassowrdIsEmpty()
        {
            return await Task.Run(() =>
            {
                bool isEmpty = false;
                if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
                    isEmpty = true;
                return isEmpty;
            });
        }
        private async Task<bool> CheckFromInternetConnection()
        {
            return await Task.Run(() =>
            {
                try
                {
                    using (var client = new System.Net.WebClient())
                    using (client.OpenRead("http://www.google.com"))
                    {
                        return true;
                    }
                }
                catch
                {
                    return false;
                }
            });


        }


        private  Task<bool> CheckFromInternetConnectionV2()
        {
            return Task.Run(() =>
            {
                NetworkAccess accessType = Connectivity.Current.NetworkAccess;
                return (accessType == NetworkAccess.Internet);
            });
            

        }
        
        private void AddUserData(user_model user)
        {
            App.appServices.currentUser = user;
            App.appServices.userToken = user.token;
        }
    }


}
