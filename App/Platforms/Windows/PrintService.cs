namespace App.Services.PrinterServices
{
    public partial class PrintService
    {
        public partial IList<string> GetDeviceList() => null;
        private partial async Task ConnectToPrinter(string printername) { }
        public partial async Task Print(string textToPrint, string printerName, object qrCode) { }
    }
}
