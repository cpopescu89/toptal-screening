using AutomationFramework.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace AutomationFramework.PageObjects
{
    public class ProfilePage : BasePage
    {
        public ProfilePage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement UsernameField => Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("username")));
        private IWebElement ImageUrlField => Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("url")));
        private IWebElement SetUsernameButton => Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("submit")));
        private IWebElement LinkImageButton => Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("submitUrl")));
        private IWebElement UsernameLabel => Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".mdl-cell > p")));

        public void LinkImage(string imageLink)
        {
            ImageUrlField.SendKeys(imageLink);
            LinkImageButton.Click();
        }

        public void ChangeUsername(string username)
        {
            UsernameField.SendKeys(username);
            SetUsernameButton.Click();
        }

        public bool HasUpdatedUsername(string username) => Wait.Until(ExpectedConditions.TextToBePresentInElement(UsernameLabel, username));
    }
}
