using System;
using System.Drawing;
using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace AutomationFramework.Framework
{
    [Binding]
    public sealed class BootstrapSelenium
    {
        private readonly IObjectContainer _container;

        private IWebDriver _driver;

        public BootstrapSelenium(IObjectContainer container) => _container = container;


        [AfterScenario(Order = 100)]
        public void Dispose()
        {
            Console.WriteLine($"Test run finished. Test was: {TestContext.CurrentContext.Result.Outcome}");
            _driver?.Close();
            _driver?.Quit();
            _driver = null;
        }


        [BeforeScenario]
        public void LoadDriver()
        {
            _driver = CreateChromeDriver();
            _container.RegisterInstanceAs(_driver, typeof(IWebDriver));
        }


        private static IWebDriver CreateChromeDriver()
        {
            var options = new ChromeOptions();
            options.AddArguments("--start-maximized");
            options.SetLoggingPreference("performance", LogLevel.Info);
            options.AddArgument("--incognito");
            options.AddArgument("--headless");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
            var driver = new ChromeDriver(options);
            driver.Manage().Window.Size = new Size(1920, 1080);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            return driver;
        }

    }
}
