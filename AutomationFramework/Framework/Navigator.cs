using OpenQA.Selenium;
using System;

namespace AutomationFramework.Framework
{
    public class Navigator
    {
        private readonly IWebDriver _driver;


        protected Navigator(IWebDriver driver) => _driver = driver;

        public T GoTo<T>(string url)
        {
            _driver.Navigate().GoToUrl(url);
            return (T)Activator.CreateInstance(typeof(T), _driver);
        }
    }
}