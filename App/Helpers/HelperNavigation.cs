namespace App.Helpers
{
    public class HelperNavigation
    {
        private MainPageContentViewViewModel _vm;

        public HelperNavigation(MainPageContentViewViewModel vm)
        {
            _vm = vm;
        }


        public void NavigateToHome()
        {
            _vm.NavigateToHomePageCommand.Execute(true);
        }

        public void NavigateToAddNewClinet()
        {
            _vm.NavigateToAddNewClinetCommand.Execute(true);
        }

        public void NavigateToClientPage()
        {
            _vm.NavigateToClientPageCommand.Execute(true);
        }
        public void NvigateToCartPage()
        {
            _vm.NaviageToCardPageCommand.Execute(true);
        }

        public void NvigateToPaymentPage()
        {
            _vm.NavigateToPaymentPageCommand.Execute(true);

        }

        public void NvigateToUserPage(ContentView view)
        {
            _vm.NaviagteToView(view);
        }

        public void NvigateToUserPage(ContentPage page)
        {
            _vm.NaviagteToPage(page);
        }

    }
}
