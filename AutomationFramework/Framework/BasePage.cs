using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;


namespace AutomationFramework.Framework
{
    public class BasePage
    {
        protected readonly IWebDriver Driver;
        protected readonly WebDriverWait Wait;

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, AppSettings.WaitingTimeoutInSeconds);
        }

        protected IWebElement Notification =>
            Wait.Until(ExpectedConditions.ElementIsVisible(By.TagName("simple-snack-bar")));
    }
}
