using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ApiTestingFramework.Apis.Models;
using ApiTestingFramework.Utils.Settings;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Serialization.Json;

namespace ApiTestingFramework.Apis
{
    class BaseApiTests
    {

        private static HttpClient _client;

        public static void SetAuthentication()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token",
                "14ffa63e30532651698ee379154d7243cb9a6758");
        }


        public static async Task<Result> GetResult()
        {
            var x = await _client.GetAsync(new Uri("https://wger.de/api/v2/workout/"));
            var result = await x.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Result>(result);
        }




        // public static void SetBaseUriAndAuth() => Client = new RestClient(Settings.BaseUrl) {Authenticator = AuthTwitter()};

        //private static OAuth1Authenticator AuthTwitter() =>
        //    OAuth1Authenticator.ForProtectedResource(Settings.ConsumerKey,
        //        Settings.ConsumerSecret, Settings.AccessToken, Settings.AccessTokenSecret);


        //        public static void PostTweet(string message)
        //        {
        //            Request = new RestRequest("/update.json", Method.POST);
        //            Request.AddParameter("status", message, ParameterType.GetOrPost);
        //            GetResponse();
        //        }

        //        public static void GetResponseOfResource(string apiResource)
        //        {
        //            Request = new RestRequest {Resource = apiResource};
        //            GetResponse();
        //        }

        //        private static void GetResponse() => Response = Client.Execute(Request);

        //        private static T DeserialiseResponse<T>()
        //        {
        //            var jsonDeserializer = new JsonDeserializer();
        //            return jsonDeserializer.Deserialize<T>(Response);
        //        }

        //        public static bool IsTweetPosted(string tweet)
        //        {
        //            var result = DeserialiseResponse<List<HomeTimeline>>();
        //            return result[0].Text == tweet;
        //        }
        //    }
        //}
    }
}