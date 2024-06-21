using Android.Bluetooth;
using Java.Util;

namespace App.Services.PrinterServices
{
    public partial class PrintService
    {
        private BluetoothAdapter bluetoothAdapter = null!;
        private BluetoothDevice printerDevice = null!;
        private BluetoothSocket bluetoothSocket = null!;

        public partial IList<string> GetDeviceList()
        {

            try
            {
                using (BluetoothAdapter bluetoothAdapter = BluetoothAdapter.DefaultAdapter)
                {
                    var btdevice = bluetoothAdapter?.BondedDevices.Select(i => i.Name).ToList();
                    return btdevice;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return null;
        }

        public partial async Task Print(string textToPrint, string printerName, object qrCode)
        {

            bluetoothAdapter = BluetoothAdapter.DefaultAdapter;
            if (bluetoothAdapter == null)
            {
                throw new Exception("Bluetooth not supported on this device");
                //return false; // Bluetooth not supported
            }

            if (!bluetoothAdapter.IsEnabled)
                throw new Exception("Bluetooth is not enabled");

            foreach (BluetoothDevice device in bluetoothAdapter.BondedDevices)
            {
                if (device.Name == printerName)
                {
                    printerDevice = device;
                    break;
                }
            }

            if (printerDevice == null)
            {
                throw new Exception("Printer not found");
                //return false; // Printer not found
            }

            try
            {
                bluetoothSocket = printerDevice.CreateRfcommSocketToServiceRecord(UUID.FromString("00001101-0000-1000-8000-00805F9B34FB"));
                await bluetoothSocket.ConnectAsync();
                //return true; // Connected successfully
            }
            catch (Exception ex)
            {
                return;
                //return false; // Error connecting
            }

            if (bluetoothSocket == null)
            {
                return;
                //return false; // Not connected to printer
            }

            try
            {
                Stream outputStream = bluetoothSocket.OutputStream;
                byte[] bytes = System.Text.Encoding.ASCII.GetBytes(textToPrint);

                //await outputStream.WriteAsync(bytes, 0, bytes.Length);

                // start print qrcode
                MemoryStream stream = new MemoryStream();
                byte[] buffer = qrCode as byte[];
                stream.Write(buffer, 0, buffer.Length);
                var qrbytes = stream.ToArray();
                await outputStream.WriteAsync(qrbytes, 0, qrbytes.Length);
                // end print qrcode


                await outputStream.FlushAsync();
                //return true; // Print successful
            }
            catch (Exception ex)
            {
                return;
                //return false; // Error printing
            }
            if (bluetoothSocket != null)
            {
                try
                {
                    bluetoothSocket.Close();
                }
                catch (Exception ex) { }
                bluetoothSocket = null;
            }


        }


        private partial async Task ConnectToPrinter(string printername) {}

      


    }

    
   
}
