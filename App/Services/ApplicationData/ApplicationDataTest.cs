namespace App.Services.ApplicationData
{
    public class ApplicationDataTest : IApplicationData
    {
        public async Task GetData()
        {
            await GetUser();
            await get_product_test();
            await GetDataPromo();
            await GetDataTaxs();
            await GetDataPayments();
        }

        private async Task get_product_test()
        {
            var products = new get_product()
                {
                    addons = null,
                    addon_types = null,
                    item_box = null,
                    products = new List<inventory_prodcut>()
                    {
                        new inventory_prodcut()
                        {
                            active = false,
                            barcode = null,
                            code = null,
                            color = null,
                            cost = 100,
                            cost_after_tax = 100 ,
                            created_by = null,
                            group = null,
                            name = "product one",
                            image = null,
                            price_with_tax = 115,
                            quantity = 100,
                        } ,
                        new inventory_prodcut()
                        {
                            active = false,
                            barcode = null,
                            code = null,
                            color = null,
                            cost = 100,
                            cost_after_tax = 100 ,
                            created_by = null,
                            group = null,
                            name = "product one",
                           image = null,
                            price_with_tax = 115,
                            quantity = 100,
                        },
                         new inventory_prodcut()
                        {
                            active = false,
                            barcode = null,
                            code = null,
                            color = null,
                            cost = 100,
                            cost_after_tax = 100 ,
                            created_by = null,
                            group = null,
                            name = "product one",
                            image = null,
                            price_with_tax = 115,
                            quantity = 100,
                        } ,
                        new inventory_prodcut()
                        {
                            active = false,
                            barcode = null,
                            code = null,
                            color = null,
                            cost = 100,
                            cost_after_tax = 100 ,
                            created_by = null,
                            group = null,
                            name = "product one",
                            image = null,
                            price_with_tax = 115,
                            quantity = 100,
                        },
                         new inventory_prodcut()
                        {
                            active = false,
                            barcode = null,
                            code = null,
                            color = null,
                            cost = 100,
                            cost_after_tax = 100 ,
                            created_by = null,
                            group = null,
                            name = "product one",
                            image = null,
                            price_with_tax = 115,
                            quantity = 100,
                        } ,
                        new inventory_prodcut()
                        {
                            active = false,
                            barcode = null,
                            code = null,
                            color = null,
                            cost = 100,
                            cost_after_tax = 100 ,
                            created_by = null,
                            group = null,
                            name = "product one",
                            image = null,
                            price_with_tax = 115,
                            quantity = 100,
                        },
                         new inventory_prodcut()
                        {
                            active = false,
                            barcode = null,
                            code = null,
                            color = null,
                            cost = 100,
                            cost_after_tax = 100 ,
                            created_by = null,
                            group = null,
                            name = "product one",
                            image = null,
                            price_with_tax = 115,
                            quantity = 100,
                        } ,
                        new inventory_prodcut()
                        {
                            active = false,
                            barcode = null,
                            code = null,
                            color = null,
                            cost = 100,
                            cost_after_tax = 100 ,
                            created_by = null,
                            group = null,
                            name = "product one",
                            image = null,
                            price_with_tax = 115,
                            quantity = 100,
                        },


                    }
                };
            App.appServices.products = products;
        }

        private async Task GetUser()
        {
            var user = new get_users()
            {
                users = new List<users>() { },
                tokens = new List<auth_token>() { },
                customers = new List<account_clients>() { },

            };
            App.appServices.user = user ?? new get_users();
        }

        private async Task GetDataPromo()
        {
            get_promo promos = new get_promo() { };
            App.appServices.promos = promos;
            App.appServices.SetPromos();
        }

        private async Task GetDataTaxs()
        {
            var taxs = new get_tax();

            App.appServices.taxs = taxs;
        }

        private async Task GetDataPayments()
        {
            var payments = new get_payments();
            App.appServices.payments = payments;
        }

    }
}
