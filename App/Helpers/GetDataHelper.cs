namespace App.Helpers
{
    public class GetDataHelper
    {
        public static async Task<string> Get(string url, List<headers>? headers = null)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Accept", "application/json");
                    foreach (var h in headers)
                        client.DefaultRequestHeaders.Add(h.key, h.value);

                    var respone = await client.GetAsync(url);

                    if (respone.IsSuccessStatusCode)
                        return await respone.Content.ReadAsStringAsync();
                    else
                        return null!;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
    public class headers
    {
        public string key { get; set; }
        public string value { get; set; }
    }
}
