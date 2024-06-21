namespace App.Services.CreatNewCustomer
{
    public class CreateNewCustomer : ICreateNewCustomer
    {
        private readonly HttpClient _httpClient;
        public CreateNewCustomer(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task Create(Account_Client_Post_Model model)
        {
            string url = URLS.post_account_customers;
            if(!_httpClient.DefaultRequestHeaders.Contains("Authorization"))
            {
                string token = App.appServices.userToken;
                _httpClient.DefaultRequestHeaders.Add("Authorization", "Token " + token);
            }
            
            string json = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url , content);
            if (!response.IsSuccessStatusCode)
                throw new Exception(response.Content.ReadAsStringAsync().Result);
            
        }
    }
}
