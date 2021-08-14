using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace AutomationFramework.Framework.Extensions
{
    public static class WebDriverExtensions
    {
        public static void ScrollToElement(this IWebDriver driver, IWebElement element) =>
            driver.ExecuteJavaScript("arguments[0].scrollIntoView(true);", element);
    }
}
