using App.Services.CalcOrder.bl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.CalcOrder
{
    public interface ICalacOrderServices
    {
        Order_Detalis Calc(InventoryOrder order);
    }
}
