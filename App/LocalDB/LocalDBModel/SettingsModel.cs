namespace App.LocalDB.LocalDBModel
{
    public class SettingsModel
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public int LangSelectedIndex { get; set; } 
        public int DiscountSelectedIndex { get; set; } 
        public int StarterSacleCode { get; set; } 
        public int Scale { get; set; } 
        public int SaclePattern { get; set; } 
        public int ScaleDightOfPrice { get; set; } 
        public int ScaleDigthOfWehight { get; set; }
        public int EndCode { get; set; }
    }
}
