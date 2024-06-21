
namespace App.Services.PrinterServices.OrderPrinter
{
    public interface IPrinter
    {
        Task PrintAsync(PrinterModel model);
    }
}
