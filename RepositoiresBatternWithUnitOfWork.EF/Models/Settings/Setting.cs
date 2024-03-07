using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoiresBatternWithUnitOfWork.EF.Models.Settings
{
    public class Setting
    {
        public Setting()
        {
            PrinterSettings = new PrinterSettings();
        }
        public int Id { get; set; }
        public string Discount_Type { get; set; } = "total_price"; //total_price , orignal_price = before tax
        public bool Scales_Is_Price { get; set; } = false;
        public string Adding_Type { get; set; } = "price"; // weghit
        public int Scales_Degit_Type { get; set; } = 13;
        public int Sacles_Perfix_Degit { get; set; } = 2;
        public string Scales_Perfix { get; set; } = "22";
        public int Scales_Code { get; set; } = 5;
        public int Scles_Dot_Price { get; set; } = 3; // handerd ....
        public int Scales_Price { get; set; } = 5;
        public int Scales_Weghit { get; set; } = 5;
        public int Scles_Dot_Weghit { get; set; } = 3; // handerd ....
        public int Scales_Checker_Degits { get; set; } = 1;
        public string Lang { get; set; } = "EN";
        public DateTime Setting_Date { get; set; }

        public virtual PrinterSettings PrinterSettings { get; set; }
    }
}
