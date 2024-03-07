namespace App.Helpers
{
    public class ScalesHelper
    {
        private int GetScalesType()
        {
            return  App.appServices.GetAppSettings().Scale;
        }
        private int GetScalesPattern()
        {
            return App.appServices.GetAppSettings().SaclePattern;
        }
        public int GetScaleTyep()
        {
            return GetScalesType();
        }
        public int GetDecimalPoint()
        {
            return App.appServices.GetAppSettings().ScaleDightOfPrice;
        }
        public int GetDecimalPointWeight()
        {
            return App.appServices.GetAppSettings().ScaleDigthOfWehight;
        }
        public Scale GetScaleSettings()
        {
            Scale s = new Scale();
            if (GetScalesType() == 13)
            {
                s.sacleTyep = 13;
                if (GetScalesPattern() == 1)
                {
                    s.isPrice = true;
                    s.start = 1;
                    s.code = 5;
                    s.price = 6;
                    s.end = 1;

                }
                else if (GetScalesPattern() == 2)
                {
                    s.isPrice = true;
                    s.start = 1;
                    s.code = 6;
                    s.price = 5;
                    s.end = 1;
                }
                else if (GetScalesPattern() == 3)
                {
                    s.isPrice = true;
                    s.start = 2;
                    s.code = 4;
                    s.price = 6;
                    s.end = 1;

                }
                else if (GetScalesPattern() == 4)
                {

                    s.isPrice = true;
                    s.start = 2;
                    s.code = 5;
                    s.price = 5;
                    s.end = 1;

                }
                else if (GetScalesPattern() == 5)
                {
                    s.isPrice = true;
                    s.start = 2;
                    s.code = 6;
                    s.price = 4;
                    s.end = 1;

                }
                else if (GetScalesPattern() == 6)
                {
                    s.isPrice = false;
                    s.start = 1;
                    s.code = 5;
                    s.weigth = 6;
                    s.end = 1;

                }
                else if (GetScalesPattern() == 7)
                {

                    s.isPrice = false;
                    s.start = 1;
                    s.code = 6;
                    s.weigth = 5;
                    s.end = 1;

                }
                else if (GetScalesPattern() == 8)
                {
                    s.isPrice = false;
                    s.start = 2;
                    s.code = 4;
                    s.weigth = 6;
                    s.end = 1;

                }
                else if (GetScalesPattern() == 9)
                {

                    s.isPrice = false;
                    s.start = 2;
                    s.code = 5;
                    s.weigth = 5;
                    s.end = 1;
                }
                else if (GetScalesPattern() == 10)
                {
                    s.isPrice = false;
                    s.start = 2;
                    s.code = 6;
                    s.weigth = 4;
                    s.end = 1;
                }
            }
            else if (GetScalesType() == 18)
            {
                s.sacleTyep = 18;

                if (GetScalesPattern() == 1)
                {
                    s.start = 1;
                    s.code = 5;
                    s.price = 6;
                    s.weigth = 5;
                    s.end = 1;
                } else if (GetScalesPattern() == 2)
                {
                    s.start = 1;
                    s.code = 6;
                    s.price = 5;
                    s.weigth = 5;
                    s.end = 1;
                }
                else if (GetScalesPattern() == 3)
                {
                    s.start = 2;
                    s.code = 4;
                    s.price = 6;
                    s.weigth = 5;
                    s.end = 1;
                }
                else if (GetScalesPattern() == 4)
                {
                    s.start = 2;
                    s.code = 5;
                    s.price = 5;
                    s.weigth = 5;
                    s.end = 1;
                }
                else if (GetScalesPattern() == 5)
                {
                    s.start = 2;
                    s.code = 6;
                    s.price = 4;
                    s.weigth = 5;
                    s.end = 1;
                }
            }
            return s;
        }
    }
    public struct Scale
    {
        public int sacleTyep;
        public bool isPrice;
        public int start;
        public int code;
        public int weigth;
        public int price;
        public int end;
    }
}
