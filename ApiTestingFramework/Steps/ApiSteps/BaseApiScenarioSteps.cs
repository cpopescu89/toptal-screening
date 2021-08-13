using System;
using System.Threading.Tasks;
using ApiTestingFramework.Apis;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ApiTestingFramework.Steps.ApiSteps
{
    [Binding]
    public class TestTwitterTweetsSteps
    {

        [Given(@"I post a tweet of ""(.*)""")]
        public async Task GivenIPostATweetOf(string tweet)
        {
            var result = await BaseApiTests.GetResult();
        }
        
        [When(@"I retrieve the resource of ""(.*)""")]
        public void WhenIRetrieveTheResourceOf(string apiResource)
        {
            //BaseApiTests.GetResponseOfResource(apiResource);
        }
        
        [Then(@"the latest tweet is my message of ""(.*)""")]
        public void ThenTheLatestTweetIsMyMessageOf(string tweet)
        {
            //Assert.True(BaseApiTests.IsTweetPosted(tweet));
        }
    }
}