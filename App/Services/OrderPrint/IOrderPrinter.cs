
namespace App.Services.OrderPrint
{
    public interface IOrderPrinter
    {
        Task PrintAsync(InventoryOrder order);
    }
}
