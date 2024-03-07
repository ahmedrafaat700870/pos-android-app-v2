namespace App
{
    public class AppServices
    {
        private SettingsModel Settings { get; set; }
        public user_model currentUser;
        public string userToken;
        // data to application .
        public get_users user;
        public get_product products;
        public get_tax taxs;
        public get_payments payments;
        public get_promo promos;
        
        public List<promo_price_type> promo_price_types;

        public void SetPromos()
        {

            var promotions = new List<promo_price_type>();
            var promoItems = new List<promo_item>();
            var _promos = App.appServices.promos.promo_items;
            foreach (var _prom in _promos)
            {
                promo_item __promo = new promo_item()
                {
                    apply_all = _prom.apply_to_all,
                    apply_to_next = _prom.apply_to_next,
                    Cloud_Id = _prom.id,
                    Cloud_promo_price_type_Id = _prom.promo,
                    created = _prom.created,
                    discount_in_percentage = _prom.discount_in_percentage / 100,
                    fixed_price = _prom.discount_in_fixed_price,
                    is_all = _prom.is_all,
                    is_conditional = _prom.is_conditional,
                    Cloud_product_id = _prom.product,
                };
                promoItems.Add(__promo);
            }


            var promtions = App.appServices.promos.promos.Where(x => x.is_active);

            foreach (var promtion in promtions)
            {
                promo_price_type promoPriceType = new promo_price_type()
                {
                    Cloud_Id = promtion.id,
                    end_date = promtion.end_date,
                    start_date = promtion.start_date,
                    days_of_week = promtion.days_of_week,
                    is_active = promtion.is_active,
                    name = promtion.name,
                };
                promoPriceType.Promo_Item = promoItems.Where(x => x.Cloud_promo_price_type_Id == promoPriceType.Cloud_Id).ToList();
                foreach (var p in promoPriceType.Promo_Item)
                    p.Promotions = promoPriceType;
                promotions.Add(promoPriceType);
            }

            promo_price_types = promotions;
        }


        public SettingsModel GetAppSettings()
        {

            if(Settings is null)
            {
                var data = JsonConvert.DeserializeObject<SettingsModel>(App.GetReadAndWriteFile().ReadTextFile("settings"));
                if (data is null )
                {
                    SettingsModel settingsModel = new SettingsModel()
                    {
                        DiscountSelectedIndex = 0,
                        LangSelectedIndex = 1,
                        SaclePattern = 4,
                        Scale = 13,
                        ScaleDightOfPrice = 3,
                        ScaleDigthOfWehight = 3,
                        StarterSacleCode = 22,
                        EndCode = 1
                    };
                    string content = JsonConvert.SerializeObject(settingsModel);
                    App.GetReadAndWriteFile().WirteTextToFile(content, "settings");
                    data = settingsModel;
                }
                Settings = data;
            }

            return Settings;
        }

        public void SetAppSettings(SettingsModel newSettings)
        {
            Settings = newSettings;
        }
    }
}
