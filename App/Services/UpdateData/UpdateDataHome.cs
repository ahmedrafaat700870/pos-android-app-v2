namespace App.Services.UpdateData;

public class UpdateDataHome : IUpdateDataHome
{
    private readonly IApplicationData _applicationData;

    public UpdateDataHome(IApplicationData applicationData)
    {
        _applicationData = applicationData;
    }

    private headers _headers;


    private headers GetDataHeader()
    {
        if (_headers is null)
        {
            _headers = new headers()
            {
                key = "Authorization",
                value = "Token " + App.appServices.currentUser.token
            };
        }

        return this._headers;
    }

    public async Task Update()
    {
        await GetDataTax();
        await GetDataProduct();
        await GetDataPayments();
    }

    private async Task GetDataProduct()
    {
        string url = URLS.get_products;
        string products = string.Empty;

        products = await GetDataHelper.Get(url, new List<headers>() { GetDataHeader() });
        App.appServices.products = JsonConvert.DeserializeObject<get_product>(products) ?? new get_product();
    }

 
    private async Task GetDataTax()
    {
        string url = URLS.get_taxces;
        string taxs = string.Empty;

        taxs = await GetDataHelper.Get(url, new List<headers>() { GetDataHeader() });
        App.appServices.taxs = JsonConvert.DeserializeObject<get_tax>(taxs) ?? new get_tax();
    }

    private async Task GetDataPayments()
    {
        string url = URLS.get_payments;
        string payments = string.Empty;

        payments = await GetDataHelper.Get(url, new List<headers>() { GetDataHeader() });
        App.appServices.payments = JsonConvert.DeserializeObject<get_payments>(payments) ?? new get_payments();
    }
}