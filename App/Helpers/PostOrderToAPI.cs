namespace App.Helpers
{
    public class PostOrderToAPI
    {

        private static  IPostOrder _postOrder;
        public PostOrderToAPI(IPostOrder postOrder) 
        {
            _postOrder = postOrder;
        }
        public async Task PostOrder()
        {
            int status  = await _postOrder.Send();

            if (status == 0) // success send order.
            {
                App.order = new InventoryOrder();
                OrderHeloper.CalcOrderItemCountInOrder();
                Success(string.Empty);
            } else
            {
                App.order.PaymentsPaymentamounts = null!;
                var lang = HerlperSettings.GetLang().ToastLang.GetLang();
                Error(lang.PostOrderfalid);
            }
        }



        private void Error(string message)
        {
            ToastHelper.Show(message);
        }

        private  void Success(string message)
        {
            SuccessOrderPage successPage = new SuccessOrderPage();
            App.helperNavigation.NvigateToUserPage(successPage);
            successPage.load();
        }


    }
}
