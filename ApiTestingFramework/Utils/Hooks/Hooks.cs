using ApiTestingFramework.Apis;
using TechTalk.SpecFlow;

namespace ApiTestingFramework.Utils.Hooks
{
    [Binding]
    internal class Hooks
    {
        [BeforeFeature]
        internal static void BeforeFeatureHooks()
        {
            {
                BaseApiTests.SetAuthentication();
            }
        }

        //[BeforeScenario]
        //internal static void BeforeScenarioHooks()
        //{
        //    {
        //        BaseApiTests.SetBaseUriAndAuth();
        //    }
        //}
    }
}
