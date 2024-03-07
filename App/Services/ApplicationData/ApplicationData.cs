namespace App.Services.ApplicationData
{
    public class ApplicationData : IApplicationData
    {
        private readonly ICRUDHttpServices _services;
        public ApplicationData(ICRUDHttpServices services)
        {
            _services = services;
        }
        public async Task GetData()
        {

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

        private async Task GetDataPromo()
        {
            get_promo promos = await _services.Get_one<get_promo>(URLS.get_promos);
            App.appServices.promos = promos;
            App.appServices.SetPromos();
        }

        private async Task GetDataUser()
        {
            var user = await this._services.Get_one<get_users>(URLS.get_users);
            App.appServices.user = user ?? new get_users();
        }
        private async Task GetDataCustomers()
        {
            //var customers = this._services.GetAll<get>
        }

        private async Task GetDataProdcuts()
        {
            //var products = this._services.GetAll<get_product>(URLS.get_products);
            var product = await this._services.Get_one<get_product>(URLS.get_products);
            App.appServices.products = product ?? new get_product();
        }

        private async Task GetDataTaxs()
        {
            var taxs = await this._services.Get_one<get_tax>(URLS.get_taxces);

            App.appServices.taxs = taxs ?? new get_tax();
        }

        private async Task GetDataPayments()
        {
            var payments = await this._services.Get_one<get_payments>(URLS.get_payments);
            App.appServices.payments = payments ?? new get_payments();
        }



        
    }
}
