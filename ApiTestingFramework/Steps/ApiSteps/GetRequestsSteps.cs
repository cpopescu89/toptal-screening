using System;
using System.Linq;
using System.Threading.Tasks;
using ApiTestingFramework.Apis;
using ApiTestingFramework.Apis.Models;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ApiTestingFramework.Steps.ApiSteps
{
    [Binding]
    public class GetRequestsSteps
    {
        private Task<Equipment> _equipment;

        [Given(@"I call the ""(.*)"" endpoint")]
        public async Task GivenICallTheEndpoint(string endpoint)
        {
            await BaseApiTests.CallEndpoint(endpoint);
        }

        [When(@"I retrieve the results")]
        public void WhenIRetrieveTheResults()
        {
            _equipment = BaseApiTests.GetEquipment();
        }

        [Then(@"I get (.*) result")]
        public void ThenIGetResult(int numberOfResults)
        {
            Assert.True(_equipment.Result.results.Length.Equals(numberOfResults));
        }

        [Then(@"the ""(.*)"" is one of them")]
        public void ThenTheIsOneOfThem(string item)
        {
            Assert.True(_equipment.Result.results.Any(x => x.name.Equals(item)));
        }
        
    }
}
