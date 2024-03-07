namespace App.Lang
{
    public partial class LoginPageLang : ObservableObject, IUnitLang<LoginPageLang>
    {
        [ObservableProperty]
        private string welcome;
        [ObservableProperty]
        private string signInToContinue;
        [ObservableProperty]
        private string userNmae;
        [ObservableProperty]
        private string password;
        [ObservableProperty]
        private string newUser;
        [ObservableProperty]
        private string singUp;
        [ObservableProperty]
        private string singInBtn;
        [ObservableProperty]
        private string remeberMe;
        public LoginPageLang GetLang()
        {
            int lang = App.appServices.GetAppSettings().LangSelectedIndex;
            if (lang == 0)
                SetDataEN();
            else if (lang == 1)
                SetDataAR();
            return this;
        }
        private void SetDataEN()
        {
            Welcome = "Welcome";
            SignInToContinue = "Sign In To Continue";
            UserNmae = "UserName";
            Password = "Password";
            NewUser = "NewUser";
            SingUp = "SingUp";
            SingInBtn = "Singin";
            RemeberMe = "Remeber Me";
        }

        private void SetDataAR()
        {
            Welcome = "مرحبا";
            SignInToContinue = "تسجيل الدخول للمتابعة";
            UserNmae = "اسم المستخدم";
            Password = "كلمة المرور";
            NewUser = "مستخدم جديد";
            SingUp = "التسجيل";
            SingInBtn = "دخول";
            RemeberMe = "تذكرنى";
        }

    }
}
