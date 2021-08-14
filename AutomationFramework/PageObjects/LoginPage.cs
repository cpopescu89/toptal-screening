using AutomationFramework.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace AutomationFramework.PageObjects
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement EmailField => Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("email")));
        private IWebElement PasswordField => Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("password")));
        private IWebElement LoginButton => Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("loginButton")));
        private IWebElement RegisterButton => Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("newCustomerLink")));

        public void ClickLoginButton() => LoginButton.Click();
        public RegisterPage ClickRegisterButton()
        {
            RegisterButton.Click();
            return new RegisterPage(Driver);
        }

        public bool HasRegistrationConfirmationPopup()
        {
            var result = Notification.Displayed;
            Wait.Until(ExpectedConditions.UrlContains("/login"));
            Notification.FindElement(By.TagName("button")).Click();
            return result;
        }

        public void LoginWithCredentials(string email, string password)
        {
            EmailField.SendKeys(email);
            PasswordField.SendKeys(password);
            ClickLoginButton();
        }
    }
}
