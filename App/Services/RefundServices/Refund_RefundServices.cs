
namespace App.Services.RefundServices
{
    public class Refund_RefundServices : IDataRefundServices<InventoryRefund>
    {
        public async Task<List<InventoryRefund>> GetAll()
        {
            //throw new NotImplementedException();
            return await Task.FromResult(new List<InventoryRefund>());
        }

        public async Task<List<InventoryRefund>> GetByPage(int page)
        {
            //throw new NotImplementedException();
            return await Task.FromResult(new List<InventoryRefund>());
        }
    }
}
