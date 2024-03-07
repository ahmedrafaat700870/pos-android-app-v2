using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using HTTPCLIENT.HttpClientServices.interfaces;
using HTTPCLIENT.request_bodys;


namespace HTTPCLIENT.HttpClientServices
{

    public class CRUDHttpServices : ICRUDHttpServices
    {

        private readonly HttpClient _client;

        private const string _application_json = "application/json";
        public CRUDHttpServices(HttpClient client)
        {
            this._client = client;
        }

        public async Task<List<T>> GetAll<T>(string url)
        {

            var response = await _client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            var resualt = new List<T>();

            if (response.Content.Headers.ContentType.MediaType == _application_json)
                resualt = JsonConvert.DeserializeObject<List<T>>(content);

            return resualt;
        }

        public async Task<List<T>> GetAll<T>(string url, object input)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
            var item_to_save = new StringContent(JsonConvert.SerializeObject(input), Encoding.UTF8, _application_json);
            request.Content = item_to_save;
            HttpResponseMessage response = await this._client.SendAsync(request);

            var resualt = new List<T>();
            if (response.IsSuccessStatusCode)
            {
                // Read and process the response if needed
                string content = await response.Content.ReadAsStringAsync();
                resualt = JsonConvert.DeserializeObject<List<T>>(content);
            }

            return resualt;

        }

        public async Task<T> GetByTime_Stamp<T>(string url, string time_stamp)
        {
            var response = await _client.GetAsync(url + $"/{time_stamp}");

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            var resualt = (T)Activator.CreateInstance(typeof(T));

            if (response.Content.Headers.ContentType.MediaType == _application_json)
            {
                resualt = JsonConvert.DeserializeObject<T>(content);
            }

            return resualt;

        }

        public async Task PostAll<T>(string url, List<T> input)
        {

            var dataSended = JsonConvert.SerializeObject(input);

            //Console.WriteLine(dataSended.ToString());
            var item_to_save = new StringContent(dataSended, Encoding.UTF8, _application_json);

            //string s = await item_to_save.ReadAsStringAsync();

            var response = await _client.PostAsync(url, item_to_save);

            var content = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();


        }

        public async Task<T> PostOne<T>(string url, login input)
        {
            var item_to_save = new StringContent(JsonConvert.SerializeObject(input), Encoding.UTF8, _application_json);

            var respone = await _client.PostAsync(url, item_to_save);

            respone.EnsureSuccessStatusCode();

            var content = await respone.Content.ReadAsStringAsync();

            var resualt = (T)Activator.CreateInstance(typeof(T));

            if (respone.Content.Headers.ContentType.MediaType == _application_json)
            {
                resualt = JsonConvert.DeserializeObject<T>(content);
            }

            return resualt;
        }



        public async Task<T> Get_one<T>(string url)
        {
            var response = await _client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            var resualt = (T)Activator.CreateInstance(typeof(T));

            if (response.Content.Headers.ContentType.MediaType == _application_json)
            {
                resualt = JsonConvert.DeserializeObject<T>(content);
            }

            return resualt;
        }

        public bool add_token(string token)
        {

            _client.DefaultRequestHeaders.Add("Authorization", token);
            return true;
        }
    }
}
