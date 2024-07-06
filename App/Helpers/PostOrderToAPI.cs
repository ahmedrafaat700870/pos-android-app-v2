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
                Success(string.Empty);
            } else
            {
                App.order.PaymentsPaymentamounts = null!;
                var lang = HerlperSettings.GetLang().ToastLang.GetLang();
                Error(lang.PostOrderfalid);
            }
        }

        public void RessetOrder()
        {
            App.order = new InventoryOrder();
            OrderHeloper.CalcOrderItemCountInOrder();
        }

        public async Task<bool> PostOrderV2()
        {
            int status = await _postOrder.Send();

            if (status == 0) // success send order.
            {
                Success(string.Empty);
                return true;
            }
            else
            {
                var lang = HerlperSettings.GetLang().ToastLang.GetLang();
                Error(lang.PostOrderfalid);
                return false;
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
