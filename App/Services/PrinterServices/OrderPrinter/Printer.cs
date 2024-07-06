using XamarinESCUtils.Model;
using XamarinESCUtils.Platforms.Common;

namespace App.Services.PrinterServices.OrderPrinter
{
    public class Printer : IPrinter
    {

        private const int line = 1;
        private IBlueToothService _blueToothService;
        private IEscUtil _ecUtil;
       

        public Task PrintAsync(PrinterModel model)
        {

            return Task.Run(() =>
            {
                _blueToothService = App.GetBlueToothService();
                _ecUtil = App.GetEscUtil();

                var printerData = JsonConvert.DeserializeObject<BluetoothInfo>(App.appServices.GetAppSettings().Printer);
                bool isSuccess = _blueToothService.ConnectBlueTooth(printerData.Adress);
                if (isSuccess)
                {
                    DrowHeader(model);
                    DrowBody(model);
                    DrowFooter(model);
                    EndPrinting();
                }
            });

        }

        private void DrowHeader(PrinterModel model)
        {
            InitPrinter();
            _blueToothService.SendData(Encoding.ASCII.GetBytes("\x1D\x21\x21"));
            //_blueToothService.SendData(_ecUtil.BoldOn());
            SimpleNextLine(2);
            DrowLine();
            DrowHeaderItem(model.OrderType);
            DrowLine();
            DrowHeaderItem("invoice :" , model.OrderId.ToString());
            
            DrowHeaderItem("date :", model.OrderTime.ToShortDateString());
           
            DrowHeaderItem("time :", model.OrderTime.ToShortTimeString());
           
            DrowHeaderItem("casher :", model.CasherName);
            if(!string.IsNullOrEmpty(model.clientName))
                DrowHeaderItem("client :" , model.clientName );
           /* 
            SimpleNextLine(1);
            DrowHeaderItem("brunch :", model.PrunchName);
           */
        }

        private void DrowBody(PrinterModel model)
        {
            DrowLine();
            DrowHeaderItem("invoice");
            DrowLine();
            string itemName = GetItemAfterAddingSpace("name", 8);

            string price = GetItemAfterAddingSpace("unit", 4);

            string qty = GetItemAfterAddingSpace("qty", 3);

            string total = GetItemAfterAddingSpace("price", 5);

            _blueToothService.SendData(Encoding.ASCII.GetBytes($"| {itemName} | {price} | {qty} | {total} |"));
            foreach (var item in model.Items)
            {
                DrowLine();
                
                DrowBodyItem(item);
                if(item.discount is not null && item.discount.DiscountAmount > 0)
                    DrowHeaderItem(item.discount.DiscountType, item.discount.DiscountAmount.ToString("0.00"));
            }

        }

        private void DrowFooter(PrinterModel model)
        {
            DrowLine();
            DrowHeaderItem("total :", model.total.ToString("0.00"));
            
            DrowHeaderItem("subtotal :", model.subTotal.ToString("0.00"));
      
            DrowHeaderItem("tax :", model.tax.ToString("0.00"));
            if(model.totalDiscount > 0)
                DrowHeaderItem("total discount :", model.totalDiscount.ToString("0.00"));

            DrowHeaderItem("taxs");
            foreach (var t in model.taxs)
                DrowHeaderItem($"{t.Key}", $"{t.Value.Amount.ToString("0.00")}");
            DrowHeaderItem("payment");
            foreach (var p in model.payments)
                DrowHeaderItem($"{p.Value.Name}", $"{p.Value.Amount.ToString("0.00")}");

            DrowLine();
            SimpleNextLine(1);
            DrowQrCode(model.qrCode);
        }

        private void EndPrinting()
        {
            _blueToothService.SendData(Encoding.ASCII.GetBytes("\n\n\n"));
            _blueToothService.SendData(Encoding.ASCII.GetBytes("\x1D\x56\x00")); // Full cut
        }


        private void DrowLine()
        {
            _blueToothService.SendData(Encoding.ASCII.GetBytes("---------------------------------")); // 33
        }

        private void InitPrinter()
        {
            _blueToothService.SendData(_ecUtil.SetCodeSystem(_ecUtil.CodeParse(20))); // utf-8
        }

        private void CahgeFontSize(string fontsize)
        {
            _blueToothService.SendData(Encoding.ASCII.GetBytes(fontsize)); // \x1D\x21\x10 fontSize 14
        }
        private void NextLine(int lineCount)
        {
            for (int i = 0; i < lineCount; i++)
            {
                _blueToothService.SendData(_ecUtil.NextLine(1));
                _blueToothService.SendData(Encoding.ASCII.GetBytes("|                               |")); // 33
            }
        }
        private void SimpleNextLine(int l)
        {
            _blueToothService.SendData(_ecUtil.NextLine(l));
        }
        private void DrowBodyItem(OrderItems item)
        {
            string itemName = GetItemAfterAddingSpace(item.ItemName , 7);
            
            string price = GetItemAfterAddingSpace(item.ItemPrice.ToString("0.00") , 4);

            string qty = GetItemAfterAddingSpace(item.qty.ToString("0.00") , 3);

            string total = GetItemAfterAddingSpace(item.total.ToString("0.00") , 6);

            _blueToothService.SendData(Encoding.ASCII.GetBytes($"| {itemName} | {price} | {qty} | {total}| ")); // 33
        }
        private void DrowHeaderItem(string l , string r)
        {
            string left = GetItemAfterAddingSpace(l, 13); 
            string right = GetItemAfterAddingSpace(r, 13);
            _blueToothService.SendData(Encoding.ASCII.GetBytes($"| {left} | {right} |")); // 33
        }
        private void DrowHeaderItem(string i)
        {
            string item = GetItemAfterAddingSpace(i, 31);
            _blueToothService.SendData(Encoding.ASCII.GetBytes($"|{item}|"));
        }
        private string GetItemAfterAddingSpace(string orginalItemName , int space)
        {
            string itemName;
            if (orginalItemName.Length > space)
                itemName = orginalItemName.Substring(0, space);
            else
            {
                itemName = orginalItemName;
                bool left = true;
                for (int i = 0; i < space - orginalItemName.Length; i++)
                {
                    if (left)
                        itemName = itemName + " ";
                    else
                        itemName = " " + itemName;
                    left = !left;
                }
            }
            return itemName;
        }

        private void DrowQrCode(string qr)
        {
            _blueToothService.SendData(_ecUtil.AlignCenter());
            _blueToothService.SendData(_ecUtil.GetPrintQrCode(qr, 8, 8));
        }


    }
}
