namespace App.Services.RefundServices
{
    public interface IRefundServices 
    {
        Task AddRefund(InventoryOrder order);
    }
}
