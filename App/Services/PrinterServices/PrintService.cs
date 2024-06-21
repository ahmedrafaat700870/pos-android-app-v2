
namespace App.Services.PrinterServices
{
    public partial class PrintService
    {
        public partial IList<string> GetDeviceList();
        private partial Task ConnectToPrinter(string printername);
        public partial Task Print(string textToPrint, string printerName, object qrCode);
    }
}
