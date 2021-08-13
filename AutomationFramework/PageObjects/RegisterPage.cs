using System.Collections.Generic;
using System.Linq;
using AutomationFramework.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace AutomationFramework.PageObjects
{
    public class RegisterPage : BasePage
    {
        public RegisterPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement EmailField => Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("emailControl")));
        private IWebElement PasswordField => Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("passwordControl")));
        private IWebElement RepeatPasswordField => Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("repeatPasswordControl")));
        private IWebElement SecurityQuestionDropdown => Wait.Until(ExpectedConditions.ElementIsVisible(By.TagName("mat-select")));
        private IWebElement AnswerField => Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("securityAnswerControl")));

        private IReadOnlyCollection<IWebElement> DropdownOptions =>
            Wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.TagName("mat-option")));

        private IWebElement RegisterButton => Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("registerButton")));

        public void FillEmailField(string content) => EmailField.SendKeys(content);
        public void FillPasswordField(string content)
        {
            PasswordField.SendKeys(content);
            RepeatPasswordField.SendKeys(content);
        }

        public void SelectSecurityQuestionNumber(int number)
        {
            SecurityQuestionDropdown.Click();
            DropdownOptions.ElementAt(number - 1).Click();
        }

        public void FillAnswerField(string answer) => AnswerField.SendKeys(answer);

        public void ClickRegisterButton() => RegisterButton.Click();

        public void Register(string email, string password)
        {
            FillEmailField(email);
            FillPasswordField(password);
            SelectSecurityQuestionNumber(1);
            FillAnswerField("answer");
            ClickRegisterButton();
        }
    }
}
