
namespace App.Services.ApplicationData
{
    internal class ApplicatonDataV2 : IApplicationData , IClientData
    {
       
        private headers _headers;
        public ApplicatonDataV2() {}

        private void adduserTokne()
        {
            if (App.appServices.currentUser is not null)
            {
                _headers = new headers()
                {
                    key = "Authorization",
                    value = "Token " + App.appServices.currentUser.token
                };
            }
        }

        public async Task GetData()
        {
            adduserTokne();
            // get all data 
            try
            {
                await GetDataUser();

            }
            catch (Exception ex)
            {


            }

            try
            {
                await GetDataCustomers();
            }
            catch (Exception ex)
            {

            }

            try
            {
                await GetDataProdcuts();

            }
            catch (Exception ex)
            {

            }
            try
            {

                await GetDataTaxs();
            }
            catch (Exception ex)
            {

            }
            try
            {
                await GetDataPayments();

            }
            catch (Exception ex)
            {

            }


            try
            {
                await GetDataPromo();
            }
            catch
            {

            }



        }

        public async Task GetDataPromo()
        {
            string url = URLS.get_promos;
            string d = string.Empty;
            if (_headers is null)
                d = await GetDataHelper.Get(url );
            else
                d = await GetDataHelper.Get(url , new List<headers>() { _headers});
            get_promo promos = JsonConvert.DeserializeObject<get_promo>(d);
            App.appServices.promos = promos;
            App.appServices.SetPromos();
        }

        public async Task GetDataUser()
        {
            string url = URLS.get_users;
            string d = string.Empty;
            if (_headers is null)
                d = await GetDataHelper.Get(url);
            else
                d = await GetDataHelper.Get(url, new List<headers>() { _headers });
            get_users user = JsonConvert.DeserializeObject<get_users>(d);
            App.appServices.user = user ?? new get_users();
        }
        public async Task GetDataCustomers()
        {
            //var customers = this._services.GetAll<get>
        }

        public async Task GetDataProdcuts()
        {
            string url = URLS.get_products;
            string d = string.Empty;
            if (_headers is null)
                d = await GetDataHelper.Get(url);
            else
                d = await GetDataHelper.Get(url, new List<headers>() { _headers });
            get_product product = JsonConvert.DeserializeObject<get_product>(d);
            App.appServices.products = product ?? new get_product();
        }

        public async Task GetDataTaxs()
        {
            string url = URLS.get_taxces;
            string d = string.Empty;
            if (_headers is null)
                d = await GetDataHelper.Get(url);
            else
                d = await GetDataHelper.Get(url, new List<headers>() { _headers });
            get_tax tax = JsonConvert.DeserializeObject<get_tax>(d);
            App.appServices.taxs = tax ?? new get_tax();
        }

        public async Task GetDataPayments()
        {
            string url = URLS.get_payments;
            string d = string.Empty;
            if (_headers is null)
                d = await GetDataHelper.Get(url);
            else
                d = await GetDataHelper.Get(url, new List<headers>() { _headers });
            get_payments payments = JsonConvert.DeserializeObject<get_payments>(d);
            App.appServices.payments = payments ?? new get_payments();
        }

    }
}
