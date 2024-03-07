namespace App.Services.RefundServices
{
    public class Refund_OrderServices : IDataRefundServices<InventoryOrder>
    {
        public async Task<List<InventoryOrder>> GetAll()
        {
            //throw new NotImplementedException();
            return await Task.FromResult(new List<InventoryOrder>());
        }

        public async Task<List<InventoryOrder>> GetByPage(int page)
        {
            //throw new NotImplementedException();
            return await Task.FromResult(new List<InventoryOrder>());
        }
    }
}
