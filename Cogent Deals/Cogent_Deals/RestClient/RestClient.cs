using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Cogent_Deals;
using System.Linq;

namespace Plugin.RestClient
{
    /// <summary>
    /// RestClient implements methods for calling CRUD operations
    /// using HTTP.
    /// </summary>
    public class RestClient
    {
        private const string WebServiceUrl = "http://cogentdeals.com/api/get/content/articles?catid=109&limit=10&maxsubs=10";

        public async Task<ObservableCollection<Deal>> GetAsync(string uri)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(uri);


            JObject json = JObject.Parse(response);
            List<JToken> articles = json["articles"].Children().ToList();

            ObservableCollection<Deal> Deals = new ObservableCollection<Deal>();
            foreach(JToken article in articles)
                {
                    Deal deal = JsonConvert.DeserializeObject<Deal>(article.ToString());
                    Deals.Add(deal);
                }

            return Deals;
        }

        /*
        public async Task<bool> PostAsync(T t)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(t);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PostAsync(WebServiceUrl, httpContent);

            return result.IsSuccessStatusCode;
        }

        public async Task<bool> PutAsync(int id, T t)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(t);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PutAsync(WebServiceUrl + id, httpContent);

            return result.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id, T t)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.DeleteAsync(WebServiceUrl + id);

            return response.IsSuccessStatusCode;
        */
    }
}
