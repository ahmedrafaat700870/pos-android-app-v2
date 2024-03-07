namespace App.Services.Login
{
    public class LoginServicesV2 : ILoginServices
    {

        private string url = URLS.login_url;

        public async Task<user_model> Login(string username, string password)
        {
            login user = new login() { username = username, password = password };
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Accept", "application/json");
                    var objectData = JsonConvert.SerializeObject(user);
                    var content = new StringContent(objectData, encoding: Encoding.UTF8 , "application/json");
                    var respone = await client.PostAsync(url, content);
                    if (respone.IsSuccessStatusCode)
                    {
                        string data = await respone.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<user_model>(data);
                    }
                    else
                    {
                        return null!;
                    }
                }
            }
            catch 
            {
                return null;
            }
        }
    }
}
