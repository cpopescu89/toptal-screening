using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationFramework.Framework
{
    public class Navigator
    {
        private readonly IWebDriver _browser;


        protected Navigator(IWebDriver browser) => _browser = browser;

        public T GoTo<T>(string url)
        {
            _browser.Navigate().GoToUrl(url);
            return (T)Activator.CreateInstance(typeof(T), _browser);
        }
    }
}