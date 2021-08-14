using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ApiTestingFramework.Apis;
using ApiTestingFramework.Apis.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ApiTestingFramework.Steps.ApiSteps
{
    [Binding]
    public class PostRequestsSteps
    {
        private PostWeightObject _postWeightObject;
        private GetWeightObject _getWeightObject;
        private string _endpoint;
        [Given(@"I set the current date and a ""(.*)"" weight")]
        public void GivenISetTheCurrentDateAndAWeight(int weight)
        {
            var randomNumber = new Random();
            var startDate = new DateTime(1000, 1, 1);
            var range = (DateTime.Today - startDate).Days;
            var date = startDate.AddDays(randomNumber.Next(range)).ToString("yyyy-MM-dd");
            _postWeightObject = new PostWeightObject { date = date, weight = weight.ToString() };
        }

        [When(@"I post to the ""(.*)"" endpoint")]
        public async Task WhenIPostToTheEndpoint(string endpoint)
        {
            _endpoint = endpoint;
            var json = JsonConvert.SerializeObject(_postWeightObject);
            await BaseApiTests.CallEndpointPost(endpoint, json);
        }

        [Then(@"the request is successfully made")]
        public void ThenTheRequestIsSuccessfullyMade()
        {
            Assert.True(BaseApiTests.Response.IsSuccessStatusCode);
        }

        [Then(@"the data is there")]
        public void ThenTheDataIsThere()
        {
            _getWeightObject = BaseApiTests.GetWeight(_endpoint).Result;
            Assert.True(_getWeightObject.results.Any(x => x.date.Equals(_postWeightObject.date)));
            Assert.True(_getWeightObject.results.Any(x => x.weight.Equals(_postWeightObject.weight + ".00")));
        }

        [Then(@"the request is not successfully made")]
        public void ThenTheRequestIsNotSuccessfullyMade()
        {
            Assert.False(BaseApiTests.Response.IsSuccessStatusCode);
        }

        [Then(@"I get a ""(.*)"" response")]
        public void ThenIGetAResponse(int response)
        {
            Assert.True(BaseApiTests.Response.StatusCode == (HttpStatusCode)response);
        }


        [Then(@"my data is not there")]
        public void ThenMyDataIsNotThere()
        {
            _getWeightObject = BaseApiTests.GetWeight(_endpoint).Result;
            Assert.False(_getWeightObject.results.Any(x => x.date.Equals(_postWeightObject.date)));
            Assert.False(_getWeightObject.results.Any(x => x.weight.Equals(_postWeightObject.weight + ".00")));

        }

    }
}
