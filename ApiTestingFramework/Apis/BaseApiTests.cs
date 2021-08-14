using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ApiTestingFramework.Apis.Models;
using ApiTestingFramework.Utils.Settings;
using Newtonsoft.Json;


namespace ApiTestingFramework.Apis
{
    class BaseApiTests
    {

        private static HttpClient _client;
        public static HttpResponseMessage Response;
        public static void SetAuthentication()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token",
                Settings.AccessToken);
        }


        public static async Task CallEndpoint(string endpoint) => Response = await _client.GetAsync(new Uri(Settings.BaseUrl + endpoint + "/"));

        public static async Task<Equipment> GetEquipment()
        {
            var result = await Response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Equipment>(result);
        }


        public static async Task CallEndpointPost(string endpoint, string json)
        {
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            Response = await _client.PostAsync(new Uri(Settings.BaseUrl + endpoint + "/"), content);
        }

        public static async Task<GetWeightObject> GetWeight(string endpoint)
        {
            await CallEndpoint(endpoint);
            var result = Response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<GetWeightObject>(result);
        }


    }
}